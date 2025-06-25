using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float playerSpeed;
    public float playerHealth;
    public float jumpForce;
    public bool jumpAllowed;
    public Rigidbody rb;
    public Collider Collider;
    public GameObject PlayerCam;
    
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
        rb.linearVelocity = new Vector3(hor, rb.linearVelocity.y, ver);
        if (jumpAllowed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
        MoveCam();
       
    }
    float routCam = 0;
    void MoveCam()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX, 0));

        float mouseY = Input.GetAxis("Mouse Y");
        routCam -= mouseY;
        PlayerCam.transform.localRotation = Quaternion.Euler(routCam, 0,0);
    }
    public void OnTriggerEnter(Collider other)
    {
            jumpAllowed = true;
        if (other.CompareTag("Enemy"))
        {
            playerHealth -= 1;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        
            jumpAllowed = false;
        
    }

}
