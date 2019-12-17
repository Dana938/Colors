using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject ranking1 = GameObject.Find ( "Ranking1" );
        GameObject ranking2 = GameObject.Find ( "Ranking2" );
        GameObject ranking3 = GameObject.Find ( "Ranking3" );

        ranking1.GetComponent<Text> ().text = MakeTimeText ( Ranking.GetRanking ( 0 ).ElapsedTime );
        ranking2.GetComponent<Text> ().text = MakeTimeText ( Ranking.GetRanking ( 1 ).ElapsedTime );
        ranking3.GetComponent<Text> ().text = MakeTimeText ( Ranking.GetRanking ( 2 ).ElapsedTime );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart ()
    {
        SceneManager.LoadScene ( "GameScene" );
    }

    private string MakeTimeText(TimeSpan time)
    {
        return $"{time.ToString ( "hh\\:mm\\:ss" )}.{time.Milliseconds.ToString ().PadRight ( 3, '0' )}";
    }
}
