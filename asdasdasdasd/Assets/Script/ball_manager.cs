using UnityEngine;
using System.Collections;

public class ball_manager : MonoBehaviour {
    public GameObject uiroot;
    public GameObject ball;
    public GameObject[] ball_spawn;
    public HitParticleMng ParticleMng;
    public float time;
    float _time;
    public int count = 0;

    public bool Game_End = false;
	// Update is called once per frame
	void Update () {
        _time += Time.deltaTime;

        if(!Game_End)
        {
            if (_time >= time && count < 5)
            {
                _time = 0f;
                count++;
                int random = Random.Range(0, 4);
                GameObject obj = NGUITools.AddChild(uiroot, ball);
                obj.transform.localPosition = ball_spawn[random].transform.localPosition;
                ParticleMng._BallList.Add(obj);
            }
        }
       
	}
}
