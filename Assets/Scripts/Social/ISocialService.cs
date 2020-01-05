using GooglePlayGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface ISocialService
{
	bool? LoggedIn { get; }

	void Initialize ();
	void Login ();

	void ShowLeaderboard ();
	void ShowAchievement ();

	void UnlockAchievement ( ColorsAchievements achv );
	void IncrementAchievement ( ColorsAchievements achv, int step = 1 );
	void PostScore ( TimeSpan time );
}

public enum ColorsAchievements
{
	FirstStep,
	
	Mixer,
	Shakoy,
	JustOne10Minutes,
	RushHour,

	ChallengerPractice,
	HundredChallenge,
	Pi,
	Argos
}

public static class SocialServiceManager
{
	static ISocialService socialService;

	public static bool SupportSocialService => socialService != null;
	public static bool? LoggedIn => socialService?.LoggedIn;

	static SocialServiceManager ()
	{
		Initialize ();
	}

	public static void Initialize ()
	{
#if UNITY_ANDROID
		socialService = new GooglePlaySocialService ();
#endif
		socialService?.Initialize ();
		socialService?.Login ();
	}

	public static void ShowLeaderboard ()
	{
		socialService?.ShowLeaderboard ();
	}

	public static void ShowAchievement ()
	{
		socialService?.ShowAchievement ();
	}

	public static void UnlockAchievement ( ColorsAchievements achv )
	{
		socialService?.UnlockAchievement ( achv );
	}

	public static void IncrementAchievement ( ColorsAchievements achv, int step = 1 )
	{
		socialService?.IncrementAchievement ( achv );
	}

	public static void PostScore ( TimeSpan time )
	{
		socialService?.PostScore ( time );
	}
}
