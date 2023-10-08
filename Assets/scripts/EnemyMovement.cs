using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 5f;    
    public float runDuration = 1;
    private CharacterController characterController;
    private Animator animator;
    public float runningThreshold = 1f;

    private void Start() {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Vector3 initialDirectionToPlayer = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(initialDirectionToPlayer);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(directionToPlayer);
        // fix horizontal movement
        directionToPlayer.x = 0f;
        Vector3 movement = directionToPlayer * movementSpeed * Time.deltaTime;

        characterController.Move(movement);

        // animation
        float currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        bool isWalking = movement != Vector3.zero;
        bool isRunning = currentSpeed >= runningThreshold;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isWalking", isWalking);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object on the "Destroyer" layer.
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
        {
            // Destroy the enemy when it collides with the destroyer object.
            Destroy(gameObject);
        }
    }
}
