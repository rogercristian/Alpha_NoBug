using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationState : MonoBehaviour
{
    private string currentState;
    private void Awake()
    {
        GameEvents.Instance.OnAnimationChange += HandlerOnAnimationChange;
    }
    private void OnDestroy()
    {
        GameEvents.Instance.OnAnimationChange -= HandlerOnAnimationChange;
    }
    private void HandlerOnAnimationChange(string newState)
    {
        Animator animator = GetComponent<Animator>();
        if(currentState == newState) { return; }
       // animator.Rebind();
        animator.Play(newState, -1, .1f);
        currentState = newState;
       
    }
}
