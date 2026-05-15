using UnityEngine;
using UnityEngine.InputSystem;

public class SellManager : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SellUnit();
        }
    }

    void SellUnit()
    {
        Ray ray =
            Camera.main.ScreenPointToRay(
                Mouse.current.position.ReadValue()
            );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Data data =
                hit.collider.GetComponent<Data>();

            Holder holder =
                hit.collider.GetComponent<Holder>();

            if (data != null && holder != null)
            {
                int refund = data.cost / 2;

                MoneyManager.Instance.money += refund;

                MoneyManager.Instance.SendMessage("UpdateUI");

                holder.currentTile.ClearTile();

                Destroy(hit.collider.gameObject);
            }
        }
    }
}