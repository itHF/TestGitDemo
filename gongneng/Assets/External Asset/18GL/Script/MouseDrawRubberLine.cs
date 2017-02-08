/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: MouseDrawRubberLine.cs
  Author:罗克诚       Version :1.0          Date: 2016-8-8
  Description:画橡皮条
************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseDrawRubberLine : MonoBehaviour
{
    public Material lineMaterial;
    Vector3[] tempLine;
    Dictionary<int, Vector3[]> dicOfLine;
    bool startDraw = false;
    int index;

    // Use this forinitialization
    void Start()
    {
        index = -1;
        dicOfLine = new Dictionary<int, Vector3[]>();
    }

    // Update iscalled once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!startDraw)
            {
                startDraw = true;
            }

            if (startDraw)
            {
                tempLine = new Vector3[2];
                tempLine[0].x = Input.mousePosition.x;
                tempLine[0].y = Input.mousePosition.y;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (startDraw)
            {
                tempLine[1].x = Input.mousePosition.x;
                tempLine[1].y = Input.mousePosition.y;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (startDraw)//一条线绘制完毕
            {
                if (tempLine.Length == 2)
                {
                    index++;
                    dicOfLine.Add(index, tempLine);
                }
            }
        }
    }

    void OnPostRender()
    {
        if (!lineMaterial)
        {
            return;
        }

        lineMaterial.SetPass(0);
        GL.LoadOrtho();
        GL.Color(Color.yellow);
        GL.Begin(GL.LINES);
        int size = dicOfLine.Count;

        for (int i = 0; i < size; i++)
        {
            Vector3[] line = dicOfLine[i];
            Vector3 start = line[0];
            Vector3 end = line[1];
            DrawLine2D(start.x, start.y, end.x, end.y);
        }

        if (tempLine != null)
        {
            Vector3 start = tempLine[0];
            Vector3 end = tempLine[1];
            DrawLine2D(start.x, start.y, end.x, end.y);
        }

        GL.End();
    }

    void DrawLine2D(float x1, float y1, float x2, float y2)
    {
        GL.Vertex(new Vector3(x1 / Screen.width, y1 / Screen.height, 0));
        GL.Vertex(new Vector3(x2 / Screen.width, y2 / Screen.height, 0));
    }
}
