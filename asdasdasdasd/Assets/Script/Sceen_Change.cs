using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Sceen_Change : MonoBehaviour {

    // Use this for initialization
    float time;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >=5.5f)
        {
            time = 0;
            SceneManager.LoadScene(1);
            
        }
	}
}
