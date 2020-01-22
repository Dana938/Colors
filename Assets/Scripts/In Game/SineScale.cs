using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineScale : MonoBehaviour
{
    float theta = 0;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime * 1.25f;
        float sin = Mathf.Sin ( theta ) / 6;

        gameObject.transform.localScale = new Vector3 ( 0.5f + sin, 0.5f + sin, 1 );
    }
}
