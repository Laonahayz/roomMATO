using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outbed : MonoBehaviour
{

    public GameObject role;
    public GameObject bed;
    public bool onbed = true;
    void OnTriggerStay2D(Collider2D c)
    {
        if (onbed)
        {
            if (c.tag == "bed_left")
            {
                role.transform.localPosition = new Vector3(-0.97f, -0.46f, 0f);
                onbed = false;
                bed.SetActive(true);
            }
            if (c.tag == "bed_down")
            {
                role.transform.localPosition = new Vector3(1.8f, -0.75f, 0f);
                onbed = false;
                bed.SetActive(true);
            }
        }
        /*else
        {
            if (c.tag == "bed")
            {
                bed.SetActive(false);
                role.transform.localPosition = new Vector3(0, 1.8f, 0f);
                onbed = true;                
            }
        }*/
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
