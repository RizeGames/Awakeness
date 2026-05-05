using UnityEngine;

public class CurrentStatePushableObject : MonoBehaviour
{
    private bool isPushed = false;

    public bool IsPushed
    {
        get { return isPushed; }
        set { isPushed = value; }
    }
}
