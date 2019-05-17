using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    public Text display;
    // Use this for initialization
    void Start () {
        int score = PlayerPrefs.GetInt("score");
        PlayerPrefs.DeleteKey("score");
        display.text = display.text + score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
