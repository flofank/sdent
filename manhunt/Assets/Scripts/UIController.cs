using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public GameObject File = null;
    public GameObject Level = null;

	// Use this for initialization
	void Start () {
        hideFile();
        if (Level != null)
        {
            Level.GetComponent<Text>().text = "Level " + Game.level;
        }
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

            if(File.transform.FindChild("Case") != null)
            File.transform.FindChild("Case").GetComponent<Text>().text = Game.Case;
        }
    }

    public void hideFile()
    {
        if (File != null)
        {
            File.SetActive(false);
        }
    }

    public void loadNotes()
    {
        SceneManager.LoadScene("notes");
    }

    public void exitNotes()
    {
        SceneManager.LoadScene("menu");
    }

    public void nextLevel()
    {
        if (Game.gameOver) Game.initializeGame();
        else Game.nextLevel();
    }

    public void loadHome()
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

        string destination = "menu".Equals(scene) ? "home" : scene.ToString();
        Game.warpTime(duration, "car", "travelling to "+destination, scene);
        Game.tries = 0; // reset tries when travelling to another scene
    }

    public void makeCall()
    {
        string info = Game.newInfo(); // maybe display this on call screen?
        if (info != null)
        {                              
            Game.warpTime(600, "phone", "A witness told you: \"" +info+"\"", "menu");
        }
        else
        {
            Game.warpTime(1, "phone", "No additional Information available.", "menu");
        }
    }
}
