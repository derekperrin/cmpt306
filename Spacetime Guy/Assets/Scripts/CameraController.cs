using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private GameObject ObjectToTrack;
    [SerializeField]
    private float movementSpeed;

	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(ObjectToTrack.transform.position.x, ObjectToTrack.transform.position.y, this.transform.position.z), movementSpeed * Time.deltaTime);
        //body.velocity = ObjectToTrack.GetComponent<Rigidbody2D>().velocity - 
    }
}
