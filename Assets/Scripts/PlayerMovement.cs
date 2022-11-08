﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    public bool enableMovement = true;
    public bool dead = false;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] AudioSource jumpSound;

    private enum MovementState { idle, running, jump, fall }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (enableMovement == true)
            {
                enableMovement = false;
            }
            else if (enableMovement == false)
            {
                enableMovement = true;
            }
        }

        if (enableMovement == true && dead == false)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded() && enableMovement==true && dead == false)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            jumpSound.Play();
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
