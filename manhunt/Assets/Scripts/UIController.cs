using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public GameObject File = null;

	// Use this for initialization
	void Start () {
        hideFile();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showFile()
    {
        if (File != null)
        {
            if (File.activeSelf)
                hideFile();
            else
                File.SetActive(true);
        }
    }

    public void hideFile()
    {
        if (File != null)
        {
            File.SetActive(false);
        }
    }

    public static void loadHome()
    {
        loadScene("menu");
    }

    public void loadForest()
    {
        loadScene("forest");
    }

    public void loadMall()
    {
        loadScene("mall");
    }

    public void loadPark()
    {
        loadScene("park");
    }


    private static void loadScene(string scene)
    {
        int duration = 0;
        string activeScene = SceneManager.GetActiveScene().name;

        if ("menu".Equals(activeScene)) {
            if ("forest".Equals(scene)) duration = 1800; // 30 min
            else if ("park".Equals(scene)) duration = 900; // 15 min
            else if ("mall".Equals(scene)) duration = 600; // 10 min
        }
        else if ("forest".Equals(activeScene))
        {
            if ("menu".Equals(scene)) duration = 1800; // 30 min
            else if ("park".Equals(scene)) duration = 2100; // 35 min
            else if ("mall".Equals(scene)) duration = 2400; // 40 min
        }
        else if ("park".Equals(activeScene))
        {
            if ("menu".Equals(scene)) duration = 900; // 15 min
            else if ("forest".Equals(scene)) duration = 2100; // 35 min
            else if ("mall".Equals(scene)) duration = 900; // 15 min
        }
        else if ("mall".Equals(activeScene))
        {
            if ("menu".Equals(scene)) duration = 600; // 10 min
            else if ("forest".Equals(scene)) duration = 2400; // 40 min
            else if ("park".Equals(scene)) duration = 900; // 15 min
        }

        Game.warpTime(duration, "car", scene);
    }

    public void makeCall()
    {
        Game.warpTime(600, "phone", "menu");
    }
}
