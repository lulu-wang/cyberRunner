using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiBgController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimateAppear()
    {
        animator.SetBool("showText", true);
    }
}
