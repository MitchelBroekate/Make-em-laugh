using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorRandomise : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Image>().color = new Vector4(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 255);
    }
}
