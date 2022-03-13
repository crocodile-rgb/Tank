using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreat : MonoBehaviour
{
    //0家,1墙,2障碍,3出生效果,4河流，5草，6空气墙
    public GameObject[] items;
    private List<Vector3> Vlist = new List<Vector3>();
    private void Awake()
    {
        InitMap();
    }

    private void InitMap()
    {
        //CreatMap
        CreatItem(items[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreatItem(items[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreatItem(items[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i <= 1; i++)
        {
            CreatItem(items[1], new Vector3(i, -7, 0), Quaternion.identity);
        }
        //AirWall
        for (int i = -11; i < 12; i++)
        {
            CreatItem(items[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreatItem(items[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreatItem(items[6], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreatItem(items[6], new Vector3(11, i, 0), Quaternion.identity);
        }

        for (int i = 0; i < 60; i++)
        {
            CreatItem(items[1], RandomCreatPos(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreatItem(items[2], RandomCreatPos(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreatItem(items[4], RandomCreatPos(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreatItem(items[5], RandomCreatPos(), Quaternion.identity);
        }

        //玩家
        GameObject player = Instantiate(items[3], new Vector3(-2, -8, 0), Quaternion.identity);
        //Vlist.Add(new Vector3(-2, -8, 0));
        player.GetComponent<Born>().BorningPlayer = true;

        
        //敌人
        CreatItem(items[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreatItem(items[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreatItem(items[3], new Vector3(10, 8, 0), Quaternion.identity);
        InvokeRepeating("CreatEnemy", 8, 8);
    }

    private void CreatItem(GameObject item,Vector3 pos,Quaternion rot)
    {
        GameObject itemGo=Instantiate(item, pos, rot);
        itemGo.transform.SetParent(gameObject.transform);
        Vlist.Add(pos);
    }

    //Random to Creat Map
    private Vector3 RandomCreatPos()
    {
        while (true)
        {
            Vector3 ranPos = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!IsExist(ranPos))
            {
                return ranPos;
            }
        }
    }

    private bool IsExist(Vector3 v)
    {
        for(int i = 0; i < Vlist.Count; i++)
        {
            if (v == Vlist[i]) return true;
        }
        return false;
    }


    private void CreatEnemy()
    {
        int num = Random.Range(0,3);
        if (num == 0)
        {
            Instantiate(items[3], new Vector3(-10, 8, 0), Quaternion.identity);
        }else if (num == 1)
        {
            Instantiate(items[3], new Vector3(0, 8, 0), Quaternion.identity);
        }else
        {
            Instantiate(items[3], new Vector3(10, 8, 0), Quaternion.identity);
        }
    }
}
