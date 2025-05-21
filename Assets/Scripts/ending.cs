using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class ending : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tomato, MATO_END,HAM;
    public GameObject Magic_LightA, Magic_LightB;
    public GameObject MATOlight;
    public Animator Ham,MatoEND;
    static public bool EndingNoMagic = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tomato.GetComponent<bread>().isbread && tomato.GetComponent<cheese>().isch && tomato.GetComponent<meet>().ismeat && tomato.GetComponent<vagetable>().isvage)
        {
            if (jumpout.IsBG_A)
            {
                Magic_LightA.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                Magic_LightB.GetComponent<ParticleSystem>().Play();
            }

            if (jumpout.CanOpenM)
            {
                Magic_LightA.GetComponent<ParticleSystem>().Stop();
                Magic_LightB.GetComponent<ParticleSystem>().Stop();
                EndingNoMagic = true;
                MATO_END.SetActive(true);
                tomato.SetActive(false);
                MATOlight.SetActive(false);
                tomato.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.0F);
                StartCoroutine(Endanime());
            }
        }
    }
    IEnumerator Endanime()
    {
        yield return new WaitForSeconds(1);
        Ham.SetBool("END", true);
        yield return new WaitForSeconds(4);
        MatoEND.SetBool("END", true);
        yield return new WaitForSeconds(1);
        HAM.SetActive(false);
        yield return new WaitForSeconds(4);
        Flowchart.BroadcastFungusMessage("結局對話");
    }
}
