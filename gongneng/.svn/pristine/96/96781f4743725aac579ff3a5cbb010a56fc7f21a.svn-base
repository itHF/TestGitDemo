/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: MouseDrawLine.cs
  Author:罗克诚       Version :1.0          Date: 2016-8-8
  Description:实时画线
************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseDrawLine : MonoBehaviour
{
    //绘制线段材质
    public Material material;
    private Dictionary<int, List<Vector3>> dicOfLine;
    List<Vector3> tempList;//临时线的点列表
    int index = -1;

    void Start()
    {
        dicOfLine = new Dictionary<int, List<Vector3>>();
    }

    void OnGUI()
    {
        GUILayout.Label("当前鼠标x轴位置：" + Input.mousePosition.x);
        GUILayout.Label("当前鼠标y轴位置：" + Input.mousePosition.y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            index++;
            tempList = new List<Vector3>();//每次点击鼠标的时候都要实例化一个新的列表
        }

        if (Input.GetMouseButton(0))
        {
            //将每次鼠标改变的位置存储进链表
            tempList.Add(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (tempList.Count < 2)//少于两个点的不添加
            {
                index--;
            }
            else
            {
                dicOfLine.Add(index, tempList);
            }
        }
    }

    void OnPostRender()
    {
        if (!material)
        {
            return;
        }

        material.SetPass(0);
        GL.Color(Color.yellow);
        GL.LoadOrtho();
        GL.Begin(GL.LINES);
        int size = dicOfLine.Count;

        for (int i = 0; i < size; i++)//绘制之前画的线
        {
            List<Vector3> list = dicOfLine[i];
            int listLength = list.Count;
            for (int j = 0; j < listLength - 1; j++)
            {
                Vector3 start = list[j];
                Vector3 end = list[j + 1];
                DrawLine2D(start.x, start.y, end.x, end.y);
            }
        }

        if (tempList != null)//绘制当前正在画的内容
        {
            int currentLength = tempList.Count;
            for (int l = 0; l < currentLength - 1; l++)
            {
                Vector3 start = tempList[l];
                Vector3 end = tempList[l + 1];
                DrawLine2D(start.x, start.y, end.x, end.y);
            }
        }

        GL.End();
    }

    void DrawLine2D(float x1, float y1, float x2, float y2)
    {
        GL.Vertex3(x1 / Screen.width, y1 / Screen.height, 0);
        GL.Vertex3(x2 / Screen.width, y2 / Screen.height, 0);
    }
}
