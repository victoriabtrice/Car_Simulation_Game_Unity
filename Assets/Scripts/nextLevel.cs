using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public Button button_home;
    public Button button_nextgame;

    void Awake()
    {
        button_home.onClick.AddListener(home);
        button_nextgame.onClick.AddListener(next_level);
    }

    void home()
    {
        SceneManager.LoadScene(0);
    }

    void next_level()
    {
        SceneManager.LoadScene(5);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
