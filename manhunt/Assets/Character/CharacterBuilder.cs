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
        transform.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/char_walk0_body");
        transform.Find("trousers").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/char_walk0_trousers_oliv");
        transform.Find("top").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/char_walk0_top_shirtgrayorange");
    }

    public void walk2()
    {
        transform.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/char_walk1_body");
        transform.Find("trousers").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/char_walk1_trousers_oliv");
        transform.Find("top").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/char_walk1_top_shirtgrayorange");
    }

    private enum Beard {
        black0, black1, black2, black3, black4, black5, black6, black7, black8, black9,
        blond0, blond1, blond2, blond3, blond4, blond5, blond6, blond7, blond8, blond9,
        red0, red1, red2, red3, red4, red5, red6, red7, red8, red9,
        brown0, brown1, brown2, brown3, brown4, brown5, brown6, brown7, brown8, brown9
    }
    private enum BeardType {
    }
}
