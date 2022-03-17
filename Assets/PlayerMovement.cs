using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;

    public float runSpeed = 500f;
    public float strafeSpeed = 500f;
    public float jumpForce = 15f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;
    protected bool grounded = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gm.EndGame();

            Debug.Log("THE END");
        }

        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }

    }


    void Update()
    {
        if(Input.GetKey("a"))
        {
            strafeLeft = true;
        }else{
            strafeLeft = false;
        }
        
        if(Input.GetKey("d"))
        {
            strafeRight = true;
        }else{
            strafeRight = false;
        }

        if(Input.GetKeyDown("space"))
        {
            doJump = true;
        }

        if(transform.position.y < -5f)
        {
            gm.EndGame();

            Debug.Log("THE END");
        }

        
    }

    void FixedUpdate()
    {
        //rb.AddForce(0, 0, runSpeed * Time.deltaTime);
        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        if (strafeLeft)
        {
            //rb.MovePosition(transform.position + Vector3.left * strafeSpeed * Time.deltaTime);
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (strafeRight)
        {
            //rb.MovePosition(transform.position + Vector3.right * strafeSpeed * Time.deltaTime);
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (doJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doJump = false;
        }
    }
}
