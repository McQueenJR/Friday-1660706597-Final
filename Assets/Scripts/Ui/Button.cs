using UnityEngine;


public class Button : MonoBehaviour
{
    public GameObject unitPrefab;

    public Placement placement;

    public void SelectUnit()
    {
        placement.selectedUnit = unitPrefab;

       
    }
    
}
