using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Info : MonoBehaviour {
    public static bool info = false;
    public static int timeToWarp = 3600;
    public static string sceneToLoad = "menu";
    public static string icon = "questioning";
    public static string buttonText = "OK";
    public static string infoText = "That was the guy - You win!";
    private static int WARP_SPEED = 10;
    private double warpSpeed = 0.1;

	// Use this for initialization
	void Start ()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("loading/" + icon);
        if (info)
        {
            transform.FindChild("infoText").gameObject.SetActive(true);
            transform.FindChild("infoText").gameObject.GetComponent<Text>().text = infoText;
            transform.FindChild("button").gameObject.SetActive(true);
            transform.FindChild("button").FindChild("buttonText").gameObject.GetComponent<Text>().text = buttonText;
        } else
        {
            transform.FindChild("button").gameObject.SetActive(false);
            transform.FindChild("infoText").gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!info)
        { 
            warpSpeed = warpSpeed > WARP_SPEED ? WARP_SPEED : warpSpeed * 1.02;
            if (timeToWarp > 0)
            {
                Game.skipTime((int)warpSpeed);
                timeToWarp = timeToWarp - (int) warpSpeed;
            }
            else
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
	}
}
