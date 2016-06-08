using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Game : MonoBehaviour {
    public static int timeAvailable = 43200; //12h
    public static float startTime = Time.time;
    public static int CROWD_SIZE = 200;
    public static int SUSPECTS = 6;
    private static bool ready = false;
    public static List<Character> crowd;
    public static List<Character> suspects;
    public static Character offender;
    private static System.Random r = new System.Random();

	// Use this for initialization
	void Start () {
        if (!ready)
        {
            initializeGame();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private static void initializeGame()
    {
        generateCrowd();
        pickSuspects();
        pickOffender();
        ready = true;
    }

    private static void generateCrowd()
    {
        crowd = new List<Character>();
        while (crowd.Count < CROWD_SIZE)
        {
            Character c = new Character();
            c.body = (Character.Body) Enum.GetValues(typeof(Character.Body)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Body)).Length));
            c.haircolor = (Character.HairColor) Enum.GetValues(typeof(Character.HairColor)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.HairColor)).Length));
            if (c.body == Character.Body.bold1 && c.haircolor == Character.HairColor.red) // Invalid combination
            {
                continue;
            }
            switch (c.haircolor)
            {
                case Character.HairColor.blond:
                    c.beard = (string) Enum.GetValues(typeof(Character.Beard_Blond)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Blond)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Blond)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Blond)).Length)).ToString();
                    c.hair = (string) Enum.GetValues(typeof(Character.Hair_Blond)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Blond)).Length)).ToString();
                    break;
                case Character.HairColor.brown:
                    c.beard = (string) Enum.GetValues(typeof(Character.Beard_Brown)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Brown)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Brown)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Brown)).Length)).ToString();
                    c.hair = (string) Enum.GetValues(typeof(Character.Hair_Brown)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Brown)).Length)).ToString();
                    break;
                case Character.HairColor.red:
                    c.beard = (string) Enum.GetValues(typeof(Character.Beard_Red)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Red)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Red)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Red)).Length)).ToString();
                    c.hair = (string) Enum.GetValues(typeof(Character.Hair_Red)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Red)).Length)).ToString();
                    break;
                case Character.HairColor.black:
                    c.beard = (string) Enum.GetValues(typeof(Character.Beard_Black)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Black)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Black)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Black)).Length)).ToString();
                    c.hair = (string) Enum.GetValues(typeof(Character.Hair_Black)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Black)).Length)).ToString();
                    break;
            }
            c.eye = (Character.Eye) Enum.GetValues(typeof(Character.Eye)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eye)).Length));
            c.top = (Character.Top) Enum.GetValues(typeof(Character.Top)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Top)).Length));
            c.trousers = (Character.Trousers) Enum.GetValues(typeof(Character.Trousers)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Trousers)).Length));
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

    private static void pickSuspects()
    {
        suspects = new List<Character>();
        while (suspects.Count < SUSPECTS)
        {
            var i = r.Next(crowd.Count - 1);
            suspects.Add(crowd[i]);
            crowd.RemoveAt(i);
        }
    }

    private static void pickOffender()
    {
        var i = r.Next(crowd.Count - 1);
        offender = crowd[i];
        crowd.RemoveAt(i);
    }

    public static List<Character> getCrowd()
    {
        if (!ready)
        {
            initializeGame();
        }
        return crowd;
    }
}
