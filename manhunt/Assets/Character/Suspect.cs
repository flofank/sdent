using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Suspect : MonoBehaviour
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
        Game.warpTime(1800, "questioning", "The questioning showed that this suspect is not the offender.", "menu");
    }
}
