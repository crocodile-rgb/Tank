using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed = 3;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//上右下左
    public GameObject bullet;
    public GameObject explosion;
    private Vector3 bulletEulerAngle;

    private float TimeVal;//攻击间隔
    private float TimeValChangeDir;//转向
    private float v=-1, h;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();//获得自身组件
    }
    void Start()
    {

    }

    void Update()
    {
        //攻击间隔
        if (TimeVal >= 1)
        {
            Attack();
        }
        else
        {
            TimeVal += Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    /// <summary>
    /// tank移动方法
    /// </summary>
    private void Move()
    {
        if (TimeValChangeDir >= 4)
        {
            int num = Random.Range(0, 8);
            if (num >= 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num >= 1 && num <= 2)
            {
                v = 0;
                h = 1;
            }
            else
            {
                v = 0;
                h = -1;
            }
            TimeValChangeDir = 0;
            
        }else
        {
            TimeValChangeDir += Time.deltaTime;
        }
        
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
        if (h != 0)
        {
            return;
        }
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
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    private void Attack()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngle));
        TimeVal = 0;
    }
    //死亡方法
    private void Die()
    {
        GameManager2.Instance2.playScore++;
        //爆炸特效
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Enemy")
        {
            TimeValChangeDir = 4;
        }
    }
}
