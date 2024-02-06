using System;
using UnityEngine;
using TMPro;

public class PopUps : MonoBehaviour
{
    float currentTime;

    public TMP_Text currentTimeText;

    int popUpAmount;

    GameObject spawnPopUp;
    GameObject activeAd;
    public GameObject canvas;

    Vector3 scaleBoundry;

    SpriteRenderer rendererS;

    public float time = 0f;
    float waitTime;

    [Header("Pop-Ups")]
    public GameObject[] popUps;

    Vector2 randomPos;

    public Camera cam;

    public bool timerActive;

    public GameObject mainMenu;

    void Update()
    {
        TimeCheck();
        SpawnAd();
        LiveTimer();
        CheckActiveScreen();

    }

    void TimeCheck()
    {

        if (currentTime <= 40 * 2)
        {
            waitTime = 4 * 2;

            popUpAmount = 1;
        }
        if (currentTime > 40 * 2 && currentTime <= 100 * 2)
        {
            waitTime = 3 * 2;

            popUpAmount = 2;
        }
        if (currentTime > 100 * 2 && currentTime <= 300 * 2)
        {
            waitTime = 2 * 2;

            popUpAmount = 3;
        }
        if (currentTime > 300 * 2 && currentTime <= 500 * 2)
        {
            waitTime = 2 * 2;

            popUpAmount = 5;
        }
        if (currentTime > 500 * 2)
        {
            waitTime = 1 * 2;

            popUpAmount = 4;
        }
    }

    void SpawnAd()
    {
        time += Time.deltaTime;

        if (time >= waitTime)
        {
            time = 0f;

            for (int i = 0; i < popUpAmount; i++)
            {
                spawnPopUp = popUps[UnityEngine.Random.Range(0, popUps.Length)];
                GetBoundryLocation();
                Spawner(RandomSpawnLocation());
            }
        }

    }

    void LiveTimer()
    {
            currentTime = currentTime + Time.deltaTime / 2;

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            if (currentTime < 10)
            {
                currentTimeText.text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
            }
            else
            {
                currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
            }
    }

    void CheckActiveScreen()
    {
        if (mainMenu.activeInHierarchy == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 2f;
        }
    }

    void GetBoundryLocation()
    {
        rendererS = spawnPopUp.GetComponent<SpriteRenderer>();

        scaleBoundry.x = rendererS.bounds.size.x / 2;
        scaleBoundry.y = rendererS.bounds.size.y / 2;
    }

    private Vector3 RandomSpawnLocation()
    {
        randomPos.x = UnityEngine.Random.Range(scaleBoundry.x, Screen.width - scaleBoundry.x);
        randomPos.y = UnityEngine.Random.Range(scaleBoundry.y, Screen.height - scaleBoundry.y);

       Vector3 posInworld = cam.ScreenToWorldPoint(new Vector3(randomPos.x, randomPos.y, 81));

        return posInworld;
    }

    void Spawner(Vector3 posToSpawnAt)
    {
        activeAd = Instantiate(spawnPopUp, posToSpawnAt, Quaternion.identity);

        activeAd.transform.parent = canvas.transform;
    }
}
