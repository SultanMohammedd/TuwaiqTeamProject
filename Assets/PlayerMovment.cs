using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    public Rigidbody rb;
    public Collider Collider;
    public bool jumpAllowed;
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
       
    }
    public void OnTriggerEnter(Collider other)
    {
        
            jumpAllowed = true;
        
    }
    public void OnTriggerExit(Collider other)
    {
        
            jumpAllowed = false;
        
    }

}
