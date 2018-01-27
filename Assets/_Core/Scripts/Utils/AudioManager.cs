using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundType
{
    SndSignalUp,
    SndSignalDown,
    SndShootRocket,
    SndImpactRocket,
    SndSattiliteIdle,
    SndSattiliteCrash,
    SndSattiliteFalling,
    SndShockwave,
    SndGetPoints,
    SndLosePoints,
    SndMenuClick,
    SndMenuIdle,
    SndGameIdle,
    SndEnemyIdle,
    SndEnemyShoot,
    SndEnemyCrash,
    SndTowerDeactive,
    SndTowerMalfunction,
    SndTowerReActive,
    SndTowerReFuntion,
    SndArnoldGetDown
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    //private Text _scoreText = null;

    public static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("AudioManager");
                    _instance = container.AddComponent<AudioManager>();
                }
            }

            return _instance;
        }
    }

    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.Damage:

                break;
            default:
                break;
        }



    }
}
