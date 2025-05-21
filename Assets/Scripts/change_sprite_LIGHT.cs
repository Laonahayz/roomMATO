using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_sprite_LIGHT : MonoBehaviour
{

    public GameObject light, light2;
    public GameObject BG_A;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (BG_A.activeInHierarchy == true)
        {
            light.SetActive(true);
        }
        else
        {
            light2.SetActive(true);
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (BG_A.activeInHierarchy == true)
        {
            light.SetActive(false);
        }
        else
        {
            light2.SetActive(false);
        }
        
    }
}
