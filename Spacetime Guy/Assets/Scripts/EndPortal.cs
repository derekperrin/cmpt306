using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : MonoBehaviour {

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Used mainly for when the monster crashes into the player
        if (collision.gameObject.tag == "Player")
        {
            GlobalControl.Instance.SendMessage("GetPlayerState");
            Debug.Log("health:" + GlobalControl.Instance.playerHealth);
            GlobalControl.Instance.SendMessage("IncrementLevelCompleted");
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
