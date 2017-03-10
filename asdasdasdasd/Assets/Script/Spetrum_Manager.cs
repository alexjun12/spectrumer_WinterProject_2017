using UnityEngine;
using System.Collections;

public class Spetrum_Manager : MonoBehaviour {

    public GameObject[] Back_spetrum_list;

    public float height;

    public GameObject[] Spetrum_list;

    public AudioSource[] audio_list;
    public AudioSource audiosource;
    float[] spectrum;
    float[] volume;
    public int numSamples;
    public int channel;

    // Use this for initialization
    void Start () {

        volume = new float[numSamples];
        spectrum = new float[numSamples];

        //랜덤음악
        int random = Random.Range(0, audio_list.Length);
        audio_list[random].Play();
        audiosource = audio_list[random];
    }
	
	// Update is called once per frame
	void Update () {
        audiosource.GetOutputData(volume, channel);
        audiosource.GetSpectrumData(spectrum, channel, FFTWindow.Rectangular);

        for(int i = 0; i<52; i++)
        {
            if(i < 31)
            {
            Spetrum_list[i].transform.localScale = new Vector3(1f, height * spectrum[i], 1);
            }
            else
            {
                Spetrum_list[i].transform.localScale = new Vector3(1f, 55 * spectrum[i], 1);
            }

            if(i<16)
            {
                if (Back_spetrum_list[i] != null)
                {
                    Back_spetrum_list[i].transform.localScale = new Vector3(1f, 13 * spectrum[15 - i] + 0.03f, 1f);
                }
            }

        }
    }
}
