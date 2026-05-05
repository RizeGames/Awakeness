using System;
using UnityEngine;

public class SpeakerPoleDistance : MonoBehaviour
{
    
    private float distance;

    public float Distance
    {
        get { return distance; }
        private set { distance = value; }
    }

    public void CalculateDistance(Transform player)
    {
         distance = Vector3.Distance(transform.position, player.position);
    }
}
