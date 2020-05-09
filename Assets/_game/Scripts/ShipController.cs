using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Animator anim;
    public float MaxTime;


    private float timeToHover;

    void Start()
    {
        anim = GetComponent<Animator>();
        timeToHover = Random.Range(1, MaxTime);
        StartCoroutine(WaitForHover());
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        anim.SetTrigger("DoTheThing");
    //}

    IEnumerator WaitForHover()
    {
        yield return new WaitForSeconds(timeToHover);

        anim.SetTrigger("DoTheThing");
        timeToHover = Random.Range(1, MaxTime);
        StartCoroutine(WaitForHover());
    }

    public void SetLeft(int _status)
    {
        print(_status == 0);
        anim.SetBool("Left", _status == 0 ? true : false);
    }
}
