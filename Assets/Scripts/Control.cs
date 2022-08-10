using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity;
    [SerializeField]
    private Transform Level;
    private Vector3 _previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - _previousMousePosition;
            Level.Rotate(0, -delta.x * _sensitivity, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
