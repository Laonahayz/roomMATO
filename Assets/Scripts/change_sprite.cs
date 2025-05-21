using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_sprite : MonoBehaviour
{

    public GameObject r_railing,l_railing;

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
        r_railing.SetActive(true);
        l_railing.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        r_railing.SetActive(false);
        l_railing.SetActive(false); 
    }
}
