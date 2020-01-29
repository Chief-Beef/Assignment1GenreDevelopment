using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty2 : MonoBehaviour
{

    public Rigidbody rbody;
    public float bulletVelocity = 30;
    public float timer = 4.0f;
    public float rotateX, rotateY, rotateZ;
    public bool testBool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;

        
        rotateY = eulerAngles.y;
        

       
        if (rotateY == 90)
        {
            rbody.velocity = new Vector3(bulletVelocity,0,0);
            //rbody.AddForce(-bulletVelocity, 0, 0, ForceMode.VelocityChange);

            testBool = true;
        }
        else //if (rotate == -90)
        {
            rbody.velocity = new Vector3(-bulletVelocity,0,0);
            //rbody.AddForce(-bulletVelocity, 0, 0, ForceMode.VelocityChange);
            testBool = false;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "platform" || col.gameObject.tag == "wall")
        {
            timer = 0;
        }
    }
}
   
