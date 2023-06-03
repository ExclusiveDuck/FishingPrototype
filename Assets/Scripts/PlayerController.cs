using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] private float speed;

    private bool isGrounded;
    private float gravityValue = 9.81f;
    private float radius = 0.4f;
    public Transform groundCheck;
    public LayerMask ground;
    Vector3 velocity;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, ground);

        if (isGrounded && velocity.y <   0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y -= gravityValue * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

}
