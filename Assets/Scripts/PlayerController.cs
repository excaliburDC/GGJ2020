using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundDist = 0.2f;
    // public float dashDist = 5f;

    public LayerMask ground;
    public Rigidbody playerRb;
    public Vector3 input;
    public bool isGrounded = true;
    public Transform groundCheck;
    public AudioSource jumpSound;
    public AudioSource collectSound;


    private string levelName;


    // Start is called before the first frame update
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        Debug.Log(levelName);
        if (levelName.Equals("Level 0"))
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        playerRb = this.GetComponent<Rigidbody>();
        groundCheck = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelName.Equals("Level 0") && StateManager.Instance.state != StateManager.States.Play)
        {
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, ground, QueryTriggerInteraction.Ignore);

        input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");

        if (input != Vector3.zero)
        {
            transform.forward = input;

            //walk sound and animation
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * gravity), ForceMode.VelocityChange);
            jumpSound.Play();
            //play jump sound
        }


        //if (Input.GetKeyDown(KeyCode.R)) //dash movement
        //{
        //    Vector3 dashVel = Vector3.Scale(transform.forward, dashDist * new Vector3(Mathf.Log(1f / (Time.deltaTime * playerRb.drag + 1)) /
        //            -Time.deltaTime, 0f, (Mathf.Log(1f / (Time.deltaTime * playerRb.drag + 1)) / -Time.deltaTime)));

        //    playerRb.AddForce(dashVel, ForceMode.VelocityChange);
        //}
    }

    private void FixedUpdate()
    {
        if (!levelName.Equals("Level 0") && StateManager.Instance.state != StateManager.States.Play)
        {
            return;
        }
        playerRb.MovePosition(playerRb.position + input * speed * Time.fixedDeltaTime);
    }

    public void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            ExecuteManager.Instance.AddToAnswer(other.gameObject.name);
            collectSound.Play();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            StateManager.Instance.state = StateManager.States.Fail;
        }
    }
}
