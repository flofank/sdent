using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Wanted : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    void OnMouseDown()
    {
        Game.warpTime(1800, "questioning", "menu");
    }
}
