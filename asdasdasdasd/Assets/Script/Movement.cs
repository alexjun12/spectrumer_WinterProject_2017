using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public UILabel label;
    public HitParticleMng ParticleMng;
    public ball_manager b_manager;
    public GameObject Ingame;
    public GameObject Title;
    public GameObject option;
    public Popup popmanager;
    public float speed;
    bool Game_Check;

    float play_time;
    int time;

    void OnEnable()
    {
        time = 0;
        play_time = 0;
        Game_Check = false;
        transform.localPosition = Vector3.zero;
        b_manager.Game_End = false;
        b_manager.count = 0;

        if (popmanager.Hero_Sprite1_check)
        {
            transform.GetComponent<UI2DSprite>().sprite2D = popmanager.H_Skin1;
        }
        if(popmanager.Hero_Sprite2_check)
        {
            transform.GetComponent<UI2DSprite>().sprite2D = popmanager.H_Skin2;
        }
    }

    void Start()
    {
        Game_Check = false;
        
    }
     
    void Update()
    {
        if(!Game_Check)
        {
            Vector3 move = Input.acceleration;
            //transform.Translate(move * speed,);
            transform.localPosition += new Vector3(move.x * speed, move.y * speed, 0f);
            float radia = Mathf.Atan2(0 - move.y, 0 - move.x);
            transform.localEulerAngles = new Vector3(0, 0, radia * Mathf.Rad2Deg);

            play_time += Time.deltaTime;
            time = (int)play_time;
            label.text = time.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "ball")
        {
            Game_Check = true;
            ParticleMng.DeadEffect(transform.localPosition);
            b_manager.Game_End = true;
            /*
            for(int i = 0; i< ParticleMng._BallList.Count;i++)
            {
                ParticleMng._BallList[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
            */
            GameOver();
        }
    }

    public void GameOver()
    {
        //ParticleMng.DeadEffect(transform.localPosition);
        StartCoroutine(GameOverSet(1.0f));
        
    }

    IEnumerator GameOverSet(float time)
    {
        yield return new WaitForSeconds(time);

        transform.localPosition = new Vector3(1400, 1400, 1400);
        Ingame.SetActive(false);
        Title.SetActive(true);
        option.SetActive(true);
        for (int i = 0; i < ParticleMng._BallList.Count; i++)
        {
            Destroy(ParticleMng._BallList[i].gameObject);
        }
     
        ParticleMng._BallList.Clear();

    }
}
