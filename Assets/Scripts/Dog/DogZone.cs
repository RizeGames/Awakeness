using System;
using UnityEngine;

public class DogZone : MonoBehaviour
{

    public event Action OnPlayerEnterZone;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PlayerAnimation>(out PlayerAnimation playerAnimation))
        {
            if (playerAnimation.GetAnimator().GetLayerWeight(2) < 0.1f) 
            {
                // i will add the game lose condition here later
                OnPlayerEnterZone?.Invoke();
            }
            
        }
    }
}
