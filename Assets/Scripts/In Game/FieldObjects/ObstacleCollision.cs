using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    RuntimeAnimatorController walkAnimation, collidedAnimation;

    // Start is called before the first frame update
    void Start()
    {
        walkAnimation = Resources.Load<RuntimeAnimatorController> ( "Actor/Walk" );
        collidedAnimation = Resources.Load<RuntimeAnimatorController> ( "Actor/Collided" );
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
            Debug.Log ( $"Relative Velocity: {collision.relativeVelocity.x}, {collision.relativeVelocity.y}" );
            if ( Mathf.Abs ( collision.relativeVelocity.x ) > float.Epsilon )
            {
                Debug.Log ( "Collided Animation" );
                var actorAnimator = actor.GetComponent<Animator> ();
                if ( actorAnimator.runtimeAnimatorController != collidedAnimation )
                    actorAnimator.runtimeAnimatorController = collidedAnimation;
            }
            else if ( collision.relativeVelocity.y < 0 )
            {
                var actorAnimator = actor.GetComponent<Animator> ();
                if ( actorAnimator.runtimeAnimatorController != walkAnimation )
                    actorAnimator.runtimeAnimatorController = walkAnimation;
            }
            else if (collision.relativeVelocity.y == 0)
            {
                Debug.Log ( "Collided Animation" );
                var actorAnimator = actor.GetComponent<Animator> ();
                if ( actorAnimator.runtimeAnimatorController != collidedAnimation )
                    actorAnimator.runtimeAnimatorController = collidedAnimation;
            }
        }
    }
}
