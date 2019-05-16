using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private GameObject runner;
    private float xoffset;
    // Use this for initialization
    void Start () {
        runner = GameObject.FindGameObjectWithTag("Runner");
        xoffset = gameObject.transform.position.x - runner.transform.position.x;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        gameObject.transform.position = new Vector3(runner.transform.position.x+xoffset, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
