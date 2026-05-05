using UnityEngine;

public class FootStepDust : MonoBehaviour
{
    [SerializeField] private ParticleSystem footStepDustEffect;


    public void PlayFootStepDustEffect()
    {
        if (!footStepDustEffect.isPlaying)
        {
            footStepDustEffect.Play();
        }
    }

  
}
