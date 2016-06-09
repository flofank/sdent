using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NotWanted : MonoBehaviour
{

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
        if(Game.tries >= 5)
        {
            Game.tries = 0;
            UIController.loadHome();
        }
    }
}
