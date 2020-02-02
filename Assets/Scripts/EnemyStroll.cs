using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStroll : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;
    

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if(moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="PlatformColliders")
        {
            Debug.Log("Enemy entered trigger");
            new WaitForSeconds(1f);
            if (moveRight)
                moveRight = false;
            else
                moveRight = true;
        }
    }
}
