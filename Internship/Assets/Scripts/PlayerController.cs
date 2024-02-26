using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float horizontalMultiplier;

    public float leftLimit = -5f; 
    public float rightLimit = 5f;

    [SerializeField] private LayerMask groundMask;

    private bool onGround = true;
    private bool crouchBlock = false;

    private Rigidbody rb;

    private float horizontalInput;
    private float crouchDelay = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S) && !crouchBlock)
        {
            Crouch();
        }
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * horizontalMultiplier * Time.fixedDeltaTime;

        if ((horizontalMove.x < 0 && transform.position.x > leftLimit) ||
            (horizontalMove.x > 0 && transform.position.x < rightLimit))
        {
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
        else
        {
            rb.MovePosition(rb.position + forwardMove);
        }
    }

    private void Jump()
    {   
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        onGround = false;
    }

    private void Crouch()
    {
        StartCoroutine(ScaleObject());
    }

    IEnumerator ScaleObject()
    {
        crouchBlock = true;

        float t = 0f;
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = new Vector3(originalScale.x, originalScale.y/2, originalScale.z);

        while (t < 1)
        {
            t += Time.deltaTime * crouchSpeed;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        yield return new WaitForSeconds(crouchDelay);

        t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * crouchSpeed;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        crouchBlock = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Death");
            GameMenu.instance.GameOver();
        }
    }
}
