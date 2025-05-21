using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [Header("MATO")]
    public GameObject Player;
    [Header("視角框")]
    public GameObject HINT_B;
    [Header("說明書")]
    public GameObject operation_IMG, Magic_IMG, Game_IMG, Empty;
    [Header("魔法陣特效")]
    public GameObject Magic_Light;
    [Header("問號icon")]
    public GameObject quesicon;

    public bool isentermagic = false;
    public bool WatchG = false;
    public bool isopeningIns1 = false;
    public bool isopenhint = false;
    public static bool isopenhintTEST = false;
    public static bool cansay = false;

    // Start is called before the first frame update
    void Start()
    {
        quesicon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (operation_IMG.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                operation_IMG.SetActive(false);
                Magic_Light.GetComponent<ParticleSystem>().Play();
                isopeningIns1 = true;
            }
            Player.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
        }

        if (isentermagic && isopeningIns1)
        {
            if (isopenhint == false)
            {

                Magic_Light.GetComponent<ParticleSystem>().Stop();
                Magic_IMG.SetActive(true);
                isopenhint = true;
                isopenhintTEST = true;
                cansay = true;
            }

        }
        if (Magic_IMG.activeInHierarchy == true)
        {
            Player.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Magic_IMG.SetActive(false);
            }
        }

        if(jumpout.OUO && HINT_B.activeInHierarchy==false && Empty.activeInHierarchy == false)
        {
            Game_IMG.SetActive(true);
            WatchG = true;
            StartCoroutine(OOO());
        }

        if (Game_IMG.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Player.SetActive(true);
                Game_IMG.SetActive(false);
                quesicon.SetActive(true);
                WatchG = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(magic());
    }

    IEnumerator magic()
    {
        isentermagic = true;
        yield return new WaitForSeconds(2);
        isentermagic = false;
    }
    IEnumerator OOO()
    {
        Empty.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Empty.SetActive(true);
    }
}
