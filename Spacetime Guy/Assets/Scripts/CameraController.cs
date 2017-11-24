using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //[SerializeField]
    private GameObject ObjectToTrack;
    [SerializeField]
    private float movementSpeed;


	void LateUpdate () {

        if (ObjectToTrack != null)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(ObjectToTrack.transform.position.x, ObjectToTrack.transform.position.y, this.transform.position.z), movementSpeed * Time.deltaTime);
            this.GetComponent<Rigidbody2D>().velocity = ObjectToTrack.transform.position - this.transform.position;
        }
        else {
            ObjectToTrack = GameObject.FindGameObjectWithTag("Player");
        }
            
           
    }
}
