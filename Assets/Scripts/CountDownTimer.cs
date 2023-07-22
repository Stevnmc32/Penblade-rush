using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn) 
        {
            if(TimeLeft > 0) 
            {
                TimeLeft -= Time.deltaTime;
                updateTime(TimeLeft);
            }
            else
            {
                Debug.Log("TIMES UP");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTime(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        Text.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

}
