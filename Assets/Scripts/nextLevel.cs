using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public Button button_home;
    public Button button_nextgame;
    public Text point_res;
    public Text crash_res;
    public Text time;

    void Awake()
    {
        button_home.onClick.AddListener(home);
        button_nextgame.onClick.AddListener(next_level);
    }

    void home()
    {
        PlayerPrefs.DeleteKey("CrashValue");
        PlayerPrefs.DeleteKey("PointValue");
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    void next_level()
    {
        PlayerPrefs.DeleteKey("CrashValue");
        PlayerPrefs.DeleteKey("PointValue");
        PlayerPrefs.Save();
        SceneManager.LoadScene(5);
    }

    // Start is called before the first frame update
    void Start()
    {
        int pointValue = PlayerPrefs.GetInt("PointValue", 0);
        int crashValue = PlayerPrefs.GetInt("CrashValue", 0);
        int hourValue = PlayerPrefs.GetInt("HoursTime", 00);
        int minuteValue = PlayerPrefs.GetInt("MinutesTime", 00);
        int secondValue = PlayerPrefs.GetInt("SecondsTime", 00);
        point_res.text = "Point                 " + pointValue.ToString();
        crash_res.text = "Crash           " + crashValue.ToString();
        time.text = "Time          " + minuteValue.ToString("D2") + ":" + secondValue.ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
