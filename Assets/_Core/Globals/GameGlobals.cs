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
                return 7.5f;
            case Modes.MEO:
                return 9.5f;
            case Modes.HEO:
                return 11.5f;
        }

        return -1;
    }

    public static Color GetColorFor(Modes mode)
    {
        Color c = Color.black;
        switch (mode)
        {
            case Modes.LEO:
                ColorUtility.TryParseHtmlString("#FF0000", out c);
                break;
            case Modes.MEO:
                ColorUtility.TryParseHtmlString("#00FF00", out c);
                break;
            case Modes.HEO:
                ColorUtility.TryParseHtmlString("#0000FF", out c);
                break;
        }

        return c;
    }
}
