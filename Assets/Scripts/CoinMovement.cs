using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the coin around the Z-axis
        transform.Rotate(Vector3.forward, 50f * Time.deltaTime);

        // Move the coin along the negative X-axis
        // transform.Translate(Vector3.left * Time.deltaTime);
    }
}
