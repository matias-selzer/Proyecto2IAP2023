using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeClocksito : MonoBehaviour
{
    public int minutes, seconds;
    public TMP_Text textTime;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ContarTiempo", 0, 1f);
    }

    public void ContarTiempo()
    {
        seconds--;
        if (seconds == -1)
        {
            seconds = 60;
            minutes--;
        }
        string s = "";
        string m = "";
        if (seconds < 10) s = "0";
        if (minutes < 10) m = "0";
        textTime.text = m+minutes + ":" + s+seconds;

        if(seconds==0 && minutes == 0)
        {
            gameManager.GameOver();
        }
    }
}
