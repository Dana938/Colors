using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct WaitTimer
{
	TimeSpan objective;
	TimeSpan elapsed;

	public WaitTimer ( TimeSpan objective ) { this.objective = objective; }

	public TimeSpan Objective => objective;
	public TimeSpan Elapsed => elapsed;
	public bool Alarm => elapsed >= objective;

	public void Update ( TimeSpan delta )
	{
		elapsed += delta;
	}

	public void Clear () { elapsed -= objective; }
}
