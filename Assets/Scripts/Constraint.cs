using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour
{
    [SerializeField] float topBoundary;
    [SerializeField] float bottomBoundary;
    [SerializeField] float leftBoundary;
    [SerializeField] float rightBoundary;

    Transform thisTransform;

    private void Start()
    {
        thisTransform = transform;
    }

    private void LateUpdate()
    {
        Vector2 clampedPosition = thisTransform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftBoundary, rightBoundary);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomBoundary, topBoundary);
        thisTransform.position = clampedPosition;
    }

    public void TurnOff()
    {
        enabled = false;
    }
}
