using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour, IInteractable
{
    public Animator mAnimator;

    private float lastTime = 0f;

    public void OnInteract()
    {
        if (mAnimator != null && Time.time - lastTime > 1f)
        {
            lastTime = Time.time;

            if (!mAnimator.GetBool("Open"))
            {
                mAnimator.SetBool("Open", true);
                mAnimator.SetBool("Close", false);
                mAnimator.SetTrigger("OpenTrigger");
            }
            else if (!mAnimator.GetBool("Close"))
            {
                mAnimator.SetBool("Open", false);
                mAnimator.SetBool("Close", true);
                mAnimator.SetTrigger("CloseTrigger");
            }
        }
    }
}
