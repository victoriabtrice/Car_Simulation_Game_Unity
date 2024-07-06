using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource startEngine;
    public AudioSource carEngine;
    // Start is called before the first frame update
    void Start()
    {
        startEngine.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = PlayerPrefs.GetFloat("SpeedValue", 0);
        if(speed > 0)
        {
            if(!carEngine.isPlaying)
            {
                startEngine.Stop();
                carEngine.Play(); 
            }       
        }
        // if(carEngine.isPlaying)
        // {
        //     carEngine.Stop();
        // }
        
    }
}
