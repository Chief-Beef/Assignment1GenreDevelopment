using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{

    public GameObject goldKey;
    public GameObject ironKey;
    public bool key1 = false;
    public bool key2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (ironKey == null)
            key1 = true;

        if (goldKey == null)
            key2 = true;

        if (ironKey == null && goldKey == null)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        }
    }

}
