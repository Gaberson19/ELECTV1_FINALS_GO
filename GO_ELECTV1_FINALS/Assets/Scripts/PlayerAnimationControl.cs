using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("isMovingRight", true);
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("isMovingLeft", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isMovingLeft", false);
            anim.SetBool("isMovingRight", false);
        }
    }
}
