using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SkeletalClicker : MonoBehaviour
{
    public float gravityPull = 0;
    public float pullForce = 1;

    RaycastHit hit;

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

    void Update()
    {
        gravityPull += pullForce * Time.deltaTime;
        transform.Translate(Vector3.down * gravityPull);

        if (clickCheck)
        {
            StartCoroutine(ClickCooldown(randomF));
        }

        if (!death.dead)
        {
            skeletonRotate.Rotate(0, 0, rotateDirection, Space.Self);
        }

    }

    private void OnMouseUp()
    {

        source.clip = clip;
        source.Play();

        if (!clickCheck)
        {
            gravityPull = -1;

            randomI = Random.Range(1, 3);
            randomF = Random.Range(1f, 2f);
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

    IEnumerator ClickCooldown(float time)
    {
        yield return new WaitForSeconds(time);

        clickCheck = false;
        StopAllCoroutines();
    }

}
