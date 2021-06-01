using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int initialHealth;
    [SerializeField] int damagePerHit;
    [SerializeField] AudioClip deathAudio;
    [SerializeField] UnityEvent onDeath;

    public int CurrentHealth { get { return currentHealth; } }
    int currentHealth;

    Rigidbody2D thisRigidbody;
    AudioSource audioSource;

    private void OnEnable()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        Reset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHealth -= damagePerHit;
        if (currentHealth == 0)
            StartCoroutine("Die");
    }

    IEnumerator Die()
    {
        onDeath.Invoke();
        if(deathAudio)
            audioSource.PlayOneShot(deathAudio);
        thisRigidbody.gravityScale = 1;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    void Reset()
    {
        currentHealth = initialHealth;
        thisRigidbody.gravityScale = 0;
    }
}
