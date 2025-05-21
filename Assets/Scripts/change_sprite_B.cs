using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_sprite_B : MonoBehaviour
{
    public GameObject railing_B;
    public GameObject r_railing_C2, l_railing_C2, Light;

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
        railing_B.SetActive(false);
        r_railing_C2.SetActive(true);
        l_railing_C2.SetActive(true);
        Light.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        railing_B.SetActive(true);
        
        r_railing_C2.SetActive(false);
        l_railing_C2.SetActive(false);
        //Light.SetActive(true);
    }
}
