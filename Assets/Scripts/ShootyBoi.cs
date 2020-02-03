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
    public float xSpeed;
    public float ySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x);
       

        if (Input.GetKeyDown(space) && timer <= 0 && Mathf.Abs(Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg) <= 90)
        {
            Instantiate(bullet, new Vector3(this.transform.position.x+2, this.transform.position.y+1, this.transform.position.z), gun1.transform.rotation);
           
            if (timer <= 0)
            {
                timer = .25f;
            }
        }
        else if (Input.GetKeyDown(space) && timer <= 0 && Mathf.Abs(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) >= 90)
        {
            Instantiate(bullet, new Vector3(this.transform.position.x - 2, this.transform.position.y + 1, this.transform.position.z), gun1.transform.rotation);

            if (timer <= 0)
            {
                timer = .25f;
            }
        }
    }
}
