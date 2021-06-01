using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float initialForce;
    [SerializeField] float startXPosition;
    [SerializeField] float maxYPosition;

    Rigidbody2D thisRigidbody;
    Transform thisTransform;

    private void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        thisTransform = transform;
    }

    private void OnEnable()
    {
        float direction = (Random.Range(0.0f, 1.0f) < 0.5f ? -1.0f : 1.0f);
        SetStartPosition(direction);
        SetRotation(direction);
        SetInMotion(direction);
    }

    private void Update()
    {
        float currentX = thisTransform.position.x;
        if (currentX > startXPosition || currentX < -startXPosition)
            gameObject.SetActive(false);
    }

    void SetStartPosition(float direction)
    {
        Vector2 initialPosition = new Vector2();
        initialPosition.x = direction > 0 ? -startXPosition : startXPosition;
        initialPosition.y = Random.Range(-maxYPosition, maxYPosition);
        thisTransform.position = initialPosition;
    }

    void SetInMotion(float direction)
    {
        thisRigidbody.AddForce(Vector2.right * direction * initialForce, ForceMode2D.Impulse);
    }

    void SetRotation(float direction)
    {
        float magnitude = direction > 0 ? 0 : 180;
        thisTransform.eulerAngles = Vector3.up * magnitude;

    }
}
