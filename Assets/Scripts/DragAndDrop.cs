using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool dragging;

    public LayerMask alphabetMask;

    public GameObject dragObject;

    private Camera camera;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z));
            RaycastHit hit;

            if (!dragging && Physics.Raycast(ray, out hit, Mathf.Infinity, alphabetMask))
            {
                Debug.Log("Hit an alphabet platform.");
                Debug.Log(hit.transform.gameObject.name);
                dragObject = hit.transform.gameObject;
                dragging = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (dragging && dragObject)
            {
                Vector3 newPos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camera.transform.position.z));
                Debug.Log(newPos);
                newPos.z = 0f;
                dragObject.transform.position = newPos;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
}
