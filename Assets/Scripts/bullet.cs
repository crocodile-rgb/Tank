using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float bulletSpeed=10;
    public bool isPlayerBullet;
    public AudioClip barriarClip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * bulletSpeed * Time.deltaTime, Space.World);
    }

    //Tank:玩家tank
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Home":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Wood":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barriar":
                if (isPlayerBullet)
                {
                    AudioSource.PlayClipAtPoint(barriarClip, transform.position);
                }
                Destroy(gameObject);
                break;
            case "Tank":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Tank2":
                if (!isPlayerBullet)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
    }
}
