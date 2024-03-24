using UnityEngine;

public class DragAndSnap : MonoBehaviour
{
    public MovableObjectsChecks moveableObjectScript;

    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 snapPosition;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
        transform.position = snapPosition;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = GetMouseWorldPosition();
            Vector3 targetPosition = mousePos + offset;
            transform.position = targetPosition;
            snapPosition = GetNearestGridPosition(targetPosition);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    Vector3 GetNearestGridPosition(Vector3 position)
    {
        float gridSize = 2.0f;
        float x = Mathf.Clamp(Mathf.Round(position.x / gridSize) * gridSize, 0f, 18f);
        float z = Mathf.Clamp(Mathf.Round(position.z / gridSize) * gridSize, 0f, 18f);

        

        return new Vector3(x, position.y, z);
    }
}
