using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float playerSpeed;
    public float playerHealth;
    public float jumpForce;
    public float mouseSense;
    public bool jumpAllowed;
    public Rigidbody rb;
    public Collider Collider;
    public Transform PlayerCam;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Enenmy;

    

    public float knockbackDirectionX;
    public float knockbackDirectionZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float hor = Input.GetAxis("Horizontal") * playerSpeed;
        float ver = Input.GetAxis("Vertical") * playerSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed = 15;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = 5;
        }

        Vector3 cameraForward = PlayerCam.forward; // Or Camera.main.transform.forward if using main camera
        cameraForward.y = 0; // Flatten the vector to the horizontal plane
        cameraForward.Normalize(); // Normalize to ensure a consistent magnitude of 1

        // Get the camera's right direction
        Vector3 cameraRight = PlayerCam.right; // Or Camera.main.transform.right
        cameraRight.y = 0; // Flatten the vector
        cameraRight.Normalize(); // Normalize

        Vector3 moveDirection = (cameraRight * hor) + (cameraForward * ver);
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        Vector3 finalHorizontalVelocity = moveDirection * playerSpeed;

        rb.linearVelocity = new Vector3(finalHorizontalVelocity.x, rb.linearVelocity.y, finalHorizontalVelocity.z);

        if (Input.GetKeyDown(KeyCode.Space) && jumpAllowed)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jumpAllowed = false;
        }

        MoveCam();

    }
    float routCam = 0;
    void MoveCam()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense;
        transform.Rotate(new Vector3(0, mouseX, 0));

        float mouseY = Input.GetAxis("Mouse Y") * mouseSense;
        routCam -= mouseY;
        float finalRoutCam = Math.Clamp(routCam, -20, 40);
        PlayerCam.transform.localRotation = Quaternion.Euler(finalRoutCam, 0, 0);
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHitBox"))
        {
            knockbackDirectionX = (transform.position.x - Enenmy.transform.position.x);
            knockbackDirectionZ = (transform.position.z - Enenmy.transform.position.z);
            playerHealth -= 1;
            rb.AddForce(knockbackDirectionX*100, 4, knockbackDirectionZ*100, ForceMode.Impulse);

            if (playerHealth == 2)
            {
                Heart3.SetActive(false);
            }
            if (playerHealth == 1)
            {
                Heart2.SetActive(false);
            }
            if (playerHealth == 0)
            {
                Heart1.SetActive(false);
            }

            if (playerHealth <= 0)
            {
                LosePanel.SetActive(true);
            }
        }
        if (other.CompareTag("Goal"))
        {
            WinPanel.SetActive(true);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumpAllowed = true;
        }

    }
    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            jumpAllowed = false;
        }
    }

}
