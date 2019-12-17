using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneCollision : MonoBehaviour
{
    public GameObject GameOverBackground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D ( Collision2D collision )
    {
        GameObject actor = GameObject.Find ( "Actor" );

        if ( collision.gameObject == actor )
        {
            GameOverBackground.SetActive ( true );
        }
    }
}
