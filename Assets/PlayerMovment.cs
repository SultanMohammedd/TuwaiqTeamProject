using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float hor = Input.GetAxis("Horizontal") *playerSpeed;
        float ver = Input.GetAxis("Vertical") * playerSpeed;
        rb.linearVelocity = new Vector3(hor, rb.linearVelocity.y, ver);
        if (transform.position.y < 1.1) {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            } 
        }
        //if (Input.GetKey(KeyCode.W))
        //{

        //    //transform.position += new Vector3(0, 0, playerSpeed);
        //    rb.linearVelocity += new Vector3(0, 0, playerSpeed);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += new Vector3(0, 0, - playerSpeed);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += new Vector3(- playerSpeed, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(playerSpeed, 0, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{


        //    Rigidbody body = GetComponent<Rigidbody>();
        //    body.AddForce(Vector3.up * jumpForce, ForceMode.Force);
        //}
    }
}
