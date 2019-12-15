using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct Elapsed
{
	public TimeSpan ElapsedTime;
	public DateTime Recorded;
}

public static class Ranking
{
	static readonly string RankingPath = Application.persistentDataPath + "/ranking.txt";

	static Elapsed [] rank = new Elapsed [ 4 ];

	static Ranking ()
	{
		if ( File.Exists ( RankingPath ) )
		{
			int index = 0;
			using ( Stream stream = new FileStream ( RankingPath, FileMode.Open, FileAccess.Read ) )
			{
				using ( TextReader reader = new StreamReader ( stream ) )
				{
					for ( int i = 0; i < 3; ++i )
					{
						string elapsed = reader.ReadLine ();
						string recorded = reader.ReadLine ();

						rank [ index++ ] = new Elapsed ()
						{
							ElapsedTime = TimeSpan.FromTicks ( int.Parse ( elapsed ) ),
							Recorded = DateTime.Parse ( recorded )
						};
					}
				}
			}
		}
	}

	public static void Save ()
	{
		using ( Stream stream = new FileStream ( RankingPath, FileMode.Create ) )
		{
			using ( TextWriter writer = new StreamWriter ( stream ) )
			{
				for ( int i = 0; i < 3; ++i )
				{
					string elapsed = rank [ i ].ElapsedTime.Ticks.ToString ();
					string recorded = rank [ i ].Recorded.ToString ( "yyyy-MM-dd" );

					writer.WriteLine ( elapsed );
					writer.WriteLine ( recorded );
				}
			}
		}
	}

	public static bool Insert (TimeSpan elapsed)
	{
		DateTime now = DateTime.UtcNow;

		rank [ 3 ] = new Elapsed ()
		{
			ElapsedTime = elapsed,
			Recorded = now,
		};

		Sort ();

		if ( rank [ 3 ].ElapsedTime == elapsed )
			return false;

		Save ();

		return rank [ 0 ].ElapsedTime == elapsed;
	}

	private static void Sort ()
	{
		for ( int i = 0; i < 4; ++i )
		{
			int current = i;
			for ( int j = i + 1; j < 4; ++j )
			{
				if ( rank [ current ].ElapsedTime < rank [ j ].ElapsedTime )
					current = j;
			}

			Elapsed temp = rank [ i ];
			rank [ i ] = rank [ current ];
			rank [ current ] = temp;
		}
	}
}
