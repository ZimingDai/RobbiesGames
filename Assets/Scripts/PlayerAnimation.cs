using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement movement;
    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(movement.xVelocity));
        anim.SetBool("isOnGround", movement.isOnGround);
        anim.SetBool("isCrouching", movement.isCrouch);
        anim.SetBool("isJumping", movement.isJump);
        anim.SetBool("isHanging", movement.isHanging);
        anim.SetFloat("verticalVelocity", rb.velocity.y);
    }

    public void StepAudio()
    {
        AudioManager.PlayFootstepAudio();
    }

    public void CrouchStepAudio()
    {
        AudioManager.PlayCrouchFootstepAudio();   
    }
}
