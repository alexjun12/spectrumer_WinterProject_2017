using UnityEngine;
using System.Collections;

public class show_option : MonoBehaviour {
    public GameObject title;
    public GameObject option;

    public void show()
    {
        option.SetActive(true);
        title.SetActive(true);
    }
}
