using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crowd : MonoBehaviour {
    private List<GameObject> characters = new List<GameObject>();
    public int CrowdSize = 5;
    public GameObject CharacterPrefab;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i <= CrowdSize; i++)
        {
            GameObject character = Instantiate<GameObject>(CharacterPrefab);
            character.GetComponent<MoveOnPath>().Speed = Random.Range(5, 10);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
