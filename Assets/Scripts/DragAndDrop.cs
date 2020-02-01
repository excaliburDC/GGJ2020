using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject dragObject;
    private Material baseMaterial;

    private float minX, maxX, minY, maxY;

    private bool dragging;

    [SerializeField] private float clampCorrection;

    public LayerMask alphabetMask;
    public float rotationSpeed;
    public Color tempColor;
    public Color newColor;

    public ParticleSystem clickParticle;

    private void Start()
    {
        mainCamera = Camera.main;

        float camDistance = Vector3.Distance(transform.position, mainCamera.transform.position);
        Vector2 bottomCorner = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        maxY = topCorner.y;
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

            Vector3 clickPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z);

            Ray ray = mainCamera.ScreenPointToRay(clickPos);
            RaycastHit hit;

            if (!dragging && Physics.Raycast(ray, out hit, Mathf.Infinity, alphabetMask))
            {
                //Debug.Log("Hit an alphabet platform.");
                //Debug.Log(hit.transform.gameObject.name);
                dragObject = hit.transform.gameObject;
                dragging = true;

                baseMaterial = dragObject.GetComponent<Renderer>().material;
                Material tempMaterial = new Material(baseMaterial);
                tempMaterial.color = tempColor;
                dragObject.GetComponent<Renderer>().material = tempMaterial;

                dragObject.GetComponent<MeshCollider>().isTrigger = true;

                clickParticle.transform.position = mainCamera.ScreenToWorldPoint(clickPos);
                clickParticle.Play();
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (dragging && dragObject)
            {
                Vector3 newPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));

                newPos.x = Mathf.Clamp(newPos.x, minX + clampCorrection, maxX - clampCorrection);
                newPos.y = Mathf.Clamp(newPos.y, minY + clampCorrection, maxY - clampCorrection);
                newPos.z = 0f;

                dragObject.transform.position = newPos;

                clickParticle.transform.position = newPos;
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

        if (dragging && Input.GetMouseButtonUp(0))
        {
            dragging = false;
            Material tempMaterial = new Material(baseMaterial);
            tempMaterial.color = newColor;
            dragObject.GetComponent<Renderer>().material = tempMaterial;

            dragObject.GetComponent<MeshCollider>().isTrigger = false;

            clickParticle.Stop();
        }
    }

    void PlayState()
    {

    }
}
