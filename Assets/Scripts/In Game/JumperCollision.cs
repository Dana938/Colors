using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperCollision : MonoBehaviour
{
    RuntimeAnimatorController jumperAnimation;

    // Start is called before the first frame update
    void Start()
    {
        jumperAnimation = Resources.Load<RuntimeAnimatorController> ( "Stage/Jumper/Jumper" );
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
            actor.GetComponent<Rigidbody2D> ().AddForce ( Vector2.up * 4.6f, ForceMode2D.Impulse );
            actor.GetComponent<Animator> ().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Actor/Jump" );

            var jumperAnimator = gameObject.GetComponent<Animator> ();
            if ( jumperAnimator.runtimeAnimatorController != jumperAnimation )
                jumperAnimator.runtimeAnimatorController = jumperAnimation;
        }
    }
}
