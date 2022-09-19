using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimationController : MonoBehaviour
{
    //private CMF.Controller controller;
    private CharacterMover mover;
    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        //controller = GetComponent<CMF.Controller>();
        mover = GetComponent<CharacterMover>();
        animator = GetComponentInChildren<Animator>();
    }


    private void LateUpdate()
    {
        //Vector3 velocity = controller.GetVelocity();
        //animator.SetFloat("Speed", velocity.magnitude);
        animator.SetFloat("Speed", mover.velocity);
    }
}
