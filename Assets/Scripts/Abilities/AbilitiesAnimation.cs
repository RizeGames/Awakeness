using UnityEngine;

public class AbilitiesAnimation : MonoBehaviour
{
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        AbilitiesSystem.Instance.OnAbilityGetsReady += SetGlowTrue;
        AbilitiesSystem.Instance.OnAbilityDoesNotGetReady += SetGlowFalse;
    }


    private void SetGlowTrue()
    {
        animator.SetBool("Glow", true);
    }

    private void SetGlowFalse()
    {
        animator.SetBool("Glow", false);
    }
}
