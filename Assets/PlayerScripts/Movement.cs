using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float extraGravity;
    [SerializeField] LayerMask ground;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private float groundCheckRadius;
    Vector3 direction;//Hareket y�n� i�in.
    Rigidbody rb;



    [Header("Mouse Look")]
    [SerializeField] private float sensivity;
    [SerializeField] Camera fpsCam;
    float mouseX, mouseY;
    float rotX, rotY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        GetMouseAxis();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Jump();
        }
        if (rb.linearVelocity.y < 0)
        {
            rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
        }
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }
    private void LateUpdate()
    {
        fpsCam.transform.localRotation = Quaternion.Euler(rotX, 0, 0);//Kameray� Hareket ettirmek i�in.
    }
    private void GetMouseAxis()
    {
        mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        rotX -= mouseY;//x ekseninde y ile d�n�yoz ya ondan yazd�m
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        rotY += mouseX;//Yapmazsak direk mouseX yazarsak hep +1/-1 alaca�� i�in ayn� yerde durur. 
        transform.localRotation = Quaternion.Euler(0, rotY, 0);
    }
    private void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        direction = new Vector3(hor, 0f, ver);
        //transform.TransformDirection ekledik ��nk� kendi local pozisyonunda ilerlemesi i�in.
        rb.MovePosition(transform.position + transform.TransformDirection(direction * Time.fixedDeltaTime * moveSpeed));

        
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpSpeed,ForceMode.Impulse);//Impulse tek seferlik kuvvet uygulamak i�in.
    }
    private bool isGrounded()
    {
        if ( Physics.CheckSphere(groundCheck.transform.position,groundCheckRadius,ground))
            return true;
       else 
            return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
    }
}
