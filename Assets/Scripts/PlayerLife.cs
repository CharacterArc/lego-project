using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement pm;

    [SerializeField] AudioSource deathSound;

    private Vector2 respawnPoint;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        respawnPoint = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }

    private void Die()
    {
        anim.SetTrigger("death");
        pm.dead = true;
        deathSound.Play();
    }

    private void RestartLevel()
    {
        transform.position = respawnPoint;
        pm.dead = false;
    }
}
