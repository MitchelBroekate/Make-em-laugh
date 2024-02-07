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
    public float clickPower = 1;

    public GameObject scripts;
    Death death;

    public AudioClip clipA;

    bool audioDoot;

    public GameObject dootTXT;

    public Coroutine clicking;
    public Coroutine dootDoot;
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


        float grav = 1;
        if (clickCheck)
        {
            clicking = StartCoroutine(ClickCo(randomF));
        }

        if (!death.dead)
        {
            if(Time.timeScale  > 0)
            {
                skeletonRotate.Rotate(0, 0, rotateDirection, Space.Self);
                GetComponent<Rigidbody>().AddForce(Vector3.down * grav);
            }
        }

        DootCheck();
    }

    private void OnMouseDown()
    {

        if (!clickCheck)
        {
            randomI = Random.Range(1, 3);
            randomF = Random.Range(2f, 2.4f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000))
            {
                if (hit.transform.tag == "Player")
                {
                    audioDoot = true;
                    source.clip = clipA;
                    source.Play();
                    dootTXT.SetActive(true);

                    GetComponent<Rigidbody>().AddForce(Vector3.up * clickPower);
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
                    audioDoot = false;
                }
            }
        }
    }

    public void Click()
    {
        if (audioDoot)
        {
            source.clip = clip;
            source.Play();
        }

    }

    void DootCheck()
    {
        if(dootTXT.activeInHierarchy == true)
        {
            dootDoot = StartCoroutine(DootCo(1));
        }
    }

    IEnumerator ClickCo(float time)
    {
        yield return new WaitForSeconds(time);

        clickCheck = false;
        StopCoroutine(clicking);
    }

    IEnumerator DootCo(float dootTime)
    {
        yield return new WaitForSeconds(dootTime);

        dootTXT.SetActive(false);
    }


    private void OnEnable()
    {
        action.Enable();
    }

}
