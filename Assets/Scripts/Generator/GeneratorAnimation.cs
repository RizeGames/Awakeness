using UnityEngine;

public class GeneratorAnimation : MonoBehaviour
{
    private Animator anim;
    private Generator generator;


    private void OnEnable()
    {
        generator = GetComponent<Generator>();

        generator.OnTurnedOn += Generator_OnTurnedOn;
        generator.OnTurnedOff += Generator_OnTurnedOff;
        generator.OnBroken += Generator_OnBroken;
    }

    private void Generator_OnBroken()
    {
        SetState(false);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Generator_OnTurnedOff()
    {
        SetState(false);
    }

    private void Generator_OnTurnedOn()
    {
        SetState(true);
    }

    public void SetState(bool state) 
    {
        anim.SetBool("State", state);
    }

}
