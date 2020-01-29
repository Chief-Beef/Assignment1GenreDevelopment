using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyBoi : MonoBehaviour
{

    public float xMovement;
    public float speed = 10f;
    public const float origSpeed = 1.75f;
    public const float iAmSpeed = 3.5f;
    public float speedMultiplier = 1.75f;
    public float lookDirection = 0;
    public float jumpForce;
    public float extraGravity = 200;
    public float jumpPosition;
    public float lastHeight;
    public float currentHeight;
    public float speedTimer;

    public bool canJump = true;
    public bool fastFall;
    public bool turning = true;
    public bool hasGoldKey = false;
    public bool hasIronKey = false;

    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;
    public KeyCode space;
    public KeyCode shift;

    public Rigidbody rb;

    public GameObject[] myObjects = new GameObject[4];
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;


    // Start is called before the first frame update
    void Start()
    {
        /*myObjects[0] = obj1;
        myObjects[1] = obj2;
        myObjects[2] = obj3;
        myObjects[3] = obj4;*/
        lastHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedTimer > 0)
        {
            speedTimer -= Time.deltaTime;
        }
        else
        {
            speedMultiplier = origSpeed;
        }

        currentHeight = this.transform.position.y;
        xMovement = 0;

        if (Input.GetKey(shift))
        {
            speed *= speedMultiplier;
        }

        if (Input.GetKey(right))
        {
            xMovement += speed * Time.deltaTime;
            turning = true;
        }

        if(Input.GetKey(left))
        {
            xMovement -= speed * Time.deltaTime;
            turning = false;
        }


       
        if (Input.GetKeyDown(up) && canJump == true)
        {
            //rb.drag = 0;
            rb.velocity = new Vector3(0, 0, 0);

            //rb.velocity = new Vector3(0, 11, 0);
            rb.AddForce(Vector3.up * jumpForce);
            canJump = false;
            jumpPosition = this.transform.position.y;
        }
            
            

        if (((currentHeight < lastHeight) && canJump == false) || currentHeight == jumpPosition + 4)
        {
            fastFall = true;
            //rb.velocity = new Vector3(0,-10,0);
            //rb.drag = 0;
        }
        if (Input.GetKeyDown(down) && fastFall == true)
        {
            rb.AddForce(Vector3.down * extraGravity);
        }

        if(turning == true)
        {
            lookDirection = 0;
        }
        else
        {
            lookDirection = 180;
        }

        xMovement += this.transform.position.x;
        this.gameObject.transform.position = new Vector3(xMovement, this.transform.position.y, this.transform.position.z);

        //this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, lookDirection, this.transform.eulerAngles.z);

        if(turning == true)
        {
            obj1.SetActive(true);
            obj2.SetActive(true);
            obj3.SetActive(false);
            obj4.SetActive(false);
        }
        else
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(true);
            obj4.SetActive(true);
        }

        lastHeight = currentHeight;

        if(Input.GetKey(shift))
        {
            speed /= speedMultiplier;
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "wall")
        {
            canJump = true;
            fastFall = false;
            //rb.drag = 0;
        }

        if (col.gameObject.tag == "platform")
        {
            canJump = true;
            fastFall = false;
        }

        if (col.gameObject.tag == "speedCapsule")
        {
            //Destroy(col.gameObject);
            speedTimer = 10.0f;
            speedMultiplier = iAmSpeed;
        }

        if (col.gameObject.tag == "goldKey")
        {
            Destroy(col.gameObject);
            //hasGoldKey = true;
        }

        if (col.gameObject.tag == "ironKey")
        {
            Destroy(col.gameObject);
            //hasIronKey = true;
        }

        if (col.gameObject.tag == "cylinder")
        {
            this.enabled = false;
        }

    }


}
