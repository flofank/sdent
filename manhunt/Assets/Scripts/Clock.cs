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
        if (Game.gameOver)
        {
            clockText.text = "00:00:00";
        } else
        {
            int timePassed = (int)(Time.time - Game.startTime);
            int timeLeft = Game.timeAvailable - timePassed;
            TimeSpan t = TimeSpan.FromSeconds(timeLeft);
            clockText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            if (timeLeft <= 0)
            {
                Game.gameOver = true;
                Game.showInfo("gameover", "GAME OVER\n You ran out of time. The offender got away.", "Restart", "menu");
            }

        }

        
    }
    
}
