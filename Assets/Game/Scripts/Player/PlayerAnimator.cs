using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayIdleAnimation()
    {
        _animator.Play("idle");
    }

    public void PlayWalkAnimation() 
    {
        _animator.Play("walk");
    }
}
