using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {
    public static int timeToWarp = 3600;
    public static string sceneToLoad = "menu";
    public static string warpReason = "prison";
    private static int WARP_SPEED = 10;
    private double warpSpeed = 0.1;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("loading/" + warpReason);
    }
	
	// Update is called once per frame
	void Update () {
        warpSpeed = warpSpeed > WARP_SPEED ? WARP_SPEED : warpSpeed * 1.02;
	    if (timeToWarp > 0)
        {
            Game.skipTime((int) warpSpeed);
            timeToWarp = timeToWarp - (int) warpSpeed;
        } else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
	}
}
