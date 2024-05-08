using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float z;
    private float y;
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        //kanan
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -1);
        }

        transform.Translate(0, 0, 0.5f);
    }
}
