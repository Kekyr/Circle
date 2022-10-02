using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private IMovement _movement;
    private ILine _line;
    private DirectionManager _directionManager;
    private DestinationManager _destinationManager;
    
    private List<Touch> _nextDestinations = new List<Touch>();
    private Vector3 _direction;
    private Vector3 _destination;
    private bool _isMoving;
    private Touch _touch;

    private void Start()
    {
        _movement = GetComponent<IMovement>();
        _line = GetComponent<ILine>();
        _directionManager = GetComponent<DirectionManager>();
        _destinationManager = GetComponent<DestinationManager>();
    }

    private void Update()
    {
        if (!GameManager.instance.isWin)
        {
            IsTouchesSaved();
            GetTouch();
            _line.Draw(_destination);
        }
        else
        {
            _line.Clear();
        }
    }
    
    private void IsTouchesSaved()
    {
        if (_nextDestinations.Count > 0 && !_isMoving)
        {
            UseSavedTouches();
            CalculateDirectionAndDestination();
        }
    }
    
    private void UseSavedTouches()
    {
        _touch = _nextDestinations[0];
        _nextDestinations.Remove(_touch);
    }
    
    
    private void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (!_isMoving)
            {
                CalculateDirectionAndDestination();
            }
            else
            {
                SaveTouch();
            }
        }
    }

    private void CalculateDirectionAndDestination()
    {
        _destination=_destinationManager.CalculateDestination(_touch);
        _direction=_directionManager.CalculateDirection(_destination);
        IsMoving();
    }

    private void IsMoving()
    {
        _isMoving = !_isMoving;
    }
    
    private void FixedUpdate()
    {
        if (!ComparePoints(transform.position, _destination, 0.1f))
        {
            _movement.Move(_direction);
        }
        else
        {
            _movement.Stop();
            _direction = Vector3.zero;
            IsMoving();
        }
    }
    
    private void SaveTouch()
    {
        if (_touch.phase == TouchPhase.Began)
        {
            _nextDestinations.Add(_touch);
        }
    }
    
    //Compare points
    private bool ComparePoints(Vector3 point1, Vector3 point2, float tolerance)
    {
        return Mathf.Abs(Vector3.Distance(point1, point2)) <= tolerance;
    }
}