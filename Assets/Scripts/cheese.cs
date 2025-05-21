using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class cheese : MonoBehaviour
{
    [Header("魔法陣特效")]
    public GameObject Magic_Light;
    [Header("番茄")]
    public GameObject tomato;
    [Header("眼睛")]
    public GameObject eyes;
    [Header("玻璃罐放大")]
    public GameObject jar;
    public Image jarr;
    public Image cab;
    [Header("QTE樣子")]
    public Sprite[] qte;
    [Header("櫃子圖片")]
    public Sprite[] cabb;
    [Header("起司")]
    public GameObject cheeses;
    [Header("玻璃罐碰撞物件")]
    public GameObject jarcube;
    [Header("到數計時的物件")]
    public GameObject NumberObject;
    [Header("倒計時UI")]
    public Image NumberUI;
    [Header("提示視角2")]
    public bool hint2 = false;
    [Header("玻璃音效")]
    public AudioSource glass_effect;
    public AudioClip glass,glassMagicOP;

    public float Timer;
    float Number;
    bool hamAt = false;
    bool eyeAt = false;
    bool findeye = false;
    public int num = 0;
    public float fadetime = 0;
    bool organ = false;
    public bool isch = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Number = Timer;
        NumberObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeAt)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!findeye)
                {
                    Flowchart.BroadcastFungusMessage("獲得眼睛提示");
                    hint2 = true;
                    jumpout.CanChooseNum = 2;
                    glass_effect.PlayOneShot(glassMagicOP);
                    Magic_Light.GetComponent<ParticleSystem>().Play();
                }
                eyes.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                findeye = true;
                /*開啟魔法陣亮的計時器*/
                //StartCoroutine(CloseMagic_Timer());
            }
        }
        if (findeye)
        {
            if (hamAt && jumpout.Watching_Hint2)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    NumberUI.color = new Color(1, 1, 1, 1);
                    StartCoroutine(WaitTime());
                    jar.SetActive(true);
                    jarr.sprite = qte[num];
                    cab.sprite = cabb[num];
                    tomato.GetComponent<player_walk_2>().enabled = false;
                    tomato.GetComponent<animation>().enabled = false;
                }
                if (organ)
                {
                    NumberObject.SetActive(true);
                    if (num == 0)
                    {
                        fadetime += Time.deltaTime;
                        Number -= Time.deltaTime;
                        NumberUI.color = new Color(1, 1, 1, 1 - (fadetime / 1));
                        if (Number <= 0)
                        {
                            jar.SetActive(false);
                            Number = Timer;
                            num = 0;
                            fadetime = 0;
                            organ = false;
                        }
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            StartCoroutine(QTEcolor());
                            glass_effect.PlayOneShot(glass);
                        }
                        else if (Input.anyKeyDown)
                        {
                            StartCoroutine(errQTEcolor());
                        }

                    }
                    if (num == 1)
                    {
                        fadetime += Time.deltaTime;
                        Number -= Time.deltaTime;
                        NumberUI.color = new Color(1, 1, 1, 1 - (fadetime / 1));
                        if (Number <= 0)
                        {
                            jar.SetActive(false);
                            Number = Timer;
                            num = 0;
                            fadetime = 0;
                            organ = false;
                        }
                        if (Input.GetKeyDown(KeyCode.UpArrow))
                        {
                            StartCoroutine(QTEcolor());
                            glass_effect.PlayOneShot(glass);
                        }
                        else if (Input.anyKeyDown)
                        {
                            StartCoroutine(errQTEcolor());
                        }

                    }
                    if (num == 2)
                    {
                        fadetime += Time.deltaTime;
                        Number -= Time.deltaTime;
                        NumberUI.color = new Color(1, 1, 1, 1 - (fadetime / 1));
                        if (Number <= 0)
                        {
                            jar.SetActive(false);
                            Number = Timer;
                            num = 0;
                            fadetime = 0;
                            organ = false;
                        }
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            StartCoroutine(QTEcolor());
                            glass_effect.PlayOneShot(glass);
                        }
                        else if (Input.anyKeyDown)
                        {
                            StartCoroutine(errQTEcolor());
                        }

                    }
                    if (num == 3)
                    {
                        fadetime += Time.deltaTime;
                        Number -= Time.deltaTime;
                        NumberUI.color = new Color(1, 1, 1, 1 - (fadetime / 1));
                        if (Number <= 0)
                        {
                            jar.SetActive(false);
                            Number = Timer;
                            num = 0;
                            fadetime = 0;
                            organ = false;
                        }
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {
                            StartCoroutine(QTEcolor());
                            glass_effect.PlayOneShot(glass);
                        }
                        else if (Input.anyKeyDown)
                        {
                            StartCoroutine(errQTEcolor());
                        }

                    }
                    if (num == 4)
                    {
                        isch = true;
                        cheeses.SetActive(true);
                        jar.SetActive(false);
                        StartCoroutine(WaitTime2());
                        tomato.GetComponent<cheese>().enabled = false;
                        Flowchart.BroadcastFungusMessage("呼叫獲得麵包對話");
                        //GameObject.Find("MATO").GetComponent<animation>().enabled = false;

                    }
                }
                //GameObject.Find("MATO").GetComponent<animation>().enabled = false;
            }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("眼睛觸發2"))
        {
            Debug.Log("可以點眼睛");
            eyeAt = true;
        }
        if (other.name.StartsWith("起司觸發"))
        {
            Debug.Log("可以點漢堡");
            hamAt = true;
        }
        if (other.name.StartsWith("Magic circle_collider"))
        {
            Magic_Light.GetComponent<ParticleSystem>().Stop();
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("離開ㄌ");
        eyeAt = false;
        hamAt = false;
    }

    IEnumerator CloseMagic_Timer()
    {
        Magic_Light.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(5);
        Magic_Light.GetComponent<ParticleSystem>().Stop();
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.5f);
        organ = true;
    }
    IEnumerator QTEcolor()
    {
        organ = false;
        NumberUI.color = new Color(0, 1, 0, 1);
        yield return new WaitForSeconds(0.5f);
        organ = true;
        num++;
        Number = Timer;
        if (num != 4)
        {
            jarr.sprite = qte[num];
            cab.sprite = cabb[num];
        }
        fadetime = 0;
    }
    IEnumerator errQTEcolor()
    {
        organ = false;
        NumberUI.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.5f);
        jar.SetActive(false);
        Number = Timer;
        num = 0;
        fadetime = 0;
        organ = false;
        tomato.GetComponent<player_walk_2>().enabled = true;
    }

    IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(1f);
        tomato.GetComponent<player_walk_2>().enabled = true;
        tomato.GetComponent<animation>().enabled = true;
    }
}

