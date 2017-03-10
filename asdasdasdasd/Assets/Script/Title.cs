using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
    public GameObject InGame;
    public GameObject MainTitle;
    public GameObject option;


    public void GameStart()
    {
        Debug.Log("Start");
        InGame.SetActive(true);
        MainTitle.SetActive(false);
        option.SetActive(false);
    }
}
