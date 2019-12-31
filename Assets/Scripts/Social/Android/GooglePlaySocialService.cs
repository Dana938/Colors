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
	public void Initialize ()
	{
		var config = new PlayGamesClientConfiguration.Builder ().RequestIdToken ().Build ();
		PlayGamesPlatform.InitializeInstance ( config );
		PlayGamesPlatform.Activate ();
	}

	public void Login ()
	{
		Social.localUser.Authenticate ( ( bool success ) =>
		{
			if ( success )
			{
				( Social.Active as GooglePlayGames.PlayGamesPlatform ).SetGravityForPopups ( Gravity.TOP );
			}
		} );
	}

	public void ShowLeaderboard ()
	{
		Social.ShowLeaderboardUI ();
	}

	public void UnlockAchievement ( ColorsAchievements achv )
	{
		string id = null;
		switch ( achv )
		{
			case ColorsAchievements.FirstStep: id = "CgkIh6KeoLQLEAIQAA"; break;
			case ColorsAchievements.Mixer: id = "CgkIh6KeoLQLEAIQAQ"; break;
			case ColorsAchievements.Shakoy: id = "CgkIh6KeoLQLEAIQAg"; break;
			case ColorsAchievements.JustOne10Minutes: id = "CgkIh6KeoLQLEAIQAw"; break;
			case ColorsAchievements.RushHour: id = "CgkIh6KeoLQLEAIQBA"; break;
			default:
				throw new ArgumentOutOfRangeException ( "achv" );
		}

		Social.ReportProgress ( id, 100.0f, ( bool success ) => Debug.Log ( $"Did not unlock achievement: {achv}." ) );
	}

	public void IncrementAchievement ( ColorsAchievements achv, int step = 1 )
	{
		string id = null;
		switch ( achv )
		{
			case ColorsAchievements.ChallengerPractice: id = "CgkIh6KeoLQLEAIQBQ"; break;
			case ColorsAchievements.HundredChallenge: id = "CgkIh6KeoLQLEAIQBg"; break;
			case ColorsAchievements.Pi: id = "CgkIh6KeoLQLEAIQBw"; break;
			case ColorsAchievements.Argos: id = "CgkIh6KeoLQLEAIQCQ"; break;
		}

		PlayGamesPlatform.Instance.IncrementAchievement ( id, step, ( bool success ) => Debug.Log ( $"Did not increment achievement: {achv}." ) );
	}

	public void PostScore ( TimeSpan time )
	{
		Social.ReportScore ( ( long ) time.TotalMilliseconds, "CgkIh6KeoLQLEAIQCA", ( bool success ) => Debug.Log ( "Did not post score." ) );
	}
}
