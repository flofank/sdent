using UnityEngine;
using System.Collections;

public class File : MonoBehaviour {
    private bool show = false;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().enabled = show;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle()
    {
        show = !show;
        GetComponent<SpriteRenderer>().enabled = show;
    }
}
