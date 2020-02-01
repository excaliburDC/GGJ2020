using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject dragObject;

    private bool dragging;

    public LayerMask alphabetMask;
    public float rotationSpeed;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (StateManager.Instance.State == StateManager.States.Create)
        {
            CreateState();
        }

        if (StateManager.Instance.State == StateManager.States.Create)
        {
            PlayState();
        }
    }

    void CreateState()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
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
                Vector3 newPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
                Debug.Log(newPos);
                newPos.z = 0f;
                dragObject.transform.position = newPos;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                // Rotate Anti-Clockwise
                Vector3 newRot = dragObject.transform.localRotation.eulerAngles;
                newRot.z -= rotationSpeed * Time.deltaTime;
                dragObject.transform.localRotation = Quaternion.Euler(newRot);
            }

            if (Input.GetKey(KeyCode.E))
            {
                // Rotate Clockwise
                Vector3 newRot = dragObject.transform.localRotation.eulerAngles;
                newRot.z += rotationSpeed * Time.deltaTime;
                dragObject.transform.localRotation = Quaternion.Euler(newRot);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }

    void PlayState()
    {

    }
}
