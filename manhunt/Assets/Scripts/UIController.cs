using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public GameObject File;

	// Use this for initialization
	void Start () {
        File.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showFile()
    {
        File.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.LoadScene("park");
    }
}
