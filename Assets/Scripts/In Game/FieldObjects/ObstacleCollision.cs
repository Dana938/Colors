using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    RuntimeAnimatorController walkAnimation, collidedAnimation;
    bool collided = false;

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
            if ( collision.relativeVelocity.y < 0 )
            {
                var actorAnimator = actor.GetComponent<Animator> ();
                if ( actorAnimator.runtimeAnimatorController != walkAnimation )
                    actorAnimator.runtimeAnimatorController = walkAnimation;
            }
            else if (collision.relativeVelocity.y == 0)
            {
                var actorAnimator = actor.GetComponent<Animator> ();
                if ( actorAnimator.runtimeAnimatorController != collidedAnimation )
                {
                    actorAnimator.runtimeAnimatorController = collidedAnimation;
                    collided = true;
                    StartCoroutine ( ChangeAnimationToWalk () );
                }
            }
        }
    }

    private void OnCollisionExit2D ( Collision2D collision )
    {
        collided = false;
    }

    IEnumerator ChangeAnimationToWalk ()
    {
        yield return new WaitForSeconds ( 0.3f );
        GameObject actor = GameObject.Find ( "Actor" );
        var actorAnimator = actor.GetComponent<Animator> ();
        while ( collided )
        {
            yield return null;
        }

        if ( actorAnimator.runtimeAnimatorController == collidedAnimation )
            actorAnimator.runtimeAnimatorController = walkAnimation;
    }
}
