using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class vagetable : MonoBehaviour
{
    [Header("魔法陣特效")]
    public GameObject Magic_Light;
    [Header("番茄")]
    public GameObject tomato;
    [Header("眼睛")]
    public GameObject eyes;
    [Header("羊頭放大")]
    public GameObject goat;
    [Header("生菜")]
    public GameObject vegtable;
    [Header("山羊碰撞物件")]
    public GameObject goatcube;
    [Header("提示視角1")]
    public bool hint1 = false;
    public Animator animator;
    [Header("生菜音效")]
    public AudioSource Veg_effect;
    public AudioClip Vegsound, vegMagicOP;

    bool hamAt = false;
    bool eyeAt = false;
    bool findeye = false;
    bool organ = false;
    public bool isvage = false;
    int num = 0;
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
                    hint1 = true;
                    jumpout.CanChooseNum = 1;
                    Veg_effect.PlayOneShot(vegMagicOP);
                    Magic_Light.GetComponent<ParticleSystem>().Play();
                }
                eyes.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                findeye = true;
                //StartCoroutine(CloseMagic_Timer());
                /*hint1_veg.SetActive(true);
                hint1_veg.GetComponent<Image>().color = new Color(1, 1, 1, 0.0F);
                hint1_veg.GetComponent<Button>().interactable = false;*/

            }
        }
        if (findeye)
        {
            if (hamAt && jumpout.Watching_Hint1)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(WaitTime());
                    goat.SetActive(true);
                    tomato.GetComponent<player_walk_2>().enabled = false;
                    tomato.GetComponent<animation>().enabled = false;
                    //GameObject.Find("MATO").GetComponent<animation>().enabled = false;
                }
                if (organ)
                {
                    if (num == 0)
                    {
                        if (Input.GetKey(KeyCode.DownArrow))
                        {
                            animator.SetBool("vage1", true);
                            StartCoroutine(Anima());
                            Veg_effect.PlayOneShot(Vegsound);
                        }
                    }
                    if (num == 1)
                    {
                        StartCoroutine(WaitTime2());
                        vegtable.SetActive(true);
                        
                        goat.SetActive(false);
                        tomato.GetComponent<vagetable>().enabled = false;
                        Flowchart.BroadcastFungusMessage("呼叫獲得生菜對話");
                        //GameObject.Find("MATO").GetComponent<animation>().enabled = false;
                    }
                }
            }
        }

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("眼睛觸發1"))
        {
            Debug.Log("可以點眼睛");
            eyeAt = true;
        }
        if (other.name.StartsWith("生菜觸發"))
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
    IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(1f);
        tomato.GetComponent<player_walk_2>().enabled = true;
        tomato.GetComponent<animation>().enabled = true;
    }
    IEnumerator Anima()
    {
        yield return new WaitForSeconds(1.5f);
        
        isvage = true;
        num = 1;
    }
}
