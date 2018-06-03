using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RedWinsTrigger : MonoBehaviour {
    public GameObject redWins;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot"))
        {
            SceneManager.LoadScene(4);

        }
        
    }
}
