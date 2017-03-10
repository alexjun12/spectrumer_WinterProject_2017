using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitParticleMng : MonoBehaviour {

    public GameObject _Parent;
    public GameObject _HitEffectParticle;
    public GameObject _DeadEffect;
    public GameObject _DeadLine;


    public GameObject Ball;
    public List<GameObject> _BallList = new List<GameObject>();
    public GameObject Main_Ball;

    public bool _Dead;
    float _PlusTimeScale;

    public void TempCall()
    {
        //float angle = Random.Range(0.0f,360.0f);
        //float power = Random.Range(0.0f,0.5f);
        //Debug.Log("angle = "+angle);
        //Debug.Log("power = "+power);
        //MakeEffect(Vector3.zero, angle, power);

        DeadEffect(Vector2.zero);
    }

    public void MakeEffect(Vector2 CreatePos,float angle,float power)
    {
        GameObject obj = NGUITools.AddChild(_Parent, _HitEffectParticle);
        obj.transform.localEulerAngles = new Vector3(0, 0, angle);
        obj.transform.localScale = new Vector3(0.06f+(0.08f*(power/66f)),0.06f+(0.08f*(power/ 66f)),0.06f+(0.08f*(power/ 66f)));
        obj.transform.localPosition = new Vector3(CreatePos.x, CreatePos.y, -11);
    }

    public void DeadEffect(Vector2 Pos)
    {
        GameObject obj = NGUITools.AddChild(_Parent, _DeadLine);
        obj.transform.localPosition = Pos;
        StartCoroutine(DeadNext(1.0f, Pos));

        ///////

    }
    IEnumerator DeadNext(float time,Vector2 Pos)
    {
        yield return new WaitForSeconds(time);

        GameObject obj = NGUITools.AddChild(_Parent, _DeadEffect);
        obj.transform.localPosition = Pos;
        

        //구슬사라짐
        
        //Main_Ball.SetActive(false);

        //Time.timeScale = 0.01f;
        //_PlusTimeScale = Time.smoothDeltaTime / 30;
        //_Dead = true;
    }

    void Update()
    {
        if(_Dead)
        {
            Time.timeScale += _PlusTimeScale;
            _PlusTimeScale += _PlusTimeScale / 3;
            if(Time.timeScale>=1.0f)
            {
                Time.timeScale = 1.0f;
                _Dead = false;
            }
        }
    }
}
