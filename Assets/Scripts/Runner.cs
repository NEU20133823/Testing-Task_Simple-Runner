using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Runner : MonoBehaviour {
    private float jumpHeight = 1250f;
    private float newPlatformCenterX;
    private float nextDetectionPointX;
    private float platformCenterY;
    private bool isGround;
    private float preTime;
    private int score;
    public Text display;
    public GameObject newPlatform;
    // Use this for initialization
    void Start() {
        GameObject firstPlatform = GameObject.Find("FirstPlatform");
        platformCenterY = firstPlatform.transform.position.y;
        firstPlatform.GetComponent<MeshRenderer>().material.color = Color.blue;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        newPlatformCenterX = 11.5f;
        nextDetectionPointX = 10f;
        isGround = false;
        preTime = 0f;
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 move = new Vector3(5, 0, 0);
        gameObject.transform.Translate(move * Time.deltaTime);
        CreateNewPlatform();
        if (Input.GetMouseButtonDown(0))
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
            GameObject platform = (GameObject)Instantiate(newPlatform, new Vector3(newPlatformCenterX, platformCenterY, 0F), Quaternion.identity);
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
        PlayerPrefs.SetInt("score", score);
        StartCoroutine(GameOver());
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.transform.position.y > platformCenterY)
        {
            isGround = true;
        }
        if (gameObject.GetComponent<MeshRenderer>().material.color != collision.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            Die();
        }
        else if(gameObject.transform.position.x > nextDetectionPointX)
        {
            score++;
            display.text = "Score: " + score.ToString();
            nextDetectionPointX = nextDetectionPointX + 5;
        }
    }
    IEnumerator GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        yield return new WaitForSeconds(2);
    }
}
