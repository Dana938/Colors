using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStates : MonoBehaviour
{
    public GameObject GameOverBackground;

    public int Color { get; private set; }
    public bool IsGameOver => GameOverBackground.activeSelf;

    public void ChangeColor (int color)
	{
        Color = color;

        Camera camera = GameObject.Find ( "Main Camera" ).GetComponent<Camera> ();

        switch ( color )
        {
            // Cyan
            case 0:
                camera.backgroundColor = new Color ( 0, 1, 1 );
                Debug.Log ( "Color To Cyan." );
                break;

            // Magenta
            case 1:
                camera.backgroundColor = new Color ( 1, 0, 1 );
                Debug.Log ( "Color To Magenta." );
                break;
            
            // Yellow
            case 2:
                camera.backgroundColor = new Color ( 1, 1, 0 );
                Debug.Log ( "Color To Yellow." );
                break;

            // Black
            case 3:
                camera.backgroundColor = new Color ( 0.498f, 0.498f, 0.498f );
                Debug.Log ( "Color To Black." );
                break;
        }
	}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu ()
    {
        SceneManager.LoadScene ( "MenuScene" );
    }
}
