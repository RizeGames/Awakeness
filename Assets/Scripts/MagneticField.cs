using UnityEngine;


public class MagneticField : MonoBehaviour
{
    [SerializeField] private GameObject woodenStuff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == woodenStuff) 
        {
            Destroy(gameObject);
        }
    }
}
