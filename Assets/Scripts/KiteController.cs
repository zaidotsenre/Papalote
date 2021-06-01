using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KiteController : MonoBehaviour
{
    Rigidbody2D kiteRigidbody;

    private void Start()
    {
        kiteRigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        kiteRigidbody.AddForce(Vector2.right * xInput);
        kiteRigidbody.AddForce(Vector2.up * yInput);
    }

    private void OnDisable()
    {
        SceneManager.LoadScene("Post Game");
    }
}
