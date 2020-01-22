using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct PercentageValue<T>
{
	public T Value;
	public int Percentage;
	public PercentageValue ( T value, int percentage ) { Value = value; Percentage = percentage; }
}

public static class Randomizer
{
	static Random sharedRandom = new Random ();

	public static T GetRandomNumber<T> ( params PercentageValue<T> [] percentages )
	{
		var randomValue = sharedRandom.NextDouble ();

		double total = 0;
		foreach ( var percentage in percentages )
		{
			total += percentage.Percentage / 100.0;
			if ( total >= randomValue )
				return percentage.Value;
		}

		return default ( T );
	}
}
