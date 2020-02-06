using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    RuntimeAnimatorController walkAnimation;

    // Start is called before the first frame update
    void Start()
    {
        walkAnimation = Resources.Load<RuntimeAnimatorController> ( "Actor/Walk" );
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
                {
                    if ( actorAnimator.runtimeAnimatorController == null || actorAnimator.runtimeAnimatorController.animationClips [ 0 ].isLooping )
                        actorAnimator.runtimeAnimatorController = walkAnimation;
                    else
                    {
                        if ( ( actorAnimator.playbackTime - actorAnimator.runtimeAnimatorController.animationClips [ 0 ].length ) < float.Epsilon )
                            actorAnimator.runtimeAnimatorController = walkAnimation;
                    }
                }
            }
        }
    }
}
