using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerm1 : MonoBehaviour
{
    public CharacterController controller;

    private float speed;
    public float gravity = -29.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    bool isGrounded;

    public float crouchSpeed;
    public float crouchYScale;
    public float startYScale;


    public Rigidbody rb;

    public float health = 90;


    private bool dead = false;

    public AudioSource source;

    public int counter;

    private bool finished;

    public GameObject door;

    private void Start()
    {
        startYScale = transform.localScale.y;
        rb = GetComponent<Rigidbody>();
    }
    //Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 40f;
        }
        else
        {
            speed = 20f;
        }
        //kucnij
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); /*potrzeba si³y która dociœnie gracza do ziemi po zmianie skali*/
            speed = crouchSpeed;
        }
        //przestan kucac
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }

        if (health <= 0)
        {
            dead = true;
            Destroy(gameObject);
        }

        if (dead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(counter>=4)
        {
            finished = true;
        }
        if(finished == true)
        {
            //pomysl - zastapic niszczenie rotacja
            Destroy(door);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        //delta y = 1/2g * t2
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            rb.AddTorque(100 * -transform.forward);
            rb.constraints = RigidbodyConstraints.None;
            source.Play();
            StartCoroutine(Order());
        }
        if (other.gameObject.tag == "Key")
        {
            counter++;
        }
        if(other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Credits");
        }
    }
    IEnumerator Order()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("SampleScene");
    }
}