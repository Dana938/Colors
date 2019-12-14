using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEmitter : MonoBehaviour
{
    static readonly System.Random StaticRandom = new System.Random ();

    GameObject NoObstacleGroundPrefab, SmallObstacleGroundPrefab, BigObstacleGroundPrefab, JumperGroundPrefab;

    // Start is called before the first frame update
    void Start()
    {
        NoObstacleGroundPrefab = Resources.Load ("Prefabs/Ground_None", typeof (GameObject)) as GameObject;
        SmallObstacleGroundPrefab = Resources.Load ("Prefabs/Ground_SmallObstacle", typeof (GameObject)) as GameObject;
        BigObstacleGroundPrefab = Resources.Load ("Prefabs/Ground_BigObstacle", typeof (GameObject)) as GameObject;
        JumperGroundPrefab = Resources.Load ( "Prefabs/Ground_Jumper", typeof ( GameObject ) ) as GameObject;

        for (int i = 0; i < 8; ++i)
            Instantiate (NoObstacleGroundPrefab, new Vector3 ((i * 0.75f) - 3, -1.4f, 0), Quaternion.identity);

        StartCoroutine ( "EmitGround" );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EmitGround ()
    {
        int lastEmit = 0;

        while ( true )
        {
            if (lastEmit == 8)
			{
                lastEmit = 0;
                yield return new WaitForSeconds ( 1.0f );
            }

            int random = (lastEmit == 2 || lastEmit == 4 || lastEmit == 8) ? 0 : StaticRandom.Next ( 0, 10 );
            switch ( random )
            {
                case 0:
                case 1:
                case 3:
                case 5:
                case 6:
                case 7:
                case 9:
                    Instantiate ( NoObstacleGroundPrefab, new Vector3 ( 3, -1.4f, 0 ), Quaternion.identity );
                    break;

                case 2:
                    Instantiate ( SmallObstacleGroundPrefab, new Vector3 ( 3, -1.4f, 0 ), Quaternion.identity );
                    break;

                case 4:
                    Instantiate ( BigObstacleGroundPrefab, new Vector3 ( 3, -1.4f, 0 ), Quaternion.identity );
                    break;

                case 8:
                    Instantiate ( JumperGroundPrefab, new Vector3 ( 3, -1.4f, 0 ), Quaternion.identity );
                    break;
            }

            lastEmit = random;

            yield return new WaitForSeconds ( 0.5f );
        }
    }
}
