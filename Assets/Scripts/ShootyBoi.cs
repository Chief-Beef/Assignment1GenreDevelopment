using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyBoi : MonoBehaviour
{


    public GameObject gun1;
    public GameObject gun2;
    public GameObject bullet;
    public KeyCode space;
    public KeyCode left;
    public KeyCode right;
    public float timer = .5f;
    public bool turning;
    public Rigidbody rbody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKey(right))
        {
            turning = true;
        }

        if (Input.GetKey(left))
        {
            turning = false;
        }


        if (Input.GetKeyDown(space) && timer <= 0 && turning == true)
        {
            Instantiate(bullet, new Vector3(this.transform.position.x+2, this.transform.position.y+1, this.transform.position.z), gun1.transform.rotation);
            rbody.velocity = new Vector3(-15, 0, 0);

            if (timer <= 0)
            {
                timer = .25f;
            }
        }

        if (Input.GetKeyDown(space) && timer <= 0 && turning == false)
        {
            Instantiate(bullet, new Vector3(this.transform.position.x - 2, this.transform.position.y + 1, this.transform.position.z), gun2.transform.rotation);
            rbody.velocity = new Vector3(-15, 0, 0);

            if (timer <= 0)
            {
                timer = .25f;
            }
        }
    }
}
