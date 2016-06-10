using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour {
    public Text clockText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int timePassed = (int) (Time.time - Game.startTime);
        int timeLeft = Game.timeAvailable - timePassed;
        TimeSpan t = TimeSpan.FromSeconds(timeLeft);
        clockText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
    }
    
}
