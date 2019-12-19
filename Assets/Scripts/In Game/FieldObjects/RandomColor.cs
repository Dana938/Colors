using System;
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
        GenerateRandomColor ();
    }

    public void GenerateRandomColor ()
    {
        do
        {
            TimeSpan elapsed = GameObject.Find ( "Time Text" ).GetComponent<TimeElapser> ().ElapsedTime;

            CurrentColor = StaticRandom.Next ( 0, 10 );
            if ( CurrentColor > 3 )
            {
                if ( elapsed < TimeSpan.FromSeconds ( 30 ) )
                    CurrentColor = StaticRandom.Next ( 0, 4 );
                else if ( elapsed < TimeSpan.FromSeconds ( 60 ) )
                {
                    if ( CurrentColor == ( int ) GameColor.LightGreen || CurrentColor == ( int ) GameColor.Purple )
                        continue;
                }
            }
        }
        while ( CurrentColor == GameObject.Find ( "Main Camera" ).GetComponent<GameStates> ().Color );

        SpriteRenderer renderer = GetComponent<SpriteRenderer> ();

        renderer.color = GameStates.GetColor ( CurrentColor );
    }

    // Update is called once per frame
    void Update()
    {
        GameStates gameStates = GameObject.Find ( "Main Camera" ).GetComponent<GameStates> ();
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
        rigidBody.simulated = !( gameStates.Color == CurrentColor );
    }
}
