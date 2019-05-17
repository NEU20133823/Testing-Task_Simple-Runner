using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour {
    private GameObject runner;
	// Use this for initialization
	void Start () {
		runner= GameObject.FindGameObjectWithTag("Runner");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (runner.transform.position.x - gameObject.transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
