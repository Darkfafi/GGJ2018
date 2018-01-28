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
                return 11f;
        }

        return -1;
    }

    public static Color GetColorFor(Modes mode)
    {
        Color c = Color.black;
        switch (mode)
        {
            case Modes.LEO:
                ColorUtility.TryParseHtmlString("#0000FF", out c);
                break;
            case Modes.MEO:
                ColorUtility.TryParseHtmlString("#00FF00", out c);
                break;
            case Modes.HEO:
                ColorUtility.TryParseHtmlString("#FF0000", out c);
                break;
        }

        return c;
    }

    public static float GetSpeedFor(Modes mode)
    {
        switch (mode)
        {
            case Modes.LEO:
                return 0.35f;
            case Modes.MEO:
                return 0.25f;
            case Modes.HEO:
                return 0.15f;
        }

        return 0.25f;
    }
}
