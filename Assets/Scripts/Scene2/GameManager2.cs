using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager2 : MonoBehaviour
{
    public int lifeValue = 6;
    public int playScore = 0;
    public bool isDead;
    public bool isDead2;
    public bool isDefeat;//游戏失败
    public GameObject born;

    public Text Score;
    public Text Life;
    public GameObject Gameover;

    private static GameManager2 instance2;
    public static GameManager2 Instance2
    {
        get
        {
            return instance2;
        }
        set
        {
            instance2 = value;
        }
    }

    private void Awake()
    {
        Instance2 = this;
    }

    void Start()
    {
        
    }
    void Update()
    {
        if (isDefeat)
        {
            Gameover.SetActive(true);
            Invoke("LoadMainScene", 3);
            return;
        }
        if (isDead)
        {
            Recover();
        }
        if (isDead2)
        {
            Recover2();
        }
        //UI
        Score.text = playScore.ToString();
        Life.text = lifeValue.ToString();
    }

    private void Recover()
    {
        if (lifeValue <= 0)
        {
            isDefeat = true;
            Gameover.SetActive(true);
            Invoke("LoadMainScene", 3);
        }else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.gameObject.GetComponent<Born>().BorningPlayer = true;
            isDead = false;
        }
    }
    private void Recover2()
    {
        if (lifeValue <= 0)
        {
            isDefeat = true;
            Gameover.SetActive(true);
            Invoke("LoadMainScene", 3);
        }
        else
        {
            lifeValue--;
            GameObject go2 = Instantiate(born, new Vector3(2, -8, 0), Quaternion.identity);
            go2.gameObject.GetComponent<Born>().BorningPlayer2 = true;
            isDead2 = false;
        }
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
