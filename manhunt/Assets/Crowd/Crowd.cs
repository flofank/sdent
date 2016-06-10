using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Crowd : MonoBehaviour {
    public GameObject CharacterPrefab;
    public int crowdSize;
    public int minSpeed = 20;
    public int maxSpeed = 70;
    System.Random rnd = new System.Random();

    // Use this for initialization
    void Start () {

        while(maxSpeed - minSpeed < crowdSize)
        {
            maxSpeed++;
        }

        List<int> speedList = new List<int>();

        int speed = 0;

        if (SceneManager.GetActiveScene().name.Equals(Game.offender.scene.ToString()))
        {
            // Create Wanted person
            GameObject wanted = Instantiate<GameObject>(CharacterPrefab);
            wanted.GetComponent<CharacterBuilder>().zLayer = 99;
            wanted.GetComponent<CharacterBuilder>().c = Game.offender;
            speed = rnd.Next(minSpeed, maxSpeed + 1);
            speedList.Add(speed);
            wanted.GetComponent<MoveOnPath>().Speed = speed;
            wanted.AddComponent<Wanted>();
            crowdSize--;
        }

        for (int i = 0; i < crowdSize; i++)
        {
            GameObject character = Instantiate<GameObject>(CharacterPrefab);
            character.GetComponent<CharacterBuilder>().zLayer = i;
            character.GetComponent<CharacterBuilder>().c = Game.getCrowd()[i];
            do {
                speed = rnd.Next(minSpeed, maxSpeed + 1);
            } while (speedList.Contains(speed));
            speedList.Add(speed);
            character.GetComponent<MoveOnPath>().Speed = speed;
            character.AddComponent<NotWanted>();
        }

	}
	
	// Update is called once per frame
	void Update () {
	}
}
