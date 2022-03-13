using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int lifeValue = 3;
    public int playScore = 0;
    public bool isDead;
    public bool isDefeat;//游戏失败
    public GameObject born;

    public Text Score;
    public Text Life;
    public GameObject Gameover;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
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

    private void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
