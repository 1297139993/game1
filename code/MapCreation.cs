﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {
    public GameObject[] item;
    private List<Vector3> itemPositionList = new List<Vector3>();
    //0.老家 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙
    // Use this for initialization
    private void Awake()
    {
        map1();
        map2();

    }
    
    
    //将要产生物体设为MapCreation下的子集
    private void CreateItem(GameObject createGameObject,Vector3 createPosition,Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }
    
    private bool HasThePosition(Vector3 createPosition)//判断是否有重复位置
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPosition == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }
    //产生随机位置
    private Vector3 CreateRandomPosition()
    {
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0); //不生成x=-10,10的两列，y=-8,8正两行的位置
            if (!HasThePosition(createPosition))
            {
                return createPosition;
            }
        }
       
    }
    private void map1()
    {
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);//实例化老家
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);//实例化围墙
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -7, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);

        }
        for (int i = -8; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int i = -8; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }
        //初始化玩家
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;
        for (int i = -1; i < 2; i++)//初始化敌人
        {
            CreateItem(item[3], new Vector3(i * 10, 8, 0), Quaternion.identity);
        }
        InvokeRepeating("CreateEnemy", 4, 5);
    }
    private void map2()//其他物体创建
    {
        for (int i = 0; i < 60; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }
    }
    private void CreateEnemy()//产生敌人
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0)
        {
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else
        {
            EnemyPos = new Vector3(10, 8, 0);
        }
        CreateItem(item[3], EnemyPos, Quaternion.identity);
    }


}
