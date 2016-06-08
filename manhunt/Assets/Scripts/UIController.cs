using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public GameObject File;

	// Use this for initialization
	void Start () {
        hideFile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showFile()
    {
        File.SetActive(true);
    }

    public void hideFile()
    {
        File.SetActive(false);
    }

    public void startGame()
    {
        // returns random float from 0.0 to 1.0
        float scene = Random.value;

        if(scene < 0.33) SceneManager.LoadScene("park");
        else if(scene < 0.66) SceneManager.LoadScene("forest");
        else SceneManager.LoadScene("mall");
    }
}
