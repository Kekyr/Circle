using UnityEngine;

public class Movement : MonoBehaviour, IMovement
{
    [SerializeField] private float _force;
    
    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _force * Time.fixedDeltaTime);
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
