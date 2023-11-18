using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotCounter : MonoBehaviour
{
    public static RobotCounter instance;
    public TMP_Text counterText;
    public int currentRobots = 0;
    public GameObject winScreen;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
 
        counterText.text = "Fixed Robots: " + currentRobots.ToString();
    }

    public void IncreaseRobots(int v)
    {
        currentRobots += v;
        counterText.text = "Fixed Robots: " + currentRobots.ToString();
        if( currentRobots > 3)
        {
           winScreen.SetActive(true);
        }
    }
}