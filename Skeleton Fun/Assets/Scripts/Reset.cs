using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    GameObject scripts;
    SkeletalClicker SkeletalClicker;

    private void Start()
    {
        SkeletalClicker = scripts.GetComponent<SkeletalClicker>();
    }
    public void ResetStuff()
    {

    }
}
