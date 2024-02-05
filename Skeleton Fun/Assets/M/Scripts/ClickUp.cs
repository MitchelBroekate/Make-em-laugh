using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class ClickUp : MonoBehaviour
{
    RaycastHit hit;
    public Interactions action;
    bool clickCheck;
    int randomI;
    float randomF;

   
    private void Awake()
    {
        action = new Interactions();

        action.Click.LeftClick.performed += x => Click();
    }

    private void Update()
    {
        if (clickCheck)
        {
            StartCoroutine(ClickCooldown(randomF));
        }


    }
    public void Click()
    {
        if (!clickCheck) 
        {

            randomI = Random.Range(1, 3);
            randomF = Random.Range(1f, 3f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000))
            {
                if (hit.transform.tag == "Player")
                {

                    if (randomI == 1)
                    {
                        Debug.Log("right");
                        hit.rigidbody.velocity = new Vector3(15, 15, 0);
                    }
                    else
                    {
                        Debug.Log("left");
                        hit.rigidbody.velocity = new Vector3(-15, 15, 0);
                    }

                    clickCheck = true;
                }
            }
        }
    }

    IEnumerator ClickCooldown(float time)
    {
        yield return new WaitForSeconds(time);

        clickCheck = false;
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
