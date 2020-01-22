using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameColor
{
    Cyan,
    Magenta,
    Yellow,
    Gray,

    PurpleBlue,     //< Cyan + Magenta
    LightGreen,     //< Cyan + Yellow
    EmainMachaBlue, //< Cyan + Gray
    LightRed,       //< Magenta + Yellow
    Purple,         //< Magenta + Gray
    Gold,           //< Yellow + Gray
}

public class GameStates : MonoBehaviour
{
    public static Color GetColor ( int color )
    {
        switch (color)
        {
            case 0: return new Color ( 0.5f, 1, 1 );                   //< Cyan
            case 1: return new Color ( 1, 0.5f, 1 );                   //< Magenta
            case 2: return new Color ( 1, 1, 0.5f );                   //< Yellow
            case 3: return new Color ( 0.498f, 0.498f, 0.498f );    //< Gray(Black)

            case 4: return ( GetColor ( 0 ) + GetColor ( 1 ) ) / 2; //< Purple Blue
            case 5: return ( GetColor ( 0 ) + GetColor ( 2 ) ) / 2; //< Light Green
            case 6: return ( GetColor ( 0 ) + GetColor ( 3 ) ) / 2; //< Emain-Macha Blue
            case 7: return ( GetColor ( 1 ) + GetColor ( 2 ) ) / 2; //< Light Red
            case 8: return ( GetColor ( 1 ) + GetColor ( 3 ) ) / 2; //< Purple
            case 9: return ( GetColor ( 2 ) + GetColor ( 3 ) ) / 2; //< Gold

            default: throw new ArgumentOutOfRangeException ( "color" );
        }
    }

    public GameObject GameOverBackground;

    public int Color { get; private set; }
    public bool IsGameOver => GameOverBackground.activeSelf;

    public void ChangeColor ( int color )
    {
        Camera camera = GameObject.Find ( "Main Camera" ).GetComponent<Camera> ();
        camera.backgroundColor = GetColor ( Color = color );
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( IsGameOver )
        {
            if ( Input.anyKey )
                ReturnToMenu ();
        }
    }

    public void ReturnToMenu ()
    {
        var audioSource = GameObject.Find ( "GameOverBackground" ).GetComponent<AudioSource> ();
        if ( audioSource.isPlaying )
            return;
        audioSource.Play ();
        StartCoroutine ( WaitForAudioEnd () );
    }

    private IEnumerator WaitForAudioEnd ()
    {
        var audioSource = GameObject.Find ( "GameOverBackground" ).GetComponent<AudioSource> ();
        while ( audioSource.isPlaying )
            yield return new WaitForSeconds ( 0 );
        SceneManager.LoadScene ( "MenuScene" );
    }
}
