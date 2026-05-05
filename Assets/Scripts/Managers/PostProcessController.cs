using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessController : MonoBehaviour
{

    public static PostProcessController Instance;

    [SerializeField] private Volume normalVolume;
    [SerializeField] private Volume darkVolume;

    private void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
    }


    public void EnableNormalVolume() 
    {
        normalVolume.weight = 1f;
    }

    public void DisableNormalVolume()
    {
        normalVolume.weight = 0f;
    }

    public void EnableDarkVolume()
    {
        darkVolume.weight = 1f;
    }

    public void DisableDarkVolume()
    {
        darkVolume.weight = 0f;
    }
}
