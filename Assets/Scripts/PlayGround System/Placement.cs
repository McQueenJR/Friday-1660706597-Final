using UnityEngine;
using UnityEngine.InputSystem;

public class Placement : MonoBehaviour
{
    public GameObject selectedUnit;
    public LayerMask gridLayer;
    
    void Update()
    {
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            PlaceUnit();
        }
    }

    void PlaceUnit()
    {
        if (selectedUnit == null) return;

        Ray ray =
            Camera.main.ScreenPointToRay(
                Mouse.current.position.ReadValue()
            );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, gridLayer))
        {
            GridTile tile =
                hit.collider.GetComponent<GridTile>();

            if (tile != null && !tile.occupied)
            {
                Data data =
                    selectedUnit.GetComponent<Data>();

                if (data != null)
                {
                    if (MoneyManager.Instance.HasEnoughMoney(data.cost))
                    {
                        GameObject spawnedUnit = Instantiate(
                            selectedUnit,
                            tile.transform.position + Vector3.up,
                            Quaternion.identity
                        );

                        tile.SetOccupied(spawnedUnit);

                        Holder holder =
                            spawnedUnit.GetComponent<Holder>();

                        if (holder != null)
                        {
                            holder.currentTile = tile;
                        }

                        MoneyManager.Instance.SpendMoney(data.cost);
                    }
                    else
                    {
                        Debug.Log("Not Enough Money");
                    }
                }
            }
        }
    }
}