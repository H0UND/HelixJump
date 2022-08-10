using UnityEngine;

public class Control : MonoBehaviour
{
    public float _sensitivity;

    public Transform Level;

    public Vector3 _previousMousePosition;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - _previousMousePosition;
            Level.Rotate(0, -delta.x * _sensitivity, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}