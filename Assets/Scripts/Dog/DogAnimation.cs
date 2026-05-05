using UnityEngine;

public class DogAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private DogZone dogZone;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
        dogZone.OnPlayerEnterZone += SetIsInsideTrigger;
    }

    private void SetIsInsideTrigger() 
    {
        anim.SetTrigger("isInside");
    }
}
