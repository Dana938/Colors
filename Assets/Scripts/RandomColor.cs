using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    static readonly System.Random StaticRandom = new System.Random ();

    public int CurrentColor { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        do
        {
            CurrentColor = StaticRandom.Next ( 0, 4 );
        }
        while ( CurrentColor == GameObject.Find ( "Main Camera" ).GetComponent<GameStates> ().Color );

        SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

        switch (CurrentColor)
		{
            case 0:
                renderer.color = new Color ( 0, 1, 1 );
                break;

            case 1:
                renderer.color = new Color ( 1, 0, 1 );
                break;

            case 2:
                renderer.color = new Color ( 1, 1, 0 );
                break;

            case 3:
                renderer.color = new Color ( 0.498f, 0.498f, 0.498f );
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameStates gameStates = GameObject.Find ( "Main Camera" ).GetComponent<GameStates> ();
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
        rigidBody.simulated = !( gameStates.Color == CurrentColor );
    }
}
