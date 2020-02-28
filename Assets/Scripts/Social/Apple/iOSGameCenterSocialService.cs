using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if UNITY_IOS

using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;

class iOSGameCenterSocialService : ISocialService
{
	public iOSGameCenterSocialService ()
	{

	}

	public bool? LoggedIn { get; private set; } = null;

	public void Login ()
	{
		if ( !Social.localUser.authenticated )
		{
			Social.localUser.Authenticate ( ( bool success, string message ) =>
			{
				if ( success )
				{
					LoggedIn = true;
					Debug.Log ( "iOS Game Center Service Signed in: " + Social.localUser.userName );
				}
				else
				{
					LoggedIn = false;
					Debug.Log ( $"iOS Game Center Service Signing failed: {message}" );
				}
			} );
		}
		else
		{
			LoggedIn = Social.localUser.authenticated;
			Debug.Log ( "iOS Game Center Service Signed in: " + Social.localUser.userName );
		}
	}

	public void Initialize ()
	{
		throw new NotImplementedException ();
	}

	public void IncrementAchievement ( ColorsAchievements achv, int step = 1 )
	{
		throw new NotImplementedException ();
	}

	public void PostScore ( TimeSpan time )
	{
		throw new NotImplementedException ();
	}

	public void ShowAchievement ()
	{
		throw new NotImplementedException ();
	}

	public void ShowLeaderboard ()
	{
		throw new NotImplementedException ();
	}

	public void UnlockAchievement ( ColorsAchievements achv )
	{
		throw new NotImplementedException ();
	}
}

#endif