using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crowd : MonoBehaviour {
    public GameObject CharacterPrefab;
    public int crowdSize;
    public int minSpeed = 20;
    public int maxSpeed = 80;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < crowdSize; i++)
        {
            GameObject character = Instantiate<GameObject>(CharacterPrefab);
            character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, 10);
            character.GetComponent<CharacterBuilder>().characterId = i;
            character.GetComponent<MoveOnPath>().Speed = Random.Range(minSpeed, maxSpeed);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
