using UnityEngine;
using System.Collections;

public class CharacterBuilder : MonoBehaviour {
    public bool Walter = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void walk1()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Walter ? "character_walking_1_walter" : "character_walking_1");
    }

    public void walk2()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Walter ? "character_walking_2_walter" : "character_walking_2");
    }
}
