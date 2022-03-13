using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public GameObject Tank;
    public GameObject Tank2;
    public GameObject[] EnemyTank;
    public bool BorningPlayer;
    public bool BorningPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Borning", 1f);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Borning()
    {
        if (BorningPlayer)
        {
            Instantiate(Tank, transform.position, transform.rotation);
        }
        else if (BorningPlayer2)
        {
            Instantiate(Tank2, transform.position, transform.rotation);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(EnemyTank[num], transform.position, transform.rotation);
        }
    }
}
