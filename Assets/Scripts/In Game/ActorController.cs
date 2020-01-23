using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public GameObject GameOverBackground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if ( GetComponent<Rigidbody2D> ().velocity.y < -0.1f )
        {
            //GetComponent<Animator> ().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ( "Actor/Jump" );
            GetComponent<Animator> ().runtimeAnimatorController = null;
            GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ( "Actor/fall1" );
        }
    }

    void OnBecameInvisible ()
    {
        GameOverBackground.SetActive ( true );
    }
}
