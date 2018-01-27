using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modes
{
    None,
    LEO,
    MEO,
    HEO
};

public class GameGlobals : ScriptableObject
{
    public static float GetHeightFor(Modes mode)
    {
        switch(mode)
        {
            case Modes.LEO:
                return 6;
            case Modes.MEO:
                return 8;
            case Modes.HEO:
                return 10;
        }

        return -1;
    }

    public static Color GetColorFor(Modes mode)
    {
        Color c = Color.black;
        switch (mode)
        {
            case Modes.LEO:
                ColorUtility.TryParseHtmlString("#F7F39A", out c);
                break;
            case Modes.MEO:
                ColorUtility.TryParseHtmlString("#A3DE83", out c);
                break;
            case Modes.HEO:
                ColorUtility.TryParseHtmlString("#239D60", out c);
                break;
        }

        return c;
    }
}
