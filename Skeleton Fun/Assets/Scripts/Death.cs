using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject scripts;
    PopUps popUps;
    float timeScore;
    public bool dead;
    void Start()
    {
        popUps = scripts.GetComponent<PopUps>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("hit");

        if(collision.gameObject.tag == "Death")
        {
            Time.timeScale = 0f;

            dead = true;

            timeScore = popUps.time;
        }
    }
}
