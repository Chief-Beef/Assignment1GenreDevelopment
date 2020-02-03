using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty2 : MonoBehaviour
{

    public Rigidbody rbody;
    public float bulletVelocity = 30;
    public float timer = 4.0f;
    public float rotateX, rotateY, rotateZ;
    public float xSpeed, ySpeed;
    public bool testBool;

    // Start is called before the first frame update
    void Start()
    {

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x);
        //Debug.Log("dir.x: " + dir.x + "      dir.y" + dir.y + "      angle:" + angle +    "sin(theta): " + Mathf.Sin(angle) + "cos(theta): " + Mathf.Cos(angle));
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        xSpeed = Mathf.Cos(angle);
        ySpeed = Mathf.Sin(angle);

        Debug.Log("xSpeed: " + xSpeed + "   ySpeed" + ySpeed + "    bulletVelocity: " + bulletVelocity * xSpeed);

        rbody.velocity = new Vector3(bulletVelocity * xSpeed, bulletVelocity * ySpeed, 0);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = this.transform.eulerAngles;
        
        rotateY = eulerAngles.y;
        
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

            if (xSpeed > 0)
                this.gameObject.transform.position = new Vector3(this.transform.position.x - 2, this.transform.position.y, this.transform.position.z);
            else
                this.gameObject.transform.position = new Vector3(this.transform.position.x + 2, this.transform.position.y, this.transform.position.z);


            xSpeed = -xSpeed;
            rbody.velocity = new Vector3(bulletVelocity * xSpeed, bulletVelocity * ySpeed, 0);
        
            //timer = 0;
        }
    }
}
   
