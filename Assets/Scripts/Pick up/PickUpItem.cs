using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
  
    [SerializeField] private Sprite image;
    private PickUPAudioSource pickUPAudioSource;

    public event Action OnItemPickedUp;

    private void Awake()
    {
        pickUPAudioSource = GetComponent<PickUPAudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    GameInput.instance.OnInteractKeyPressed += PickUp;
        //}
    }

    private void PickUp()
    {
        OnItemPickedUp?.Invoke();
        UISystem.Instance.EnableItemImage();
        InventorySystem.instance.AddItem(image);
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.TryGetComponent<Player>(out _)) 
        //{
        //    if (!InventorySystem.instance.GetHasItem())
        //    {
        //        UISystem.Instance.EnablePickUpBox();
        //    }
        //    else 
        //    {
        //        UISystem.Instance.DisablePickUpBox();
        //        GameInput.instance.OnInteractKeyPressed -= PickUp;
        //        Destroy(gameObject , pickUPAudioSource.GetClipLenght());
        //    }
        //}
    }

    private void OnTriggerExit(Collider other)
    {
            GameInput.instance.OnInteractKeyPressed -= PickUp;
            UISystem.Instance.DisablePickUpBox();
    }

}
