using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayIdleAnimation()
    {
        animator.Play("idle");
    }

    public void PlayWalkAnimation() 
    {
        animator.Play("walk");
    }
}
