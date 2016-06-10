using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Crowd : MonoBehaviour {
    public GameObject CharacterPrefab;
    public int crowdSize;
    public int minSpeed = 20;
    public int maxSpeed = 50;
    System.Random rnd = new System.Random();

    // Use this for initialization
    void Start () {

        while(maxSpeed - minSpeed < crowdSize)
        {
            maxSpeed++;
        }

        List<int> speedList = new List<int>();

        int speed = 0;

        // offender
        if (SceneManager.GetActiveScene().name.Equals(Game.offender.location.ToString()))
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

        // suspects
        foreach (Character sus in Game.suspects) {
            if (!sus.Equals(Game.offender) && SceneManager.GetActiveScene().name.Equals(sus.location.ToString()))
            { 
                // Create Suspect
                GameObject suspect = Instantiate<GameObject>(CharacterPrefab);
                suspect.GetComponent<CharacterBuilder>().zLayer = 99;
                suspect.GetComponent<CharacterBuilder>().c = sus;
                do {
                    speed = rnd.Next(minSpeed, maxSpeed + 1);
                } while (speedList.Contains(speed));
                speedList.Add(speed);
                suspect.GetComponent<MoveOnPath>().Speed = speed;
                suspect.AddComponent<Suspect>();
                crowdSize--;
            }
        }


        // others
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
