using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorRandom : MonoBehaviour
{
    public Vector4 c;
    private void Start()
    {
        c = new Vector4(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 255);
        c.Normalize();
        GetComponent<Image>().color = c;
    }
}
