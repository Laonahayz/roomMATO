using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class meet : MonoBehaviour
{
    [Header("魔法陣特效")]
    public GameObject Magic_Light;
    [Header("番茄")]
    public GameObject tomato;
    [Header("眼睛")]
    public GameObject eyes;
    [Header("書櫃放大")]
    public GameObject boook;
    public Image book;
    public GameObject boooook;
    public Sprite[] books;
    [Header("肉片")]
    public GameObject meets;
    [Header("書櫃碰撞物件")]
    public GameObject bookcube;
    public Animator animator;
    [Header("提示視角3")]
    public bool hint3 = false;
    [Header("玻璃音效")]
    public AudioSource book_effect;
    public AudioClip bookplacing, bkmagicOP;


    public int num = 0;

    bool hamAt = false;
    bool eyeAt = false;
    bool findeye = false;
    bool organ = false;
    public bool ismeat = false;
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
                    hint3 = true;
                    jumpout.CanChooseNum = 3;
                    book_effect.PlayOneShot(bkmagicOP);
                    Magic_Light.GetComponent<ParticleSystem>().Play();
                }
                eyes.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                findeye = true;
                /*hint3_meat.SetActive(true);
                hint3_meat.GetComponent<Image>().color = new Color(1, 1, 1, 0.0F);
                hint3_meat.GetComponent<Button>().interactable = false;*/
                /*開啟魔法陣亮的計時器*/
                //StartCoroutine(CloseMagic_Timer());
            }
        }
        if (findeye)
        {
            if (hamAt && jumpout.Watching_Hint3)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(WaitTime());
                    num = 4;
                    book.sprite = books[num];
                    boook.SetActive(true);
                    tomato.GetComponent<player_walk_2>().enabled = false;
                    tomato.GetComponent<animation>().enabled = false;
                    //GameObject.Find("MATO").GetComponent<animation>().enabled = false;
                }
                if (organ)
                {
                    if (Input.GetKeyUp(KeyCode.LeftArrow))
                    {
                        num = num - 1;
                        if (num <= 0)
                        {
                            num = 0;
                            book.sprite = books[num];
                        }
                        else
                        {
                            book.sprite = books[num];
                        }
                        book_effect.PlayOneShot(bookplacing);
                    }
                    if (Input.GetKeyUp(KeyCode.RightArrow))
                    {
                        num = num + 1;
                        if (num >= 8)
                        {
                            num = 8;
                        }
                        else
                        {
                            book.sprite = books[num];
                        }
                        book_effect.PlayOneShot(bookplacing);
                    }
                    if (num == 8)
                    {
                        boooook.SetActive(false);
                        animator.SetBool("book1", true);
                        StartCoroutine(Anima());
                        //GameObject.Find("MATO").GetComponent<animation>().enabled = false;
                    }
                    if (num == 9)
                    {
                        ismeat = true;
                        meets.SetActive(true);
                        tomato.GetComponent<player_walk_2>().enabled = true;
                        tomato.GetComponent<animation>().enabled = true;
                        tomato.GetComponent<meet>().enabled = false;
                        Flowchart.BroadcastFungusMessage("呼叫獲得起司對話");
                        boook.SetActive(false);
                    }
                }

            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("眼睛觸發3"))
        {
            Debug.Log("可以點眼睛");
            eyeAt = true;
        }
        if (other.name.StartsWith("肉片觸發"))
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
        num = 9;
    }
}
