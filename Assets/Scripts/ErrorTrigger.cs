using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {

            //transition to level 1, show crash UI
            Debug.Log("Trigger Fired");
            SceneManager.LoadSceneAsync("Crash");
        }
    }
}
