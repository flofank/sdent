using UnityEngine;
using System.Collections;

public class Mugshot : MonoBehaviour {
    public Character c;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        transform.FindChild("suspect").FindChild("body").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/body/char_walk0_body_" + c.body);
        transform.FindChild("suspect").FindChild("trousers").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/trousers/char_walk0_trousers_" + c.trousers);
        transform.FindChild("suspect").FindChild("top").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/top/char_walk0_top_" + c.top);
        transform.FindChild("suspect").FindChild("eye").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/eyes/char_eyes_" + c.eye);
        transform.FindChild("suspect").FindChild("eyebrow").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/eyebrows/char_eyebrow_" + c.eyebrow);
        transform.FindChild("suspect").FindChild("beard").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/beard/char_beard_" + c.beard);
        transform.FindChild("suspect").FindChild("hair").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/hair/char_hair_" + c.hair);
    }

    public void showMugshot(int suspectId)
    {
        if (gameObject.active)
        {
            hideMugshot();
        } else
        {
            c = Game.suspects[suspectId];
            gameObject.SetActive(true);
        }
    }

    public void hideMugshot()
    {
        gameObject.SetActive(false);
    }
}
