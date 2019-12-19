using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
	JustGround,
	SmallObstacleGround,
	BigObstacleGround,
	JumperGround,
}

public class ObjectPool : MonoBehaviour
{
	List<GameObject> groundList = new List<GameObject> ();
	List<GameObject> smallObstacleGroundList = new List<GameObject> ();
	List<GameObject> bigObstacleGroundList = new List<GameObject> ();
	List<GameObject> jumperGroundList = new List<GameObject> ();

	GameObject groundPrefab, smallObstacleGroundPrefab, bigObstacleGroundPrefab, jumperGroundPrefab;

	void Start ()
	{
		groundPrefab = Resources.Load ( "Prefabs/Ground_None", typeof ( GameObject ) ) as GameObject;
		smallObstacleGroundPrefab = Resources.Load ( "Prefabs/Ground_SmallObstacle", typeof ( GameObject ) ) as GameObject;
		bigObstacleGroundPrefab = Resources.Load ( "Prefabs/Ground_BigObstacle", typeof ( GameObject ) ) as GameObject;
		jumperGroundPrefab = Resources.Load ( "Prefabs/Ground_Jumper", typeof ( GameObject ) ) as GameObject;
	}

	public GameObject AddGround () { return AddObject ( groundList, groundPrefab ); }
	public GameObject AddSmallObstacleGround () { return AddObject ( smallObstacleGroundList, smallObstacleGroundPrefab ); }
	public GameObject AddBigObstacleGround () { return AddObject ( bigObstacleGroundList, bigObstacleGroundPrefab ); }
	public GameObject AddJumperGround () { return AddObject ( jumperGroundList, jumperGroundPrefab ); }

	private GameObject AddObject ( List<GameObject> list, GameObject prefab )
	{
		GameObject ret = null;

		foreach ( GameObject obj in list )
		{
			if ( !obj.activeInHierarchy )
			{
				ret = obj;
				ret.SetActive ( true );
				ret.GetComponentInChildren<RandomColor> ()?.GenerateRandomColor ();
				break;
			}
		}

		if ( ret == null )
		{
			ret = Instantiate ( prefab );
			list.Add ( ret );
			ret.transform.parent = gameObject.transform;
		}

		return ret;
	}

	public void ReturnObject ( GameObject obj )
	{
		obj.SetActive ( false );
	}
}
