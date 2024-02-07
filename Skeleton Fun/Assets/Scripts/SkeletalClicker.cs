using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SkeletalClicker : MonoBehaviour
{
    public float gravityPull;
    public float pullForce;

    RaycastHit hit;

    Interactions action;
    int randomI;
    float randomF;
    public Transform skeletonRotate;
    float rotateDirection;
    public AudioSource source;
    public AudioClip clip;
    bool clickCheck;

    public GameObject scripts;
    Death death;

    private void Start()
    {
        death = scripts.GetComponent<Death>();
        rotateDirection = 50 * Time.deltaTime;
    }

    private void Awake()
    {
        action = new Interactions();

        action.Click.LeftClick.performed += x => Click();
    }

    void Update()
    {
        if (clickCheck)
        {
            StartCoroutine(ClickCooldown(randomF));
        }

        if (!death.dead)
        {
            if(Time.timeScale  > 0)
            {
                skeletonRotate.Rotate(0, 0, rotateDirection, Space.Self);
                gravityPull += pullForce * Time.deltaTime;
                transform.Translate(Vector3.down * gravityPull);
            }
        }

    }

    private void OnMouseDown()
    {

        if (!clickCheck)
        {
            gravityPull = -1.5f;

            randomI = Random.Range(1, 3);
            randomF = Random.Range(2f, 3f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000))
            {
                if (hit.transform.tag == "Player")
                {

                    if (randomI == 1)
                    {
                        Debug.Log("right");
                        hit.rigidbody.velocity = new Vector3(30, 0, 0);
                        rotateDirection = -50 * Time.deltaTime;
                    }
                    else
                    {
                        Debug.Log("left");
                        hit.rigidbody.velocity = new Vector3(-30, 0, 0);
                        rotateDirection = 50 * Time.deltaTime;
                    }

                    clickCheck = true;
                }
            }
        }
    }

    public void Click()
    {
        source.clip = clip;
        source.Play();
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

}
