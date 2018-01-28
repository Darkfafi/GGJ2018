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
                audioPlayer.clip = SndSignalDown;
                audioPlayer.Play();
                break;
            case SoundType.SndShootRocket:
                audioPlayer.clip = SndShootRocket;
                audioPlayer.Play();
                break;
            case SoundType.SndSattiliteIdle:
                audioPlayer.clip = SndSattiliteIdle;
                audioPlayer.Play();
                break;
            case SoundType.SndSattiliteFalling:
                audioPlayer.clip = SndSattiliteFalling;
                audioPlayer.Play();
                break;
            case SoundType.SndSattiliteCrash:
                audioPlayer.clip = SndSattiliteCrash;
                audioPlayer.Play();
                break;
            //case SoundType.SndShockwave:
            //    audioPlayer.clip = SndShockwave;
            //    audioPlayer.Play();
            case SoundType.SndGetPoints:
                audioPlayer.clip = SndGetPoints;
                audioPlayer.Play();
                break;
            case SoundType.SndLosePoints:
                audioPlayer.clip = SndLosePoints;
                audioPlayer.Play();
                break;
            case SoundType.SndMenuClick:
                audioPlayer.clip = SndMenuClick;
                audioPlayer.Play();
                break;
            case SoundType.SndMenuIdle:
                audioPlayer.clip = SndMenuIdle;
                audioPlayer.Play();
                break;
            case SoundType.SndGameIdle:
                audioPlayer.clip = SndGameIdle;
                audioPlayer.Play();
                break;
            case SoundType.SndEnemyShoot:
                audioPlayer.clip = SndEnemyShoot;
                audioPlayer.Play();
                break;
            case SoundType.SndEnemyIdle:
                audioPlayer.clip = SndEnemyIdle;
                audioPlayer.Play();
                break;
            case SoundType.SndEnemyCrash:
                audioPlayer.clip = SndEnemyCrash;
                audioPlayer.Play();
                break;
            case SoundType.SndTowerDeactive:
                audioPlayer.clip = SndTowerDeactive;
                audioPlayer.Play();
                break;
            case SoundType.SndTowerReActive:
                audioPlayer.clip = SndTowerReActive;
                audioPlayer.Play();
                break;
            case SoundType.SndTowerMalfunction:
                audioPlayer.clip = SndTowerMalfunction;
                audioPlayer.Play();
                break;
            case SoundType.SndTowerReFuntion:
                audioPlayer.clip = SndTowerReFuntion;
                audioPlayer.Play();
                break;
            case SoundType.SndArnoldGetDown:
                audioPlayer.clip = SndArnoldGetDown;
                audioPlayer.Play();
                break;
            
            default:
                break;
        }



    }
}
