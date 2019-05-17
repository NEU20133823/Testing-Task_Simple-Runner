using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ClickReplay()
    {
        StartCoroutine(Replay());
    }
    IEnumerator Replay()
    {
        SceneManager.LoadScene("SampleScene");
        yield return new WaitForSeconds(2);
    }
}
