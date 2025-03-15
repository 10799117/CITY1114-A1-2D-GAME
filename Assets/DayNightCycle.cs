using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System.Drawing;

public class DayNightScript : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay;
    public Volume ppv;

    public float tick;
    public float seconds;
    public int mins;
    public int hours;
    public int days = 1;


    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }


    void FixedUpdate()
    {
        CalcTime();
        DisplayTime();

    }

    public void CalcTime()
    {
        seconds += Time.fixedDeltaTime * tick;

        if (seconds >= 60)
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60)
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24)
        {
            hours = 0;
            days += 1;
        }
        ControlPPV();
    }
    public void ControlPPV() 
    {
        
        if (hours >= 21 && hours < 22) 
        {
            ppv.weight = (float)mins / 60;
        }

        if (hours >= 6 && hours < 7) 
        {
            ppv.weight = 1 - (float)mins / 60; 
            
        }
    }
    public void DisplayTime()
    {

        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins);
        dayDisplay.text = "Day: " + days;
    }


}
















