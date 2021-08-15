using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    private Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator animator;
    private float sinceLastBlink = 0;
    public float blinkInterval;
    public NavMeshAgent navAgent;
    [SerializeField] Transform target;
    // Update is called once per frame
    private void Start()
    {
        navAgent.updateUpAxis = false;
        navAgent.updateRotation = false;
    }

    void Update()
    {
        navAgent.SetDestination(target.position);
        
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        animator.SetFloat("moveSpeed", movementInput.magnitude);
        sinceLastBlink += Time.deltaTime;
        if (movementInput.magnitude == 0 && sinceLastBlink > blinkInterval)
        {
            animator.SetTrigger("blink");
            sinceLastBlink = 0;
        }
        else
        {
            if (transform.localScale.x != (movementInput.x > .01f ? -1f : 1f))
                transform.localScale = new Vector3(movementInput.x > .01f ? -1f : 1f, 1, 1);
        }

        Debug.Log(navAgent.desiredVelocity);

    }

    void FixedUpdate()
    {
        //rigidBody.MovePosition(rigidBody.position + (walkSpeed * movementInput * Time.fixedDeltaTime));

        //Debug.Log(rigidBody.velocity);
    }
}
