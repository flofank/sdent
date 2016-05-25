using UnityEngine;
using System.Collections;

public class Envelope : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Hello", gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void Clicked()
    {
        Debug.Log("Clicked", gameObject);
    }
}
