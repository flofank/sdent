using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    public static int timeAvailable;
    public static float startTime;
    public static int CROWD_SIZE = 200;
    public static int SUSPECTS = 6;
    public static int MAX_NOTES = 17;
    private static bool ready = false;
    public static List<Character> crowd;
    public static List<Character> suspects;
    public static Character offender;
    private static System.Random r = new System.Random();
    public static int tries;
    public static bool gameOver = false;
    public static int level;
    public static List<string> hints = new List<string>();
    public static int noteCount;
    public static string Case;
    private static List<string> Cases;

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

    public static void initializeGame()
    {
        gameOver = false;
        generateCrowd();
        pickSuspects();
        pickOffender();
        ready = true;
        level = 1;
        createHintList();
        noteCount = 0;
        tries = 0;
        Notes.text = "";
        pickCase();

        timeAvailable = 43200; // 12h
        startTime = Time.time;
        SceneManager.LoadScene("menu");
    }

    public static void nextLevel()
    {
        generateCrowd();
        pickSuspects();
        pickOffender();
        createHintList();
        noteCount = 0;
        tries = 0;
        Notes.text = "";
        pickCase();

        int timeBonus = 43200 - (level * 3600) > 3600 ? 25200 - (level * 3600) : 3600; // 12h - 1h pro level, min 1h
        level++;
        print("Reached level " + level);
        addTime(timeBonus);

        SceneManager.LoadScene("menu");
    }

    private static void generateCrowd()
    {
        crowd = new List<Character>();
        while (crowd.Count < CROWD_SIZE)
        {
            Character c = new Character();
            c.isBold = r.Next(4) == 0; // 25% are bold
            c.hasBeard = r.Next(2) == 0; // 50% have beard
            c.body = (Character.Body) Enum.GetValues(typeof(Character.Body)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Body)).Length));
            do {
                c.haircolor = (Character.HairColor)Enum.GetValues(typeof(Character.HairColor)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.HairColor)).Length));
            }
            while (c.body == Character.Body.bold1 && c.haircolor == Character.HairColor.brown); // Invalid combination
            switch (c.haircolor)
            {
                case Character.HairColor.blond:
                    if(c.hasBeard) c.beard = (string) Enum.GetValues(typeof(Character.Beard_Blond)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Blond)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Blond)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Blond)).Length)).ToString();
                    if(!c.isBold) c.hair = (string) Enum.GetValues(typeof(Character.Hair_Blond)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Blond)).Length)).ToString();
                    break;
                case Character.HairColor.brown:
                    if(c.hasBeard) c.beard = (string) Enum.GetValues(typeof(Character.Beard_Brown)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Brown)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Brown)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Brown)).Length)).ToString();
                    if(!c.isBold) c.hair = (string) Enum.GetValues(typeof(Character.Hair_Brown)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Brown)).Length)).ToString();
                    break;
                case Character.HairColor.red:
                    if(c.hasBeard) c.beard = (string) Enum.GetValues(typeof(Character.Beard_Red)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Red)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Red)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Red)).Length)).ToString();
                    if(!c.isBold) c.hair = (string) Enum.GetValues(typeof(Character.Hair_Red)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Red)).Length)).ToString();
                    break;
                case Character.HairColor.black:
                    if(c.hasBeard) c.beard = (string) Enum.GetValues(typeof(Character.Beard_Black)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Beard_Black)).Length)).ToString();
                    c.eyebrow = (string) Enum.GetValues(typeof(Character.Eyebrow_Black)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eyebrow_Black)).Length)).ToString();
                    if(!c.isBold) c.hair = (string) Enum.GetValues(typeof(Character.Hair_Black)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Hair_Black)).Length)).ToString();
                    break;
            }
            do {
                c.eye = (Character.Eye)Enum.GetValues(typeof(Character.Eye)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Eye)).Length));
            } while (c.body == Character.Body.bold1 && c.eye == Character.Eye.brown); // invalid combination

            c.top = (Character.Top)Enum.GetValues(typeof(Character.Top)).GetValue(r.Next(0, Enum.GetValues(typeof(Character.Top)).Length));
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
            var i = r.Next(crowd.Count);
            Character suspect = crowd[i];
            crowd.RemoveAt(i);

            i = r.Next(3);
            Character.Location location = Character.Location.forest;
            if (i == 0) location = Character.Location.park;
            else if (i == 1) location = Character.Location.mall;

            suspect.location = location;
            suspects.Add(suspect);
        }
    }

    private static void pickOffender()
    {
        var i = r.Next(suspects.Count);
        offender = suspects[i];
    }

    public static List<Character> getCrowd()
    {
        if (!ready)
        {
            initializeGame();
        }
        return crowd;
    }

    public static void skipTime(int seconds)
    {
        timeAvailable = timeAvailable - seconds;
    }

    public static void addTime(int seconds)
    {
        timeAvailable = timeAvailable + seconds;
    }

    public static void warpTime(int seconds, string icon, string infoText, string followingScene)
    {
        Info.info = false;
        Info.timeToWarp = seconds;
        Info.sceneToLoad = followingScene;
        Info.icon = icon;
        Info.infoText = infoText;
        SceneManager.LoadScene("info");
    }

    public static void showInfo(string infoIcon, string infoText, string buttonText, string followingScene)
    {
        Info.info = true;
        Info.icon = infoIcon;
        Info.sceneToLoad = followingScene;
        Info.infoText = infoText;
        Info.buttonText = buttonText;
        SceneManager.LoadScene("info");
    }

    public static string newInfo()
    {
        if (hints.Count == 0 || noteCount >= MAX_NOTES)
        {
            return null;
        }

        int i = r.Next(hints.Count);
        string hint = hints[i];
        hints.RemoveAt(i);
        Notes.text += hint + "\n";
        noteCount++;

        return hint;
    }


    public static void createHintList()
    {
        hints = new List<string>();

        // bold
        hints.Add(offender.isBold ? "He was completely bold!" : "He had hair on his head.");
        // beard
        hints.Add(offender.hasBeard ? "He had a beard or moustache." : "He had no beard.");

        // skin color
        if (offender.body.Equals(Character.Body.bold0))
        {
            if(level == 1) hints.Add("His skin was white.");
            else if (level >= 2)
            {
                hints.Add("His skin was not brown");
                hints.Add("His skin was not light brown");
            }
        }
        else if (offender.body.Equals(Character.Body.bold1))
        {
            if(level == 1) hints.Add("His skin was brown.");
            else if (level >= 2)
            {
               hints.Add("His skin was not white");
               hints.Add("His skin was not light brown");
            }
        }
        else if (offender.body.Equals(Character.Body.bold2))
        {
            if(level==1) hints.Add("His skin was light brown.");
            else if (level >= 2)
            {
                hints.Add("His skin was not brown");
                hints.Add("His skin was not white");
            }
        }

        // eye color
        string eyecolor = offender.eye.ToString();
        if (level < 3) // 1 - 2
        {
            hints.Add("He had " + eyecolor + " eyes.");
        } 
        else if (level < 6) // 3 - 5
        {
            List<string> eyes = Character.getEyeColors();
            eyes.Remove(offender.eye.ToString());
            
            int j = r.Next(eyes.Count);
            string wrong = eyes[j];
            eyes.RemoveAt(j);
            hints.Add("He had " + eyecolor + " or" + wrong +" eyes.");

            j = r.Next(eyes.Count);
            wrong = eyes[j];
            hints.Add("He had " + wrong + " or" + eyecolor + " eyes.");
        }
        else // 6+
        {
            List<string> eyes = Character.getEyeColors();
            eyes.Remove(offender.eye.ToString());

            string wrong = eyes[0];
            string wrong2 = eyes[1];
            string wrong3 = eyes[2];
            string wrong4 = eyes[3];

            hints.Add("He didn't have " + wrong + "or" + wrong3 + " eyes.");
            hints.Add("He didn't have " + wrong2 + "or" + wrong4 + " eyes.");
        }

        // hair color
        string haircolor = offender.haircolor.ToString();
        if(level == 1) hints.Add("He had " + haircolor + " hair.");
        else if( level < 5) // 2 - 4
        {
            List<string> haircolors = Character.getHairColors();
            haircolors.Remove(haircolor);

            int j = r.Next(haircolors.Count);
            string wrong = haircolors[j];
            haircolors.RemoveAt(j);
            hints.Add("He had " + haircolor + " or " + wrong + " hair.");

            j = r.Next(haircolors.Count);
            wrong = haircolors[j];
            hints.Add("He had " + wrong + " or " + haircolor + " hair.");
        }
        else // 5+
        {
            List<string> haircolors = Character.getHairColors();
            haircolors.Remove(haircolor);

            string wrong = haircolors[0];
            string wrong2 = haircolors[1];
            string wrong3 = haircolors[2];
            string wrong4 = haircolors[3];

            hints.Add("He didn't have " + wrong + "or" + wrong3 + " hair.");
            hints.Add("He didn't have " + wrong2 + "or" + wrong4 + " hair.");
        }
        


        // top
        string[] top = offender.top.ToString().Split('_');
        string type = top[0];
        string color = top[1];
        if (level < 7)
        {
            hints.Add("He wore a " + color + " " + type + ".");
        }
        else
        {
            hints.Add("He wore a " + type + ".");
            hints.Add("His top was " + color);
        }

        // trousers
        string trousers = offender.trousers.ToString();
        if (level < 4) hints.Add("His trousers were " + trousers + ".");
        else // 4+
        {
            List<string> trouserColors = Character.getTrouserColors();
            trouserColors.Remove(trousers);

            foreach (string s in trouserColors) {
                hints.Add("His trousers were not " + s + ".");
            }

        }

        // location
        if (level < 3)
        {
            hints.Add("I saw him at the " + offender.location.ToString() + ".");
        }
        else // 3+
        {
            List<string> list = Character.getLocations();
            list.Remove(offender.location.ToString());
            foreach(string s in list) hints.Add("He was not at the " + s + ".");
        }


        // can't remember
        for(int i = 0; i < level; i++)
        {
            hints.Add("I can't remember anything.");
        }
    }

    private static void pickCase()
    {
        if (Cases == null)
        {
            initCases();
        }
        var i = r.Next(Cases.Count);
        Case = Cases[i];
        Cases.RemoveAt(i);
    }

    private static void initCases()
    {
        Cases = new List<string>();
        Cases.Add("Hello Sherlock. A valuable watch was stolen from the jewelry store in downtown. To find it again, and to convict the perpetrators, we need your help. Find the thief who stole the watch.");
        Cases.Add("Hello Sherlock. At the antiquariat dealer an ancient, very valuable book with gold-plated cover was stolen. We need your help to recover it and to convict the offender.");
        Cases.Add("Hello Sherlock. A drug dealer driving in the city on the loose and tried to sell methamphetamines. In order to protect our citizens and to put an end to the activities we depend on your help. Expose the drug dealer.");
        Cases.Add("Hello Sherlock. Last night in a side street was a young women found shot dead. To find the murderer, we need your help.");
        Cases.Add("Hello Sherlock. Our city is in danger. An insider trying to sell information about our power and water supply to criminals. Stop him before the data fall into the wrong hands and the city to come to harm.");
        Cases.Add("Hello Sherlock. Yesterday an old lady was raided in her house. The thief had it in their antique jewelry, which he is now trying to sell. We need your help to grab the thief before he can sell the jewelry.");
        Cases.Add("Hello Sherlock. Last night was the City Bank robbed. The bank robber has cleared all safes and caused great material damage. We need your help to find the bank robber.");
        Cases.Add("Hello Sherlock. We have found out that a trafficker is trying to find a victim in our city. Unfortunately we do not yet know who will be the victim. Help us to prevent this horrible crime and unmask the culprit in time.");
        Cases.Add("Hello Sherlock. Based on our information, we assume that on the next big sporting event in our city a bomb will go off. Find the assassin and hold him before someone gets hurt.");
        Cases.Add("Hello Sherlock. Last night has landed an unknown aircraft on our airfield. Inside the aircraft we have found stolen art. Help us to find the art thief, so he can’t steal art in our city.");
        Cases.Add("Hello Sherlock. This morning, were several computers and laptops stolen in a local school. As we suspect will the thief be trying to sell the equipment on the black market. We have to stop him and need your help.");
    }
}
