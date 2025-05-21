using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class bread : MonoBehaviour
{
    [Header("魔法陣特效")]
    public GameObject Magic_Light;
    [Header("番茄")]
    public GameObject tomato;
    [Header("眼睛")]
    public GameObject eyes;
    [Header("祭壇放大")]
    public GameObject altarr;
    public Image altar;
    [Header("祭壇文字圖")]
    public Sprite[] words;
    [Header("麵包")]
    public GameObject breads;
    [Header("祭壇碰撞物件")]
    public GameObject altarcube;
    public Animator animator;
    [Header("提示視角4")]
    public bool hint4 = false;
    [Header("祭壇音效")]
    public AudioSource bread_effect;
    public AudioClip breadsound, bdMagicOP;

    bool hamAt = false;
    bool eyeAt = false;
    bool findeye = false;
    public bool organ = false;
    public int num = 0;
    public bool isbread = false;


    // Start is called before the first frame update
    void Start()
    {

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
                    hint4 = true;
                    jumpout.CanChooseNum = 4;
                    bread_effect.PlayOneShot(bdMagicOP);
                    Magic_Light.GetComponent<ParticleSystem>().Play();
                }
                eyes.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                findeye = true;
                /*hint4_bread.SetActive(true);
                hint4_bread.GetComponent<Image>().color = new Color(1, 1, 1, 0.0F);
                hint4_bread.GetComponent<Button>().interactable = false;*/
                /*開啟魔法陣亮的計時器*/
                // StartCoroutine(CloseMagic_Timer());
            }
        }
        if (findeye)
        {
            if (hamAt && jumpout.Watching_Hint4)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(WaitTime());
                    altar.sprite = words[num];
                    tomato.GetComponent<player_walk_2>().enabled = false;
                    tomato.GetComponent<animation>().enabled = false;
                    //GameObject.Find("MATO").GetComponent<animation>().enabled = false;
                }
                if (organ)
                {
                    altarr.SetActive(true);
                    if (num == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.J))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }

                    }
                    if (num == 1)
                    {
                        if (Input.GetKeyDown(KeyCode.I))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }

                    }
                    if (num == 2)
                    {
                        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 3)
                    {
                        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 4)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 5)
                    {
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 6)
                    {
                        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 7)
                    {
                        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 8)
                    {
                        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 9)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 10)
                    {
                        if (Input.GetKeyDown(KeyCode.C))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 11)
                    {
                        if (Input.GetKeyDown(KeyCode.J))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 12)
                    {
                        if (Input.GetKeyDown(KeyCode.O))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 13)
                    {
                        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
                        {
                            StartCoroutine(RigWord());
                        }
                        else if (Input.anyKeyDown)
                        {
                            num = 0;
                            altarr.SetActive(false);
                            tomato.GetComponent<player_walk_2>().enabled = true;
                            tomato.GetComponent<animation>().enabled = true;
                            organ = false;
                        }
                    }
                    if (num == 14)
                    {
                        animator.SetBool("altar1", true);
                        StartCoroutine(Anima());
                        //GameObject.Find("MATO").GetComponent<animation>().enabled = false;
                        bread_effect.volume = 0.25f;
                        bread_effect.PlayOneShot(breadsound);
                    }
                    if (num == 15)
                    {
                        bread_effect.volume = 0.6f;
                        isbread = true;
                        breads.SetActive(true);
                        altarr.SetActive(false);
                        tomato.GetComponent<player_walk_2>().enabled = true;
                        tomato.GetComponent<animation>().enabled = true;
                        tomato.GetComponent<bread>().enabled = false;
                        Flowchart.BroadcastFungusMessage("呼叫獲得肉片對話");
                    }
                }

            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("眼睛觸發4"))
        {
            Debug.Log("可以點眼睛");
            eyeAt = true;
        }
        if (other.name.StartsWith("麵包觸發"))
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
    IEnumerator Anima()
    {
        yield return new WaitForSeconds(2);
        num = 15;
    }
    IEnumerator RigWord()
    {
        yield return new WaitForSeconds(0.01f);
        num++;
        altar.sprite = words[num];
    }
}

