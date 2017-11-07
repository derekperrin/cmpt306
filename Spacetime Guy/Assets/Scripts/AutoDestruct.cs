using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * GameObject requirements for this script:
 *  - No requirnments.
 * 
 * What this script does:
 *   This script destroys the game object that it was put in after secondsToDestruction seconds after initializing.
 *   secondsToDestruction must be set in Unity.
 *   This script is used in bullets but it can be used for any game object that we want to create.
 */
public class AutoDestruct : MonoBehaviour {
    [SerializeField]
    private float secondsToDestruction;

    void Start () {
        Invoke("DestroyObject", secondsToDestruction);
	}

    private void DestroyObject()
    {
        GameObject.Destroy(this.gameObject);
    }
}
