using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;

    public float walkSpeed = 1.0f;
    public float boostedSpeed = 2.0f;   // Speed during boost
    public float boostDuration = 1f;    // How long boost lasts

    public float cooldownDuration = 5f; // Cooldown length

    public InputAction BoostAction;     // Button for boosting

    public float turnSpeed = 20f;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    bool isBoosting = false;          // Tracks boost state
    bool isOnCooldown = false;        // Tracks cooldown state

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        MoveAction.Enable();

        BoostAction.Enable();           // Enable the boost button 

        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Only allow boost if not already boosting and not on cooldown
        if (BoostAction.triggered && !isBoosting && !isOnCooldown)
        {
            StartCoroutine(SpeedBoost());
        }
    }

    void FixedUpdate()
    {
        var pos = MoveAction.ReadValue<Vector2>();

        float horizontal = pos.x;
        float vertical = pos.y;

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        m_Rigidbody.MoveRotation(m_Rotation);

        // Movement uses boosted or normal speed
        float currentSpeed = isBoosting ? boostedSpeed : walkSpeed;

        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * currentSpeed * Time.deltaTime);
    }

    // Coroutine for boost
    IEnumerator SpeedBoost()
    {
        isBoosting = true;

        // start cooldown as soon as the boost begins
        StartCoroutine(CooldownTimer());

        yield return new WaitForSeconds(boostDuration);

        isBoosting = false;
    }

    // Cooldown coroutine 
    IEnumerator CooldownTimer()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        isOnCooldown = false;
    }
}
