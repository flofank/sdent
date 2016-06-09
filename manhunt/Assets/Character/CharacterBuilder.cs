using UnityEngine;
using System.Collections;

public class CharacterBuilder : MonoBehaviour {
    public bool Walter = false;
    public int zLayer;
    public Character c;
	// Use this for initialization
	void Start ()
    {
        int baseLayer = GetComponent<MoveOnPath>().Path.baseLayer;
        transform.Find("body").gameObject.GetComponent<SpriteRenderer>().sortingOrder = baseLayer + zLayer * 10 + 1;
        transform.Find("trousers").gameObject.GetComponent<SpriteRenderer>().sortingOrder = baseLayer + zLayer * 10 + 2;
        transform.Find("top").gameObject.GetComponent<SpriteRenderer>().sortingOrder = baseLayer + zLayer * 10 + 3;
        transform.Find("eye").gameObject.GetComponent<SpriteRenderer>().sortingOrder = baseLayer + zLayer * 10 + 4;
        transform.Find("eyebrow").gameObject.GetComponent<SpriteRenderer>().sortingOrder = baseLayer + zLayer * 10 + 5;
        transform.Find("beard").gameObject.GetComponent<SpriteRenderer>().sortingOrder = baseLayer + zLayer * 10 + 6;
        transform.Find("hair").gameObject.GetComponent<SpriteRenderer>().sortingOrder = baseLayer + zLayer * 10 + 7;
        walk1();
    }

    // Update is called once per frame
    void Update ()
    {
    }

    public void walk1()
    {
        transform.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/body/char_walk0_body_" + c.body);
        transform.Find("trousers").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/trousers/char_walk0_trousers_" + c.trousers);
        transform.Find("top").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/top/char_walk0_top_" + c.top);
        transform.Find("eye").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/eyes/char_eyes_" + c.eye);
        transform.Find("eyebrow").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/eyebrows/char_eyebrow_" + c.eyebrow);
        transform.Find("beard").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/beard/char_beard_" + c.beard);
        transform.Find("hair").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/hair/char_hair_" + c.hair);
    }

    public void walk2()
    {
        transform.Find("body").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/body/char_walk1_body_" + c.body);
        transform.Find("trousers").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/trousers/char_walk1_trousers_" + c.trousers);
        transform.Find("top").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/top/char_walk1_top_" + c.top);
        transform.Find("eye").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/eyes/char_eyes_" + c.eye);
        transform.Find("eyebrow").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/eyebrows/char_eyebrow_" + c.eyebrow);
        transform.Find("beard").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/beard/char_beard_" + c.beard);
        transform.Find("hair").gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("characters/hair/char_hair_" + c.hair);
    }


}
