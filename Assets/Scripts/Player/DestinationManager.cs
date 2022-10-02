using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    private Vector3 _destination;
    
    public Vector3 CalculateDestination(Touch touch)
    {
        _destination = Camera.main.ScreenToWorldPoint(touch.position);
        _destination.z = 0;
        return _destination;
    }
}
