using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    public Vector3 CalculateDirection(Vector3 destination)
    {
        return (destination - transform.position).normalized;
    }
}
