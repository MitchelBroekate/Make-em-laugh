using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject scripts;
    PopUps popUps;
    float timeScore;
    public bool dead;

    public Transform skelStartPos;
    public GameObject skel;

    SkeletalClicker clicker;

    public GameObject deathScreen;

    public TMP_Text timeSafedC;
    public float previousBestTimeScore;

    public TMP_Text highScoreTXT;
    float highScore;

    void Start()
    {
        popUps = scripts.GetComponent<PopUps>();
        clicker = GetComponent<SkeletalClicker>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            previousBestTimeScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("hit");

        if(collision.gameObject.tag == "Death")
        {

            skel.GetComponent<Rigidbody>().velocity = Vector3.zero;
            skel.GetComponent<Rigidbody>().isKinematic = true;
            skel.transform.position = skelStartPos.position;

            Time.timeScale = 0;

            clicker.pullForce = 0;

            dead = true;

            timeScore = popUps.currentTime;

            popUps.currentTime = 0;
            popUps.time = 0f;

            SafeTimeScore();
        }


    }

    private void Update()
    {
        if (dead)
        {
            deathScreen.SetActive(true);
        }

        TimeSafe();

    }

    void TimeSafe()
    {

        TimeSpan time = TimeSpan.FromSeconds(timeScore);
        timeSafedC.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    void SafeTimeScore()
    {
        if (timeScore > previousBestTimeScore)
        {
            PlayerPrefs.SetFloat("HighScore", timeScore);

            highScore = PlayerPrefs.GetFloat("HighScore");

            TimeSpan time = TimeSpan.FromSeconds(highScore);
            highScoreTXT.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
        else
        {
            previousBestTimeScore = PlayerPrefs.GetFloat("HighScore");

            TimeSpan time = TimeSpan.FromSeconds(previousBestTimeScore);
            highScoreTXT.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
    }
}
