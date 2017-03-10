using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {
    public GameObject _Popup;
    public GameObject Main_Title;
    public GameObject BG;
    public GameObject option;
    public GameObject Credit;
    public GameObject Credit_Button;
    public GameObject Skin1;
    public GameObject Skin2;
    public Sprite H_Back;

    public bool Hero_Sprite1_check;
    public bool Hero_Sprite2_check;

    public Sprite H_Skin1;
    public Sprite H_Skin2;

   
	public void Popup_Open()
    {
        Main_Title.SetActive(false);
        //_Popup.SetActive(true);
        option.SetActive(false);


        _Popup.GetComponent<Animator>().SetTrigger("Show");
    }


    public void Popup_del()
    {
        Main_Title.SetActive(true);
        //_Popup.SetActive(false);
        

        _Popup.GetComponent<Animator>().SetTrigger("del");
    }

    public void selet_skin1()
    {
        BG.GetComponent<UI2DSprite>().sprite2D = Skin1.GetComponent<UI2DSprite>().sprite2D;
        Hero_Sprite1_check = true;
        Hero_Sprite2_check = false;
    }

    public void selet_skin2()
    {
        BG.GetComponent<UI2DSprite>().sprite2D = H_Back;
        Hero_Sprite2_check = true;
        Hero_Sprite1_check = false;
    }

    public void show_Credit()
    {
        Credit_Button.SetActive(false);
        Credit.SetActive(true);
        Skin2.SetActive(false);
        Skin1.SetActive(false);   
    }

    public void del_Credit()
    {
        Credit_Button.SetActive(true);
        Credit.SetActive(false);
        Skin2.SetActive(true);
        Skin1.SetActive(true);
    }

    public void show_option()
    {
        option.SetActive(true);
    }
}
