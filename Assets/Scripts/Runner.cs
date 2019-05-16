using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Runner : MonoBehaviour {
    private float jumpHeight = 1250f;
    private float newPlatformCenterX = 11.5f;
    private float platformCenterY;
    private bool isGround;
    private float preTime;
    public GameObject newPlatform, platform;
    // Use this for initialization
    void Start() {
        GameObject firstPlatform = GameObject.Find("FirstPlatform");
        platformCenterY = firstPlatform.transform.position.y;
        firstPlatform.GetComponent<MeshRenderer>().material.color = Color.blue;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        isGround = false;
        preTime = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(5, 0, 0);
        gameObject.transform.Translate(move * Time.deltaTime);
        CreateNewPlatform();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float nowTime=Time.realtimeSinceStartup;
            if (nowTime - preTime < 0.2f)//double tap
            {
                ChangeColor();
            }
            else//single tap
            {
                Jump();
                preTime = nowTime;
            }
        }
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
    }
    void Jump()
    {
        if (isGround)
        {
            isGround = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
        }
    }
    void ChangeColor()
    {
        if (gameObject.GetComponent<MeshRenderer>().material.color == Color.blue) 
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
    void CreateNewPlatform()
    {
        if(newPlatformCenterX - gameObject.transform.position.x < 15)
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
    void Die()
    {
        StartCoroutine(GameOver());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.transform.position.y > platformCenterY)
        {
            isGround = true;
        }
        if (gameObject.GetComponent<MeshRenderer>().material.color != collision.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            Die();
        }
    }
    public IEnumerator GameOver()
    {
        SceneManager.LoadScene("SampleScene");
        yield return new WaitForSeconds(2);
    }
}
