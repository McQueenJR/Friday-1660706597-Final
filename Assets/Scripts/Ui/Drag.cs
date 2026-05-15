using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging;

    void OnMouseDown()
    {
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray =
                Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point;
            }
        }
    }
}
