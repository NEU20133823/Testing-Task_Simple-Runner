using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {
    private float jumpHeight = 1250f;
    private float newPlatformCenterX = 11.5f;
    private float platformCenterY;
    public GameObject newPlatform, platform;
    // Use this for initialization
    void Start() {
        GameObject firstPlatform = GameObject.Find("FirstPlatform");
        platformCenterY = firstPlatform.transform.position.y;
        firstPlatform.GetComponent<MeshRenderer>().material.color = Color.blue;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(5, 0, 0);
        gameObject.transform.Translate(move * Time.deltaTime);
        CreateNewPlatform();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
    }
    void CreateNewPlatform()
    {
        if(newPlatformCenterX-gameObject.transform.position.x < 15)
        {
            platform = (GameObject)Instantiate(newPlatform, new Vector3(newPlatformCenterX, platformCenterY, 0F), Quaternion.identity);
            newPlatformCenterX = newPlatformCenterX + 5;
            float randomNumber = Random.value;
            if (randomNumber < 0.5)
            {
                platform.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            else
            {
                platform.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
