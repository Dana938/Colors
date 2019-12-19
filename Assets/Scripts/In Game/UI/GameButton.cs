using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    void ChangeColorToCyan () => GetGameStates ().ChangeColor ( 0 );
    void ChangeColorToMagenta () => GetGameStates ().ChangeColor ( 1 );
    void ChangeColorToYellow () => GetGameStates ().ChangeColor ( 2 );
    void ChangeColorToBlack () => GetGameStates ().ChangeColor ( 3 );
    void ChangeColorToPurpleBlue () => GetGameStates ().ChangeColor ( 4 );
    void ChangeColorToLightGreen () => GetGameStates ().ChangeColor ( 5 );
    void ChangeColorToEmainMachaBlue () => GetGameStates ().ChangeColor ( 6 );
    void ChangeColorToLightRed () => GetGameStates ().ChangeColor ( 7 );
    void ChangeColorToPurple () => GetGameStates ().ChangeColor ( 8 );
    void ChangeColorToGold () => GetGameStates ().ChangeColor ( 9 );

    GameStates GetGameStates ()
    {
        return GameObject.Find ( "Main Camera" ).GetComponent<GameStates> ();
    }

    List<GameColor> touchedColors = new List<GameColor> ( 2 );

    public void CyanDown () => ButtonDown ( GameColor.Cyan );
    public void MagentaDown () => ButtonDown ( GameColor.Magenta );
    public void YellowDown () => ButtonDown ( GameColor.Yellow );
    public void BlackDown () => ButtonDown ( GameColor.Gray );
    private void ButtonDown ( GameColor color )
    {
        if ( touchedColors.Count < 2 )
        {
            touchedColors.Add ( color );

            if ( touchedColors.Count == 1 )
            {
                switch ( color )
                {
                    case GameColor.Cyan: ChangeColorToCyan (); break;
                    case GameColor.Magenta: ChangeColorToMagenta (); break;
                    case GameColor.Yellow: ChangeColorToYellow (); break;
                    case GameColor.Gray: ChangeColorToBlack (); break;
                }
            }
            else
            {
                bool cyanIn = touchedColors.Contains ( GameColor.Cyan ),
                    magentaIn = touchedColors.Contains ( GameColor.Magenta ),
                    yellowIn = touchedColors.Contains ( GameColor.Yellow ),
                    blackIn = touchedColors.Contains ( GameColor.Gray );

                if ( cyanIn && magentaIn ) ChangeColorToPurpleBlue ();
                else if ( cyanIn && yellowIn ) ChangeColorToLightGreen ();
                else if ( cyanIn && blackIn ) ChangeColorToEmainMachaBlue ();
                else if ( magentaIn && yellowIn ) ChangeColorToLightRed ();
                else if ( magentaIn && blackIn ) ChangeColorToPurple ();
                else if ( yellowIn && blackIn ) ChangeColorToGold ();
            }
        }
    }

    public void CyanUp () => ButtonUp ( GameColor.Cyan );
    public void MagentaUp () => ButtonUp ( GameColor.Magenta );
    public void YellowUp () => ButtonUp ( GameColor.Yellow );
    public void BlackUp () => ButtonUp ( GameColor.Gray );
    private void ButtonUp ( GameColor color )
    {
        if ( touchedColors.Contains ( color ) )
        {
            touchedColors.Remove ( color );
        }
    }

    void Update ()
    {
        if ( Input.GetKeyDown ( KeyCode.Q ) ) CyanDown ();
        else if ( Input.GetKeyUp ( KeyCode.Q ) ) CyanUp ();

        if ( Input.GetKeyDown ( KeyCode.A ) ) YellowDown ();
        else if ( Input.GetKeyUp ( KeyCode.A ) ) YellowUp ();

        if ( Input.GetKeyDown ( KeyCode.P ) ) MagentaDown ();
        else if ( Input.GetKeyUp ( KeyCode.P ) ) MagentaUp ();

        if ( Input.GetKeyDown ( KeyCode.L ) ) BlackDown ();
        else if ( Input.GetKeyUp ( KeyCode.L ) ) BlackUp ();
    }
}
