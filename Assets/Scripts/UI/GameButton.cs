using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    public void ChangeColorToCyan () => GetGameStates ().ChangeColor ( 0 );
    public void ChangeColorToMagenta () => GetGameStates ().ChangeColor ( 1 );
    public void ChangeColorToYellow () => GetGameStates ().ChangeColor ( 2 );
    public void ChangeColorToBlack () => GetGameStates ().ChangeColor ( 3 );

    GameStates GetGameStates ()
    {
        return GameObject.Find ( "Main Camera" ).GetComponent<GameStates> ();
    }

    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }
}
