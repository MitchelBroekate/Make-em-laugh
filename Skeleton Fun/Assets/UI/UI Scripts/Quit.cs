using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
// a