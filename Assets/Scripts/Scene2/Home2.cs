using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home2 : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite brokenSprite;
    public GameObject explosion;
    public AudioClip homeClip;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
    }
    private void Die()
    {
        sr.sprite = brokenSprite;
        Instantiate(explosion, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(homeClip, transform.position);
        GameManager2.Instance2.isDefeat = true;
    }
}
