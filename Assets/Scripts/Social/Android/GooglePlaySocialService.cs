using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class GooglePlaySocialService : ISocialService
{
	public bool? LoggedIn { get; private set; } = null;

	public void Initialize ()
	{
		var config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.InitializeInstance ( config );
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
	}

	public void Login ()
	{
		if ( !Social.localUser.authenticated )
		{
			Social.localUser.Authenticate ( ( bool success, string message ) =>
			{
				if ( success )
				{
					( Social.Active as GooglePlayGames.PlayGamesPlatform ).SetGravityForPopups ( Gravity.TOP );
					LoggedIn = true;
					Debug.Log ( "Google Play Service Signed in: " + Social.localUser.userName );
				}
				else
				{
					LoggedIn = false;
					Debug.Log ( $"Google Play Service Signing failed: {message}" );
				}
			} );
		}
		else
		{
			LoggedIn = Social.localUser.authenticated;
			Debug.Log ( "Google Play Service Signed in: " + Social.localUser.userName );
		}

	}

	public void ShowLeaderboard ()
	{
		//Social.ShowLeaderboardUI ();
		PlayGamesPlatform.Instance.ShowLeaderboardUI ( GPGSIds.leaderboard_elapsed_time );
	}

	public void UnlockAchievement ( ColorsAchievements achv )
	{
		string id = null;
		switch ( achv )
		{
			case ColorsAchievements.FirstStep: id = GPGSIds.achievement_first_step; break;
			case ColorsAchievements.Mixer: id = GPGSIds.achievement_mixer; break;
			case ColorsAchievements.Shakoy: id = GPGSIds.achievement_shakoy; break;
			case ColorsAchievements.JustOne10Minutes: id = GPGSIds.achievement_just_one_10_minutes; break;
			case ColorsAchievements.RushHour: id = GPGSIds.achievement_rush_hour; break;
			default:
				throw new ArgumentOutOfRangeException ( "achv" );
		}

		PlayGamesPlatform.Instance.UnlockAchievement ( id, ( bool success ) =>
		{
			Debug.Log ( $"Did ${( ( success ) ? "" : "not " )}unlock achievement: {achv}." );
		} );
	}

	public void IncrementAchievement ( ColorsAchievements achv, int step = 1 )
	{
		string id = null;
		switch ( achv )
		{
			case ColorsAchievements.ChallengerPractice: id = GPGSIds.achievement_challenger_practice; break;
			case ColorsAchievements.HundredChallenge: id = GPGSIds.achievement_hundred_challenge; break;
			case ColorsAchievements.Pi: id = GPGSIds.achievement_pi; break;
			case ColorsAchievements.Argos: id = GPGSIds.achievement_argos; break;
		}

		PlayGamesPlatform.Instance.IncrementAchievement ( id, step,
			( bool success ) =>
			{
				Debug.Log ( $"Did {( ( success ) ? " " : "not " )}unlock achievement: {achv}." );
			}
		);
	}

	public void PostScore ( TimeSpan time )
	{
		Social.ReportScore ( ( long ) time.TotalMilliseconds, GPGSIds.leaderboard_elapsed_time,
			( bool success ) =>
				Debug.Log ( $"Did {( success ? "" : "not " )}post score: {time}" )
		);
	}
}
