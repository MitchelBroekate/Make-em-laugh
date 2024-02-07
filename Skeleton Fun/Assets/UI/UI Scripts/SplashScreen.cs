using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//7 f

public class SplashScreen : MonoBehaviour
{
    public string sceneToLoad;
    public float timer = 7f;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
