using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject ObjectToTrack;
    [SerializeField]
    private float movementSpeed;
    private Camera cam;
    private float camSize;

    private void Start()
    {
        cam = this.GetComponent<Camera>();
        camSize = cam.orthographicSize;
        InvokeRepeating("RecalculateCamSize", 5f, 5f); // every 5 seconds, check if the camera size has changed.
    }

    void LateUpdate () {

        if (ObjectToTrack != null)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(ObjectToTrack.transform.position.x, ObjectToTrack.transform.position.y, this.transform.position.z), movementSpeed * Time.deltaTime);
            this.GetComponent<Rigidbody2D>().velocity = (ObjectToTrack.transform.position - this.transform.position) * movementSpeed * (1/camSize);
        }
        else {
            ObjectToTrack = GameObject.FindGameObjectWithTag("Player");
        }  
    }

    private void RecalculateCamSize()
    {
        if (camSize != cam.orthographicSize)
        {
            float oldCamSize = camSize;
            camSize = cam.orthographicSize;
            Debug.Log("Camera size has changed. Updated Camera speed. Old Speed: " + movementSpeed * (1 / oldCamSize) + ", New Speed: " + movementSpeed * (1 / camSize));
        }
    }
}
