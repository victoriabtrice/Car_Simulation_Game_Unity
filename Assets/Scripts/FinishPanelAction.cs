using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPanelAction : MonoBehaviour
{
    public Button button_try;
    public Button button_next;
    // Start is called before the first frame update

    void Awake()
    {
        button_try.onClick.AddListener(try_again);
        button_next.onClick.AddListener(next);
    }

    void try_again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    void next()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
