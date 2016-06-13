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
        Game.showInfo("prison", "SUCCESS! You found the offender!\nPrepare for the next case!", "Let's go!", "menu");
    }
}
