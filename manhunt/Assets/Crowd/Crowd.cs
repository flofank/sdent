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
            character.GetComponent<CharacterBuilder>().zLayer = i;
            character.GetComponent<CharacterBuilder>().c = Game.getCrowd()[i];
            character.GetComponent<MoveOnPath>().Speed = Random.Range(minSpeed, maxSpeed);
        }

        // Create Wanted person
        GameObject wanted = Instantiate<GameObject>(CharacterPrefab);
        wanted.GetComponent<CharacterBuilder>().zLayer = 99;
        wanted.GetComponent<CharacterBuilder>().c = Game.offender;
        wanted.GetComponent<MoveOnPath>().Speed = minSpeed - 1;
        wanted.AddComponent<Wanted>();

	}
	
	// Update is called once per frame
	void Update () {
	}
}
