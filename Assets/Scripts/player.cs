using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 3;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//上右下左
    public GameObject bullet;
    public GameObject explosion;
    public GameObject defendEffect;
    private Vector3 bulletEulerAngle;

    private float TimeVal;//攻击间隔
    private float defendTime = 3;//无敌时间
    private bool isDefended = true;

    public AudioSource moveAudio;
    public AudioClip[] tankClip;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();//获得自身组件
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        //无敌状态
        if (isDefended)
        {
            defendEffect.SetActive(true);
            defendTime -= Time.deltaTime;
            if (defendTime <= 0)
            {
                isDefended = false;
                defendEffect.SetActive(false);
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.isDefeat)
        {
            return;
        }
        Move();
        //攻击CD
        if (TimeVal >= 0.4)
        {
            Attack();
        }
        else
        {
            TimeVal += Time.fixedDeltaTime;
        }
    }
    /// <summary>
    /// tank移动方法
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * speed * Time.fixedDeltaTime, Space.World);//（#1世界坐标轴，World）(#2自身坐标轴，Self或省略)
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngle = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngle = new Vector3(0, 0, -90);
        }
        if (Mathf.Abs(h) > 0.05)
        {
            moveAudio.clip = tankClip[1];
            if(moveAudio.isPlaying)
            moveAudio.Play();
        }

        if (h != 0)
        {
            return;
        }
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * speed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngle = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngle = new Vector3(0, 0, 0);
        }

        if (Mathf.Abs(v) > 0.05)
        {
            moveAudio.clip = tankClip[1];
            if (moveAudio.isPlaying)
                moveAudio.Play();
        }
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles+bulletEulerAngle));
            TimeVal = 0;
        }
    }
    //死亡方法
    private void Die()
    {
        if (isDefended)
        {
            return;
        }
       
        GameManager.Instance.isDead = true;
        //爆炸特效
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
