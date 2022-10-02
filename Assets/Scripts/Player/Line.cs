using UnityEngine;

public class Line : MonoBehaviour, ILine
{
    private LineRenderer _lineRenderer;
    
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    
    public void Draw(Vector3 destination)
    {
        if (destination != Vector3.zero)
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, destination);
        }
    }

    public void Clear()
    {
        _lineRenderer.enabled = false;
    }

}
