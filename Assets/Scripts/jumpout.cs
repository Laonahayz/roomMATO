using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class jumpout : MonoBehaviour
{
    public GameObject Magic_Light_A, Magic_Light_B;

    public GameObject btn_Exit;
    public GameObject Player;
    public GameObject image;
    public GameObject hint1_veg, hint2_cheese, hint3_meat, hint4_bread;
    public GameObject hint1_BIG, hint2_BIG, hint3_BIG, hint4_BIG;
    static public int CanChooseNum;
    public int Choosing = 1;
    public Image Hint1, Hint2, Hint3, Hint4;
    public Sprite[] ChooseHint1, ChooseHint2, ChooseHint3, ChooseHint4;
    static public bool CanOpenM = false;      //可以開啟魔法陣
    static public bool IsBG_A = false;      //可以開啟魔法陣
    public bool CanCloseHint = false;  //可以關閉提示  
    public bool CanChooseHint = false; //可以選擇提示

    public bool Hint1_Open = false; //Hint1開
    public bool Hint2_Open = false; //Hint2開  
    public bool Hint3_Open = false; //Hint3開  
    public bool Hint4_Open = false; //Hint4開

    static public bool Watching_Hint1 = false; //打開過Hint1
    static public bool Watching_Hint2 = false; //打開過Hint1
    static public bool Watching_Hint3 = false; //打開過Hint1
    static public bool Watching_Hint4 = false; //打開過Hint1

    /*跳轉*/
    public GameObject BG_A, Background_A_Collider;
    public GameObject BG_B, Background_B_Collider;
    [Header("眼睛")]
    public GameObject[] eyes;
    [Header("觸發機關的方塊")]
    public GameObject[] cube;


    public static bool OUO = false; 
    //public Image X;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Change = Player.transform.position; //運算跳轉位置
        Change = new Vector3(-Change.x, -Change.y - 3.8f, Change.z);

        if (CanOpenM)
        {
            if (!ending.EndingNoMagic)
            {
                /*場景跳轉*/
                if (BG_A.activeInHierarchy == true && !CanCloseHint)
                {
                    IsBG_A = true;
                    if (Input.GetKeyDown(KeyCode.S))    //A場景切換
                    {
                        Player.transform.position = Change;
                        Background_A_Collider.SetActive(false);
                        Background_B_Collider.SetActive(true);
                        BG_A.SetActive(false);
                        BG_B.SetActive(true);
                        Player.GetComponent<vagetable>().enabled = false;
                        Player.GetComponent<cheese>().enabled = false;
                        Player.GetComponent<meet>().enabled = true;
                        Player.GetComponent<bread>().enabled = true;
                        eyes[0].SetActive(false);
                        eyes[1].SetActive(false);
                        eyes[2].SetActive(true);
                        eyes[3].SetActive(true);
                        cube[0].SetActive(false);
                        cube[1].SetActive(false);
                        cube[2].SetActive(true);
                        cube[3].SetActive(true);
                    }
                }
                else
                {
                    IsBG_A = false;
                    if (Input.GetKeyDown(KeyCode.S) && !CanCloseHint)    //B場景切換
                    {
                        Player.transform.position = Change;
                        Background_A_Collider.SetActive(true);
                        Background_B_Collider.SetActive(false);
                        BG_A.SetActive(true);
                        BG_B.SetActive(false);
                        Player.GetComponent<vagetable>().enabled = true;
                        Player.GetComponent<cheese>().enabled = true;
                        Player.GetComponent<meet>().enabled = false;
                        Player.GetComponent<bread>().enabled = false;
                        eyes[2].SetActive(false);
                        eyes[3].SetActive(false);
                        eyes[0].SetActive(true);
                        eyes[1].SetActive(true);
                        cube[2].SetActive(false);
                        cube[3].SetActive(false);
                        cube[0].SetActive(true);
                        cube[1].SetActive(true);
                    }
                }

                /*提示環節*/
                if (!CanCloseHint)
                {
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        CanCloseHint = true;
                        Player.GetComponent<player_walk_2>().enabled = false;
                        Player.GetComponent<animation>().enabled = false;
                        image.SetActive(true);
                        if (Player.GetComponent<vagetable>().hint1)
                        {
                            Hint1_Open = true;
                            hint1_veg.SetActive(true);
                        }
                        if (Player.GetComponent<cheese>().hint2)
                        {
                            Hint2_Open = true;
                            hint2_cheese.SetActive(true);
                        }
                        if (Player.GetComponent<meet>().hint3)
                        {
                            Hint3_Open = true;
                            hint3_meat.SetActive(true);
                        }
                        if (Player.GetComponent<bread>().hint4)
                        {
                            Hint4_Open = true;
                            hint4_bread.SetActive(true);
                        }
                        if (Hint1_Open || Hint2_Open || Hint3_Open || Hint4_Open)
                        {
                            CanChooseHint = true;
                        }
                        //GameObject.Find("MATO").GetComponent<player_walk_2>().enabled = false;
                        //GameObject.Find("MATO").GetComponent<animation>().enabled = false;

                        if (Hint1_Open)
                        {
                            Hint1.sprite = ChooseHint1[1];
                            Hint2.sprite = ChooseHint2[0];
                            Hint3.sprite = ChooseHint3[0];
                            Hint4.sprite = ChooseHint4[0];
                            Choosing = 1;
                        }
                        if (Hint2_Open && !Hint1_Open)
                        {
                            Hint2.sprite = ChooseHint2[1];
                            Hint3.sprite = ChooseHint3[0];
                            Hint4.sprite = ChooseHint4[0];
                            Choosing = 2;
                        }
                        if (Hint3_Open && !Hint1_Open && !Hint2_Open)
                        {
                            Hint3.sprite = ChooseHint3[1];
                            Hint4.sprite = ChooseHint4[0];
                            Choosing = 3;
                        }
                        if (Hint4_Open && !Hint1_Open && !Hint2_Open && !Hint3_Open)
                        {
                            Hint4.sprite = ChooseHint4[1];
                            Choosing = 4;
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1.0F);
                        if (!CanChooseHint)
                        {
                            hint1_BIG.SetActive(false);
                            hint2_BIG.SetActive(false);
                            hint3_BIG.SetActive(false);
                            hint4_BIG.SetActive(false);
                            CanChooseHint = true;
                        }
                        else
                        {
                            CanCloseHint = false;
                            image.SetActive(false);
                            Player.GetComponent<player_walk_2>().enabled = true;
                            Player.GetComponent<animation>().enabled = true;
                        }

                        if (Instructions.isopenhintTEST && Instructions.cansay)
                        {
                            Flowchart.BroadcastFungusMessage("獲得眼睛");
                            Instructions.cansay = false;
                            OUO = true;
                        }


                    }
                    /*選擇提示*/
                    if (CanChooseHint)
                    {
                        /*往右*/
                        if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            if (Choosing == 1 && Hint2_Open)
                            {
                                Choosing = Choosing + 1;
                                Hint1.sprite = ChooseHint1[0];
                                Hint2.sprite = ChooseHint2[1];

                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    Choosing = 2;
                                }
                            }

                            else if (Choosing == 3 && Hint4_Open)
                            {
                                Choosing = Choosing + 1;
                                Hint3.sprite = ChooseHint3[0];
                                Hint4.sprite = ChooseHint4[1];
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    Choosing = 4;
                                }
                            }

                            if (Choosing == 1 && !Hint2_Open && Hint4_Open)
                            {
                                Choosing = Choosing + 1;
                                Hint1.sprite = ChooseHint1[0];
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    Choosing = 2;
                                }
                            }

                            if (Choosing == 3 && Hint2_Open && !Hint4_Open)
                            {
                                Choosing = Choosing + 1;
                                Hint3.sprite = ChooseHint3[0];
                                if (Input.GetKeyDown(KeyCode.RightArrow))
                                {
                                    Choosing = 4;
                                }
                            }
                        }
                        /*往左*/
                        if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {

                            if (Choosing == 2 && Hint1_Open)
                            {
                                Choosing -= 1;
                                Hint1.sprite = ChooseHint1[1];
                                Hint2.sprite = ChooseHint2[0];
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    Choosing = 1;
                                }
                            }
                            else if (Choosing == 4 && Hint3_Open)
                            {
                                Choosing -= 1;
                                Hint3.sprite = ChooseHint3[1];
                                Hint4.sprite = ChooseHint4[0];
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    Choosing = 3;
                                }
                            }

                            if (Choosing == 2 && !Hint1_Open && Hint3_Open)
                            {
                                Choosing -= 1;
                                Hint2.sprite = ChooseHint2[0];
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    Choosing = 1;
                                }
                            }
                            if (Choosing == 4 && !Hint3_Open && Hint1_Open)
                            {
                                Choosing -= 1;
                                Hint4.sprite = ChooseHint4[0];
                                if (Input.GetKeyDown(KeyCode.LeftArrow))
                                {
                                    Choosing = 3;
                                }
                            }
                        }
                        /*往下*/
                        if (Input.GetKeyDown(KeyCode.DownArrow))
                        {

                            if (Choosing == 1 && Hint3_Open)
                            {
                                Choosing += 2;
                                Hint1.sprite = ChooseHint1[0];
                                Hint3.sprite = ChooseHint3[1];
                                if (Input.GetKeyDown(KeyCode.DownArrow))
                                {
                                    Choosing = 3;
                                }
                            }
                            else if (Choosing == 2 && Hint4_Open)
                            {
                                Choosing += 2;
                                Hint2.sprite = ChooseHint2[0];
                                Hint4.sprite = ChooseHint4[1];
                                if (Input.GetKeyDown(KeyCode.DownArrow))
                                {
                                    Choosing = 4;
                                }
                            }

                            if (Choosing == 1 && !Hint3_Open && Hint4_Open)
                            {
                                Choosing += 2;
                                Hint1.sprite = ChooseHint1[0];
                                if (Input.GetKeyDown(KeyCode.DownArrow))
                                {
                                    Choosing = 3;
                                }
                            }
                            if (Choosing == 2 && !Hint4_Open && Hint3_Open)
                            {
                                Choosing += 2;
                                Hint2.sprite = ChooseHint2[0];
                                if (Input.GetKeyDown(KeyCode.DownArrow))
                                {
                                    Choosing = 4;
                                }
                            }
                        }
                        /*往上*/
                        if (Input.GetKeyDown(KeyCode.UpArrow))
                        {

                            if (Choosing == 3 && Hint1_Open)
                            {
                                Choosing -= 2;
                                Hint1.sprite = ChooseHint1[1];
                                Hint3.sprite = ChooseHint3[0];
                                if (Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    Choosing = 1;
                                }
                            }
                            else if (Choosing == 4 && Hint2_Open)
                            {
                                Choosing -= 2;
                                Hint2.sprite = ChooseHint2[1];
                                Hint4.sprite = ChooseHint4[0];
                                if (Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    Choosing = 2;
                                }
                            }
                            if (Choosing == 3 && !Hint1_Open && Hint2_Open)
                            {
                                Choosing -= 2;
                                Hint3.sprite = ChooseHint3[0];
                                if (Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    Choosing = 1;
                                }
                            }
                            if (Choosing == 4 && !Hint2_Open && Hint1_Open)
                            {
                                Choosing -= 2;
                                Hint4.sprite = ChooseHint4[0];
                                if (Input.GetKeyDown(KeyCode.UpArrow))
                                {
                                    Choosing = 2;
                                }
                            }
                        }
                    }

                    /*開提示大圖*/
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (Choosing == 1 && Hint1_Open)
                        {
                            hint1_BIG.SetActive(true);
                            Watching_Hint1 = true;
                            CanChooseHint = false;
                        }
                        if (Choosing == 2 && Hint2_Open)
                        {
                            hint2_BIG.SetActive(true);
                            Watching_Hint2 = true;
                            CanChooseHint = false;
                        }
                        if (Choosing == 3 && Hint3_Open)
                        {
                            hint3_BIG.SetActive(true);
                            Watching_Hint3 = true;
                            CanChooseHint = false;
                        }
                        if (Choosing == 4 && Hint4_Open)
                        {
                            hint4_BIG.SetActive(true);
                            Watching_Hint4 = true;
                            CanChooseHint = false;
                        }
                    }


                }
            }
            
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //btn.SetActive(true);
        if (BG_A.activeInHierarchy == true)
        {
            Magic_Light_A.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            Magic_Light_B.GetComponent<ParticleSystem>().Play();
        }
        CanOpenM = true;
        CanCloseHint = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //btn.SetActive(false);
        Magic_Light_A.GetComponent<ParticleSystem>().Stop();
        Magic_Light_B.GetComponent<ParticleSystem>().Stop();
        CanOpenM = false;
    }
}
