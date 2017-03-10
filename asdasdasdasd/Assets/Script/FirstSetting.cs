using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FirstSetting : MonoBehaviour {
    public AudioSource[] audio_list;
    AudioSource audiosource;
    float[] spectrum;
    float[] volume;
    public GameObject enem;
    public int numSamples;
    public GameObject p_under;
    public GameObject p_left;
    public GameObject p_right;
    public GameObject p_up;

    public int channel;
    List<GameObject> _obj_list = new List<GameObject>();
    public int count;
    
    // Use this for initialization
	void Start () {
        
        volume = new float[numSamples];
        spectrum = new float[numSamples];
        //랜덤음악
        int random = Random.Range(0, audio_list.Length);
        audio_list[random].Play();
        audiosource = audio_list[random];

        //아래
        for (int i = 0;i< 13; i++)
        {
                GameObject obj = NGUITools.AddChild(p_under, enem);
                obj.transform.localPosition = new Vector3(i * 100f - 588f, -358f, 1f);
                obj.gameObject.tag = "under";
            _obj_list.Add(obj);
        }
        //왼쪽
        for(int i = 0;i<8;i++)
        {
            GameObject obj = NGUITools.AddChild(p_left, enem);
            obj.transform.localPosition = new Vector3(-639f, i * 100f -352f, 1f);
            obj.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            obj.gameObject.tag = "left";
            _obj_list.Add(obj);
        }
        //오른쪽
        for(int i = 0;i<8;i++)
        {
            GameObject obj = NGUITools.AddChild(p_right, enem);
            obj.transform.localPosition = new Vector3(637f, i * 100f - 354f, 1f);
            obj.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            obj.gameObject.tag = "right";
            _obj_list.Add(obj);
        }
        //위
        for(int i = 0;i<13;i++)
        {
            GameObject obj = NGUITools.AddChild(p_up, enem);
            obj.transform.localPosition = new Vector3(i * 100f -588f,355f, 1f);
            obj.gameObject.tag = "up";
            _obj_list.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
        audiosource.GetOutputData(volume, channel);
        audiosource.GetSpectrumData(spectrum, channel, FFTWindow.Rectangular);

        for(int i = 0;i< 42; i++)
        {
            if(_obj_list[i] != null)
            {
                if(_obj_list[i].transform.tag == "under")
                {
                    _obj_list[i].transform.localScale = new Vector3(1, 200 * spectrum[i], 1);
                }
                else
                {
                    _obj_list[i].transform.localScale = new Vector3(1, 500 * spectrum[i], 1);
                }

            }
            
        }
    }
}
