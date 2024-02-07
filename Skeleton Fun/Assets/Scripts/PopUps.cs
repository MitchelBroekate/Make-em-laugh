using System;
using UnityEngine;
using TMPro;
using System.Collections;

public class PopUps : MonoBehaviour
{
    public float currentTime;

    public TMP_Text currentTimeText;

    int popUpAmount;

    GameObject spawnPopUp;
    GameObject activeAd;
    public GameObject canvas;

    Vector3 scaleBoundry;

    RectTransform recT;

    public float time = 0f;
    float waitTime;

    [Header("Pop-Ups")]
    public GameObject[] popUps;

    Vector2 randomPos;

    public Camera cam;

    public bool timerActive;

    public GameObject mainMenu;

    public GameObject confetti;
    public ParticleSystem pS;

    public GameObject scripts;
    Death death;

    private void Start()
    {
        death = scripts.GetComponent<Death>();

        pS.Stop();
    }

    void Update()
    {
        TimeCheck();
        SpawnAd();
        LiveTimer();
        CheckActiveScreen();
        ConfettiPop();
    }

    void TimeCheck()
    {

        if (currentTime <= 40)
        {
            waitTime = 4 * 2;

            popUpAmount = 1;
        }
        if (currentTime > 40 && currentTime <= 100)
        {
            waitTime = 3 * 2;

            popUpAmount = 2;
        }
        if (currentTime > 100 && currentTime <= 300)
        {
            waitTime = 2 * 2;

            popUpAmount = 3;
        }
        if (currentTime > 300 && currentTime <= 500)
        {
            waitTime = 2 * 2;

            popUpAmount = 5;
        }
        if (currentTime > 500)
        {
            waitTime = 1 * 2;

            popUpAmount = 4;
        }
    }

    void ConfettiPop()
    {
        if (currentTime == 40)
        {
            StartCoroutine(ConfettiTimer());
        }
        if (currentTime == 100)
        {
            StartCoroutine(ConfettiTimer());
        }
        if (currentTime == 300)
        {
            StartCoroutine(ConfettiTimer());
        }
        if (currentTime > 499)
        {
            pS.Play();
        }
    }

    void SpawnAd()
    {
        time += Time.deltaTime;

        if (time >= waitTime)
        {
            for (int i = 0; i < popUpAmount; i++)
            {
                spawnPopUp = popUps[UnityEngine.Random.Range(0, popUps.Length)];
                GetBoundryLocation();
                Spawner(RandomSpawnLocation());
            }

            time = 0f;
        }

    }

    void LiveTimer()
    {
            currentTime = currentTime + Time.deltaTime / 2;

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

    }

    void CheckActiveScreen()
    {
        if (!death.dead)
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

    }

    void GetBoundryLocation()
    {
        recT = spawnPopUp.GetComponent<RectTransform>();

        scaleBoundry.x = recT.rect.width / 3;
        scaleBoundry.y = recT.rect.height / 3;
    }

    private Vector3 RandomSpawnLocation()
    {
        randomPos.x = UnityEngine.Random.Range(scaleBoundry.x, Screen.width - scaleBoundry.x);
        randomPos.y = UnityEngine.Random.Range(scaleBoundry.y, Screen.height - scaleBoundry.y);

       Vector3 posInworld = cam.ScreenToWorldPoint(new Vector3(randomPos.x, randomPos.y, 376));

        return posInworld;
    }

    void Spawner(Vector3 posToSpawnAt)
    {
        activeAd = Instantiate(spawnPopUp, posToSpawnAt, Quaternion.identity);

        activeAd.transform.SetParent(canvas.transform);
    }

    IEnumerator ConfettiTimer()
    {
        pS.Play();
        yield return new WaitForSeconds(4);
        pS.Stop();
        StopAllCoroutines();
    }
}
