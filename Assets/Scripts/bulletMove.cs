using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public KeyCode right;
    public KeyCode left;
    public KeyCode space;
    public Rigidbody rbody; 
    public float timer = 5.0f;
    public bool turning;
    public bool finalTurn;


    private void Start()
    {
        /*if (Input.GetKey(right))
        {
            turning = true;
        }
        else if (Input.GetKey(left))
        {
            turning = false;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
       


        if(turning == true)
        {
            rbody.velocity = new Vector3(15, 0, 0);
        }
        
        if(turning == false)
        {
            rbody.velocity = new Vector3(-15, 0, 0);
        }

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "platform")
        {
            timer = 0;
        }    
    }
}
