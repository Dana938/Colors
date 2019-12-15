using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeElapser : MonoBehaviour
{
    TimeSpan startTime;

    public TimeSpan ElapsedTime { get; private set; }
    public GameObject NewRecord;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find ( "Time Text" ).GetComponent<Text> ().font.material.mainTexture.filterMode = FilterMode.Point;

        startTime = DateTime.Now.TimeOfDay;

        StartCoroutine ( UpdateCoroutine () );
    }

    IEnumerator UpdateCoroutine ()
    {
        while ( true )
        {
            if ( GameObject.Find ( "Main Camera" ).GetComponent<GameStates> ().IsGameOver )
            {
                if ( Ranking.Insert ( ElapsedTime ) )
                {
                    NewRecord.SetActive ( true );
                }
                yield break;
            }

            var diff = DateTime.Now.TimeOfDay - startTime;
            ElapsedTime = diff;

            GameObject.Find ( "Time Text" ).GetComponent<Text> ().text = $"{diff.ToString ( "hh\\:mm\\:ss" )}.{diff.Milliseconds.ToString ().PadRight ( 3, '0' )}";

            yield return new WaitForSeconds ( 0.25f );
        }
    }
}
