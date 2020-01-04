using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEmitter : MonoBehaviour
{
    static readonly System.Random StaticRandom = new System.Random ();

    // Start is called before the first frame update
    void Start()
    {
        for ( int i = 0; i < 10; ++i )
        {
            var obj = GameObject.Find ( "Object Pool" ).GetComponent<ObjectPool> ().AddGround ();
            obj.transform.position = new Vector3 ( ( i * 0.75f ) - 3, -1.4f, 0 );
        }

        StartCoroutine ( "EmitGround" );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EmitGround ()
    {
        ObjectPool objectPool = GameObject.Find ( "Object Pool" ).GetComponent<ObjectPool> ();
        int lastEmit = 0;

        while ( true )
        {
            if (lastEmit == 8)
			{
                lastEmit = 0;
                yield return new WaitForSeconds ( 1.0f );
            }

            int random = (lastEmit == 2 || lastEmit == 4 || lastEmit == 8) ? 0 : StaticRandom.Next ( 0, 9 );
            GameObject obj = null;
            switch ( random )
            {
                case 0:
                case 1:
                case 3:
                case 5:
                case 6:
                case 7:
                    obj = objectPool.AddGround ();
                    break;

                case 2:
                    obj = objectPool.AddSmallObstacleGround ();
                    break;

                case 4:
                    obj = objectPool.AddBigObstacleGround ();
                    break;

                case 8:
                    obj = objectPool.AddJumperGround ();
                    break;
            }
            obj.transform.position = new Vector3 ( 4, -1.4f, 0 );

            lastEmit = random;

            yield return new WaitForSeconds ( 0.5f );
        }
    }
}
