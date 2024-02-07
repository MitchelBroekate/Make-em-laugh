using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject scripts;
    PopUps popUps;
    public GameObject scriptDeath;
    Death death;

    public Transform skelStartPos;
    public GameObject skel;

    public GameObject ads;

    private void Start()
    {
        popUps = scripts.GetComponent<PopUps>();
        death = scriptDeath.GetComponent<Death>();
    }
    public void ResetStuff()
    {
        Time.timeScale = 0;
        death.dead = false;
        popUps.currentTime = 0;
        skel.GetComponent<Rigidbody>().velocity = Vector3.zero;
        skel.GetComponent<Rigidbody>().isKinematic = true;
        skel.transform.position = skelStartPos.position;

        for (int i = 0; i < ads.transform.childCount; i++)
        {
            Destroy(ads.transform.GetChild(i).gameObject);
        }
    }

    public void ResetStuffD()
    {
        Time.timeScale = 2;
        death.dead = false;
        popUps.currentTime = 0;
        skel.GetComponent<Rigidbody>().velocity = Vector3.zero;
        skel.GetComponent<Rigidbody>().isKinematic = true;
        skel.transform.position = skelStartPos.position;

        for (int i = 0; i < ads.transform.childCount; i++)
        {
            Destroy(ads.transform.GetChild(i).gameObject);
        }
    }
}
