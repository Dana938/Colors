using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Leaderboard, Achievement;

    // Start is called before the first frame update
    void Start()
    {
        RefreshRanking ();

        if ( SocialServiceManager.SupportSocialService )
            StartCoroutine ( CheckSocialServiceLoggedIn () );
    }

    IEnumerator CheckSocialServiceLoggedIn ()
    {
        while ( SocialServiceManager.LoggedIn == null )
            yield return null;

        Leaderboard.SetActive ( SocialServiceManager.LoggedIn.Value );
        Achievement.SetActive ( SocialServiceManager.LoggedIn.Value );
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyUp ( KeyCode.Escape ) )
            Application.Quit ();
        if ( Input.GetKeyUp ( KeyCode.Return ) || Input.GetKeyUp ( KeyCode.Space ) )
            GameStart ();
    }

    void OnApplicationPause ( bool pauseStatus )
    {
        if ( pauseStatus )
        {
            Ranking.Save ();
        }
        else
        {
            Ranking.Load ();
            RefreshRanking ();
        }
    }

    private void RefreshRanking ()
    {
        GameObject ranking1 = GameObject.Find ( "Ranking1" );
        GameObject ranking2 = GameObject.Find ( "Ranking2" );
        GameObject ranking3 = GameObject.Find ( "Ranking3" );

        ranking1.GetComponent<Text> ().text = MakeTimeText ( Ranking.GetRanking ( 0 ).ElapsedTime );
        ranking2.GetComponent<Text> ().text = MakeTimeText ( Ranking.GetRanking ( 1 ).ElapsedTime );
        ranking3.GetComponent<Text> ().text = MakeTimeText ( Ranking.GetRanking ( 2 ).ElapsedTime );
    }

    public void GameStart ()
    {
        var audioSource = GameObject.Find ( "GameStartButton" ).GetComponent<AudioSource> ();
        if ( audioSource.isPlaying )
            return;
        audioSource.Play ();
        StartCoroutine ( WaitForAudioEnd () );
    }

    private IEnumerator WaitForAudioEnd ()
    {
        while ( GameObject.Find ( "GameStartButton" ).GetComponent<AudioSource> ().isPlaying )
            yield return new WaitForSeconds ( 0 );
        SceneManager.LoadScene ( "GameScene" );
    }

    public void ShowLeaderboard ()
    {
        SocialServiceManager.ShowLeaderboard ();
    }

    public void ShowAchievement ()
    {
        SocialServiceManager.ShowAchievement ();
    }

    private string MakeTimeText(TimeSpan time)
    {
        return $"{time.ToString ( "hh\\:mm\\:ss" )}.{time.Milliseconds.ToString ().PadRight ( 3, '0' )}";
    }
}
