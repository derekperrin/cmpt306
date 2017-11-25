using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour {
    //when clicked, this will load the new (actual game) scene.
    public void LoadingScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
