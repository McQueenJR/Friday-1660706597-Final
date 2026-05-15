using UnityEngine;

public class GridTile : MonoBehaviour
{
    public bool occupied = false;

    public GameObject currentUnit;

    private Renderer rd;

    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    public void SetOccupied(GameObject unit)
    {
        occupied = true;

        currentUnit = unit;

        rd.material.color = Color.red;
    }

    public void ClearTile()
    {
        occupied = false;

        currentUnit = null;

        rd.material.color = Color.white;
    }
}