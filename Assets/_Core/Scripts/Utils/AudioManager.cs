using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    SndSignalUp,        //1
    SndSignalDown,
    SndShootRocket,
    SndImpactRocket,
    SndSattiliteIdle,   //5
    SndSattiliteCrash,
    SndSattiliteFalling,
    SndShockwave,
    SndGetPoints,
    SndLosePoints,      //10
    SndMenuClick,
    SndMenuIdle,
    SndGameIdle,
    SndEnemyIdle,
    SndEnemyShoot,      //15
    SndEnemyCrash,
    SndTowerDeactive,
    SndTowerMalfunction,
    SndTowerReActive,
    SndTowerReFuntion,  //20
    SndArnoldGetDown
}

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip SndSignalUp = null;
    [SerializeField]
    private AudioClip SndSignalDown = null;
    [SerializeField]
    private AudioClip SndShootRocket = null;
    [SerializeField]
    private AudioClip SndImpactRocket = null;
    [SerializeField]
    private AudioClip SndSattiliteIdle = null;
    [SerializeField]
    private AudioClip SndSattiliteCrash = null;
    [SerializeField]
    private AudioClip SndSattiliteFalling = null;
    [SerializeField]
    private AudioClip SndShockwave = null;
    [SerializeField]
    private AudioClip SndGetPoints = null;
    [SerializeField]
    private AudioClip SndLosePoints = null;
    [SerializeField]
    private AudioClip SndMenuClick = null;
    [SerializeField]
    private AudioClip SndMenuIdle = null;
    [SerializeField]
    private AudioClip SndGameIdle = null;
    [SerializeField]
    private AudioClip SndEnemyIdle = null;
    [SerializeField]
    private AudioClip SndEnemyShoot = null;
    [SerializeField]
    private AudioClip SndEnemyCrash = null;
    [SerializeField]
    private AudioClip SndTowerDeactive = null;
    [SerializeField]
    private AudioClip SndTowerMalfunction = null;
    [SerializeField]
    private AudioClip SndTowerReActive = null;
    [SerializeField]
    private AudioClip SndTowerReFuntion = null;
    [SerializeField]
    private AudioClip SndArnoldGetDown = null;


    private AudioSource audioPlayer;

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

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.SndSignalUp:
                audioPlayer.clip = SndSignalUp;
                audioPlayer.Play();
                break;
            case SoundType.SndSignalDown:

                break;
            case SoundType.SndShootRocket:

                break;
            case SoundType.SndSattiliteIdle:

                break;
            case SoundType.SndSattiliteFalling:

                break;
            case SoundType.SndSattiliteCrash:

                break;
            case SoundType.SndShockwave:

            case SoundType.SndGetPoints:

                break;
            case SoundType.SndLosePoints:

                break;
            case SoundType.SndMenuClick:

                break;
            case SoundType.SndMenuIdle:

                break;
            case SoundType.SndGameIdle:

                break;
            case SoundType.SndEnemyShoot:

                break;
            case SoundType.SndEnemyIdle:

                break;
            case SoundType.SndEnemyCrash:

                break;
            case SoundType.SndTowerDeactive:

                break;
            case SoundType.SndTowerReActive:

                break;
            case SoundType.SndTowerMalfunction:

                break;
            case SoundType.SndTowerReFuntion:

                break;
            case SoundType.SndArnoldGetDown:

                break;
            default:
                break;
        }



    }
}
