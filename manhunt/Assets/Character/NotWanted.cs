using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NotWanted : MonoBehaviour
{

    private static int MAX_TRIES = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Game.tries++;
        if(Game.tries >= MAX_TRIES)
        {
            Game.tries = 0;
            Game.warpTime(3600, "car", "You accused "+MAX_TRIES+" innocent people\nof being the offender...\nYou should gather additional information at home.", "menu");
        }
    }
}
