using UnityEngine;
using System.Collections;

public class Ball_Controll : MonoBehaviour
{
    public HitParticleMng ParticleMng;
    public ball_manager B_manager;
    public float speed;
    int _direction;
    Vector3 Collision_Vector;
    int collision_check = 0;
    Vector3 Co_vector;
    Rigidbody2D R_body;
    Vector3 coll_pos;
    float add_pos;
    bool col_check = false;
    float col_time;
    int random_add;
    float temp;

    bool Game_Check;
    // Use this for initialization
    void Start()
    {
        B_manager = GameObject.Find("ball_manager").GetComponent<ball_manager>();
        ParticleMng = GameObject.Find("HJ_Manager").GetComponent<HitParticleMng>();
        _direction = Random.Range(0, 5);
        R_body = transform.GetComponent<Rigidbody2D>();
        R_body.AddForce(new Vector2(Random.Range(50f, 60f), Random.Range(50f, 60f)));     
    }

    // Update is called once per frame
    void Update()
    {
        if (Game_Check)
        {
            //Destroy(gameObject);
            R_body.constraints = RigidbodyConstraints2D.FreezePosition;
        }

        if (transform.localPosition.x >= 642f || transform.localPosition.y >= 371f ||
            transform.localPosition.x <= -633f || transform.localPosition.y <= -350f)
        {
            Destroy(gameObject);
            B_manager.count--;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!col_check)
        {
            random_add = Random.Range(0, 2);
            if (random_add == 1)
            {
                temp = 1;
            }
            else
            {
                temp = -1;
            }
            add_pos = Random.Range(55f, 66f);
            if (coll.gameObject.tag == "up")
            {
                ParticleMng.MakeEffect(transform.localPosition, 180f, add_pos/4);
                R_body.AddForce(new Vector2(add_pos * temp, -25f));
            }
            if (coll.gameObject.tag == "under")
            {
                ParticleMng.MakeEffect(transform.localPosition, 1f, add_pos/4);
                R_body.AddForce(new Vector2(add_pos * temp, 25f));
            }
            if (coll.gameObject.tag == "left")
            {
                ParticleMng.MakeEffect(transform.localPosition, -90f, add_pos/4);
                R_body.AddForce(new Vector2(25f, add_pos * temp));
            }
            if (coll.gameObject.tag == "right")
            {
                ParticleMng.MakeEffect(transform.localPosition, 90f, add_pos/4);
                R_body.AddForce(new Vector2(-25f, add_pos * temp));
            }
        }
    }

    public void GameEnd()
    {
        Game_Check = true;
    }
}
