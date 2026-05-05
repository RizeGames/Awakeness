using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetRunAnimation(float number)
    {
        anim.SetFloat("Run", number , 0.1f , Time.deltaTime);
    }

    public void SetHurtLayerActive(bool active)
    {
        anim.SetLayerWeight(0, active ? 0f : 1f);
        anim.SetLayerWeight(1, active ? 1f : 0f);
    }

    public void SetCrouchLayerActive(bool active)
    {
        anim.SetLayerWeight(0, active ? 0f : 1f);
        anim.SetLayerWeight(2, active ? 1f : 0f);
    }

    public Animator GetAnimator()
    {
        return anim;
    }
}
