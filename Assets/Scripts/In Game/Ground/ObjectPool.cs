using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
	Ground,
	SmallObstacleGround,
	BigObstacleGround,
	JumperGround,
}

public class ObjectPool : MonoBehaviour
{
	Queue<GameObject> poolQueue = new Queue<GameObject> ();
	GameObject [] prefabs;

	void Start ()
	{
		prefabs = new GameObject [ 4 ];
		prefabs [ 0 ] = Resources.Load ( "Prefabs/Ground_None", typeof ( GameObject ) ) as GameObject;
		prefabs [ 1 ] = Resources.Load ( "Prefabs/Ground_SmallObstacle", typeof ( GameObject ) ) as GameObject;
		prefabs [ 2 ] = Resources.Load ( "Prefabs/Ground_BigObstacle", typeof ( GameObject ) ) as GameObject;
		prefabs [ 3 ] = Resources.Load ( "Prefabs/Ground_Jumper", typeof ( GameObject ) ) as GameObject;
	}

	public GameObject GetObject ( ObjectType type )
	{
		GameObject ret = null;

		if ( poolQueue.Count > 0 )
		{
			GameObject poolFirst = poolQueue.Dequeue ();
			if ( poolFirst.tag == prefabs [ ( int ) type ].tag )
			{
				ret = poolFirst;
				ret.SetActive ( true );
				ret.GetComponentInChildren<RandomColor> ()?.GenerateRandomColor ();
			}
			else
			{
				poolQueue.Enqueue ( poolFirst );
				while ( poolQueue.Peek () != poolFirst )
				{
					GameObject obj = poolQueue.Dequeue ();
					if ( obj.tag == prefabs [ ( int ) type ].tag )
					{
						ret = obj;
						ret.SetActive ( true );
						ret.GetComponentInChildren<RandomColor> ()?.GenerateRandomColor ();
						break;
					}
					else poolQueue.Enqueue ( obj );
				}
			}
		}

		if ( ret == null )
		{
			ret = Instantiate ( prefabs [ ( int ) type ] );
			ret.transform.parent = gameObject.transform;
		}

		return ret;
	}

	public void ReturnObject ( GameObject obj )
	{
		obj.SetActive ( false );
		poolQueue.Enqueue ( obj );
	}
}
