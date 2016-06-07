using UnityEngine;
using System.Collections;

public class Character : Component {
    public HairColor haircolor;
    public string beard;
    public string eyebrow;
    public Eye eye;
    public string hair;
    public Top top;
    public Trousers trousers;
    public Body body;


    public enum HairColor { black, blond, red, brown}
    public enum Beard_Black { black0, black1, black2, black3, black4, black5, black6, black7, black8, black9 }
    public enum Beard_Blond { blond0, blond1, blond2, blond3, blond4, blond5, blond6, blond7, blond8, blond9 }
    public enum Beard_Red { red0, red1, red2, red3, red4, red5, red6, red7, red8, red9 }
    public enum Beard_Brown { brown0, brown1, brown2, brown3, brown4, brown5, brown6, brown7, brown8, brown9 }
    public enum Body { bold0, bold1, bold2 }
    public enum Eyebrow_Black { black0, black1, black2, black3 }
    public enum Eyebrow_Blond { blond0, blond1, blond2, blond3 }
    public enum Eyebrow_Red { red0, red1, red2, red3 }
    public enum Eyebrow_Brown { brown0, brown1, brown2, brown3 }
    public enum Eye { black, blue, brown, green, grey }
    public enum Hair_Black { black0, black1, black2, black3, black4, black5, black6, black7, black8, black9, black10, black11 }
    public enum Hair_Blond { blond0, blond1, blond2, blond3, blond4, blond5, blond6, blond7, blond8, blond9, blond10, blond11 }
    public enum Hair_Red { red0, red1, red2, red3, red4, red5, red6, red7, red8, red9, red10, red11 }
    public enum Hair_Brown { brown0, brown1, brown2, brown3, brown4, brown5, brown6, brown7, brown8, brown9, brown10, brown11 }
    public enum Top
    {
        sweater_red, sweater_black, sweater_blue, sweater_green,
        tshirt_blue, tshirt_green, tshirt_purple, tshirt_red, tshirt_white, tshirt_yellow,
        shirt_blue, shirt_lightblue, shirt_red, shirt_white, shirt_yellow,
        suit_grayorange, suit_purple
    }
    public enum Trousers { blue, brown, grey, oliv }

    public bool Equals(Character c)
    {
        bool equals = true;
        equals = equals && hair == c.hair;
        equals = equals && beard == c.beard;
        equals = equals && body == c.body;
        equals = equals && eye == c.eye;
        equals = equals && eyebrow == c.eyebrow;
        equals = equals && top == c.top;
        equals = equals && trousers == c.trousers;
        System.Console.WriteLine("Equals resultet in: " + equals);
        return equals;
    }
}
