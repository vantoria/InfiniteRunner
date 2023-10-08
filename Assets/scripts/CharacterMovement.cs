using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed = 1f;
    public float runSpeed = 5;
    public float runDuration = 1;
    public GameObject uiManager;
    float speed = 0f;

    private CharacterController characterController;
    private float runTimer = 0f;
    private bool isRunning = false;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = 1.0f;

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection.z > 0){
            runTimer += Time.deltaTime;
            if (runTimer >= runDuration){
                isRunning = true;
            }
        }
        else{
            runTimer = 0f;
            isRunning = false;
        }

        if (isRunning == true){
            speed = runSpeed;
        }
        else{
            speed = walkSpeed;
        }
        
        Vector3 movement = transform.TransformDirection(moveDirection) * speed * Time.deltaTime;
        characterController.Move(movement);
        
        bool isWalking = moveDirection != Vector3.zero;
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy")){
            Debug.Log("gameover");
            UIManager uiGameOver;
            uiGameOver = uiManager.GetComponentInChildren<UIManager>();
            uiGameOver.GameOver();
        }
    }
}
