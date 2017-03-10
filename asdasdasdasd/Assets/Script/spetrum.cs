using UnityEngine;
using System.Collections;

public class spetrum : MonoBehaviour {
    float _force;
    public GameObject effect;
    public GameObject p_effect;
    bool black = false;

    void Start()
    {
        //p_effect = GameObject.FindWithTag("p_eff");
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.transform.tag == "ball")
        {

            if (transform.tag == "under")
            {
                under_spetrum(obj);
                show_spetrum(obj);
                change_color();
            }
            if (transform.tag == "left")
            {
                left_spetrum(obj);
                show_spetrum(obj);
                change_color();
            }
            if(transform.tag == "right")
            {
                right_spetrum(obj);
                show_spetrum(obj);
                change_color();
            }
            if(transform.tag == "up")
            {
                up_spetrum(obj);
                show_spetrum(obj);
                change_color();
            }
        }
    }

    void change_color()
    {
        if(black)
        {
            black = false;
            transform.GetComponent<UI2DSprite>().color = Color.white;
        }
        else
        {
            black = true;
            transform.GetComponent<UI2DSprite>().color = Color.black;
        }    
    }
    void show_spetrum(Collision2D obj)
    {
        GameObject eff = NGUITools.AddChild(p_effect, effect);
        eff.transform.localPosition = obj.transform.localPosition;
        eff.transform.localScale = new Vector3(0.1f, 0.01f, 0.1f);
    }
    void up_spetrum(Collision2D obj)
    {
        _force = transform.localScale.y * 100f;

        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                {
                    obj.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(30f, -_force));
                    break;
                }
            case 1:
                {
                    obj.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-30f, -_force));
                    break;
                }
        }
    }
    void right_spetrum(Collision2D obj)
    {
        _force = transform.localScale.y * 100f;
        obj.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-_force, 0f));
    }
    void left_spetrum(Collision2D obj)
    {
        _force = transform.localScale.y * 100f;
        obj.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(_force, 0f));
    }
    void under_spetrum(Collision2D obj)
    {
        _force = transform.localScale.y * 100f;

        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                {
                    obj.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(30f, _force));
                    break;
                }
            case 1:
                {
                    obj.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(-30f, _force));
                    break;
                }
        }
    }
}
