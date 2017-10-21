using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour {
    public float secondsToDestruction;
    
	void Start () {
        Invoke("DestroyObject", secondsToDestruction);
	}

    private void DestroyObject()
    {
        GameObject.Destroy(this.gameObject);
    }
}
