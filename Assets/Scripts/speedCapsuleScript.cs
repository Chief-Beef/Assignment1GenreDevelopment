using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedCapsuleScript : MonoBehaviour
{

    public float timer;
    public float respawnTime = 10.0f;
    public bool active;
    public Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (active == false && timer <= 0)
        {
            active = true;
        }

        rend.enabled = active;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            active = false;
            timer = respawnTime;
        }
    }

}
