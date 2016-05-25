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
        transform.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_walk0_body");
        transform.Find("trousers").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_walk0_trousers_oliv");
        transform.Find("top").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_walk0_top_shirtgrayorange");
    }

    public void walk2()
    {
        transform.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_walk1_body");
        transform.Find("trousers").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_walk1_trousers_oliv");
        transform.Find("top").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("char_walk1_top_shirtgrayorange");
    }
}
