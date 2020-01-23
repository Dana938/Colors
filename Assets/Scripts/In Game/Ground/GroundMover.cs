using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        transform.position += new Vector3 ( -1.45f, 0, 0 ) * Time.deltaTime;
        /*if ( transform.position.x <= -4 )
        {
            GameObject.Find ( "Object Pool" ).GetComponent<ObjectPool> ().ReturnObject ( gameObject );
        }*/
    }

    void OnBecameInvisible ()
    {
        if ( transform.position.x < 0 )
        {
            var objectPool = GameObject.Find ( "Object Pool" )?.GetComponent<ObjectPool> ();
            objectPool?.ReturnObject ( gameObject );
        }
    }
}
