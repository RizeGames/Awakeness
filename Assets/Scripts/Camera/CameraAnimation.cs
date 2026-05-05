using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    public void SetCameraTrigger() 
    {
        anim.SetTrigger("Shake");
    }

    public void SetLongCameraShakeTrue() 
    {
        anim.SetBool("LongShake", true);
    }

    public void SetLongCameraShakeFalse() 
    {
        anim.SetBool("LongShake", false);
    }
}
