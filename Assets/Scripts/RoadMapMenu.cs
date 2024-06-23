using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoadMapMenu : MonoBehaviour
{
    public Button button_road;
    public Button button_parking;

    void Awake()
    {
        button_road.onClick.AddListener(RoadMap);
        button_parking.onClick.AddListener(ParkingMap);
    }

    
    void RoadMap()
    {
        SceneManager.LoadScene(2);
    }

    void ParkingMap()
    {
        SceneManager.LoadScene(3);
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
