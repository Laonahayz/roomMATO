using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetector : MonoBehaviour
{
    public GameObject player;
    public Text X;
    public Text Y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        X.text = player.GetComponent<Transform>().position.x.ToString();
        Y.text = player.GetComponent<Transform>().position.y.ToString();
    }
}
