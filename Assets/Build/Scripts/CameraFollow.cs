using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float cameraSpeed = 0.1f;
    Camera myCamera;
	// Use this for initialization
	void Start () {
        myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        myCamera.orthographicSize = (Screen.height / 100f) / .5f;

        if (target) {
            transform.position = Vector3.Lerp(transform.position, target.position + new Vector3 (0,0, -10f), cameraSpeed);
        }
	}
}
