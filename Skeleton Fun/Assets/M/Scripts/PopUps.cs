using UnityEngine;
using TMPro;
using System;

public class PopUps : MonoBehaviour
{
    float currentTime;

    public TMP_Text currentTimeText;

    int popUpAmount;

    GameObject spawnPopUP;

    float time = 0f;
    float waitTime;

    Bounds bounds;

    [Header("Pop-Ups")]
    public GameObject[] popUps;

    private void Start()
    {
        bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 20, 10));
    }
    private void Update()
    {
        TimeCheck();
        SpawnMoment();
        LiveTimer();

    }

    private void TimeCheck()
    {

        if (currentTime <= 40)
        {
            waitTime = 4;

            popUpAmount = 1;
        }
        if (currentTime > 40 && currentTime <= 100)
        {
            waitTime = 3;

            popUpAmount = 2;
        }
        if (currentTime > 100 && currentTime <= 300)
        {
            waitTime = 2;

            popUpAmount = 3;
        }
        if (currentTime > 300 && currentTime <= 500)
        {
            waitTime = 2;

            popUpAmount = 5;
        }
        if (currentTime > 500)
        {
            waitTime = 1;

            popUpAmount = 4;
        }
    }

    private void SpawnMoment()
    {
        time += Time.deltaTime;

        if (time >= waitTime)
        {
            time = 0f;

            for (int i = 0; i <= popUpAmount; i++)
            {
                spawnPopUP = popUps[UnityEngine.Random.Range(0, popUps.Length)];

                Instantiate(spawnPopUP);
            }
        }

    }

    private void LiveTimer()
    {
        currentTime = currentTime + Time.deltaTime / 2;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
