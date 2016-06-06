using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Game : MonoBehaviour {
    public static int CROWD_SIZE = 100;
    public static List<Character> crowd;
    private Character walter;
    private static System.Random r = new System.Random();

	// Use this for initialization
	void Start () {
        if (crowd == null)
        {
            generateCrowd();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private static void generateCrowd()
    {
        crowd = new List<Character>();
        while (crowd.Count < CROWD_SIZE)
        {
            Character c = new Character();
            c.body = (Character.Body) Enum.GetValues(typeof(Character.Body)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Body)).Length));
            c.beard = (Character.Beard) Enum.GetValues(typeof(Character.Beard)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard)).Length));
            c.eye = (Character.Eye) Enum.GetValues(typeof(Character.Eye)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eye)).Length));
            c.eyebrow = (Character.Eyebrow) Enum.GetValues(typeof(Character.Eyebrow)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow)).Length));
            c.top = (Character.Top) Enum.GetValues(typeof(Character.Top)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Top)).Length));
            c.trousers = (Character.Trousers) Enum.GetValues(typeof(Character.Trousers)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Trousers)).Length));
            c.hair = (Character.Hair) Enum.GetValues(typeof(Character.Hair)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair)).Length));
            bool contains = false;
            foreach (Character ch in crowd)
            {
                if (ch.Equals(c))
                {
                    contains = true;
                    break;
                }
            }
            if (!contains)
            {
                crowd.Add(c);
            } 
        }
    }

    public static List<Character> getCrowd()
    {
        if (crowd == null)
        {
            generateCrowd();
        }
        return crowd;
    }
}
