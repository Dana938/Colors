using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEmitter : MonoBehaviour
{
	PercentageValue<ObjectType> [] percentages = new [] {
		new PercentageValue<ObjectType> ( ObjectType.Ground, 70 ),
		new PercentageValue<ObjectType> ( ObjectType.SmallObstacleGround, 10 ),
		new PercentageValue<ObjectType> ( ObjectType.BigObstacleGround, 10 ),
		new PercentageValue<ObjectType> ( ObjectType.JumperGround, 10 ),
	};
	ObjectType lastEmitted;
	WaitTimer waitTimer;

	// Start is called before the first frame update
	void Start ()
	{
		ObjectPool objectPool = GameObject.Find ( "Object Pool" ).GetComponent<ObjectPool> ();
		for ( int i = 0; i < 10; ++i )
		{
			var obj = objectPool.GetObject ( ObjectType.Ground );
			obj.transform.position = new Vector3 ( ( i * 0.75f ) - 3, -1.4f, 0 );
		}

		lastEmitted = ObjectType.Ground;
		waitTimer = new WaitTimer ( TimeSpan.FromSeconds ( 0.25 ) );
	}

	// Update is called once per frame
	void Update ()
	{
		waitTimer.Update ( TimeSpan.FromSeconds ( Time.deltaTime ) );

		ObjectPool objectPool = GameObject.Find ( "Object Pool" ).GetComponent<ObjectPool> ();

		if ( waitTimer.Alarm )
		{
			if ( lastEmitted == ObjectType.JumperGround )
			{
				lastEmitted = ObjectType.Ground;
				waitTimer = new WaitTimer ( TimeSpan.FromSeconds ( 0.5 ) );
				return;
			}
			else waitTimer = new WaitTimer ( TimeSpan.FromSeconds ( 0.25 ) );

			GameObject obj = objectPool.GetObject (
				lastEmitted = ( lastEmitted != ObjectType.Ground )
					? ObjectType.Ground
					: Randomizer.GetRandomNumber ( percentages )
			);
			if ( obj == null ) throw new Exception ();
			obj.transform.position = new Vector3 ( 4/* - (( waitTimer.Elapsed - waitTimer.Objective ).Seconds * -1.45f)*/, -1.4f, 0 );

			waitTimer.Clear ();
		}
	}
}
