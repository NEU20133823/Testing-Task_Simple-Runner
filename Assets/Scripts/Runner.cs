using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {
    private float jumpHeight = 1500f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(3, 0, 0);
        gameObject.transform.Translate(move * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
    }
}
