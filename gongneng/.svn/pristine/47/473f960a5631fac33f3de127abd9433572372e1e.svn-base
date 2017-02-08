/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: DrawStructLine
  Author:王露       Version :1.0          Date: 2015-12-11
  Description:结构识别画线
************************************************************/
using UnityEngine;

public class DrawStructLine : MonoBehaviour
{
    public Material mat;
    public bool isDraw = false;
    public bool isDrawLine = false;
    public bool isDrawActiveLine = false;//动态画线
    public Vector3 lineStart;
    public Vector3 lineEnd;
    public Vector3[] tempList;//临时线的点列表
    private Vector3 temp;

    public void SetLine(Vector3 start, Vector3 end)
    {
        lineStart = start;
        lineEnd = end;
        isDraw = true;
    }

    public void SetMultiLine(Vector3[] list)
    {
        isDrawLine = true;
        tempList = list;
    }

    public void SetActiveLine(Vector3 start, Vector3 end, Vector3 active)
    {
        lineStart = start;
        lineEnd = end;
        temp = active;
        isDrawActiveLine = true;
    }

    public void ChangeActiveLine(Vector3 active)
    {
        temp = active;
    }

    public void CancelLine()
    {
        isDraw = false;
        isDrawLine = false;
        isDrawActiveLine = false;
    }

    void OnPostRender()
    {
        if (isDraw)
        {
            mat.SetPass(0);
            GL.PushMatrix();
            GL.LoadPixelMatrix();

            GL.Begin(GL.LINES);
            GL.Color(Color.white);
            DrawLine2D(lineStart.x, lineStart.y, lineEnd.x, lineEnd.y);
            GL.End();

            GL.PopMatrix();
        }
        else if (isDrawLine)
        {
            mat.SetPass(0);
            GL.PushMatrix();
            GL.LoadPixelMatrix();

            GL.Begin(GL.LINES);
            GL.Color(Color.white);

            for (int l = 0; l < tempList.Length - 1; l++)
            {
                if (l == 2 || l == 5 || l == 8 || l == 11)
                    continue;
                Vector3 start = tempList[l];
                Vector3 end = tempList[l + 1];
                DrawLine2D(start.x, start.y, end.x, end.y);
            }

            GL.End();
            GL.PopMatrix();
        }
        else if (isDrawActiveLine)
        {
            mat.SetPass(0);
            GL.PushMatrix();
            GL.LoadPixelMatrix();

            GL.Begin(GL.LINES);
            GL.Color(Color.white);
            DrawLine2D(lineStart.x, lineStart.y, lineEnd.x, lineEnd.y);
            DrawLine2D(lineEnd.x, lineEnd.y, temp.x, temp.y);
            GL.End();

            GL.PopMatrix();
        }
    }

    void DrawLine2D(float x1, float y1, float x2, float y2)
    {
        GL.Vertex3(x1, y1, 0);
        GL.Vertex3(x2, y2, 0);
    }
}
