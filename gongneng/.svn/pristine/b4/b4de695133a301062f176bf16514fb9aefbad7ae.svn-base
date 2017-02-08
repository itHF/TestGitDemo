/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: DrawLine.cs
  Author:王露       Version :1.0          Date: 2016-8-4
  Description:Excel生成的数据图动态显示。
************************************************************/
using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour 
{
    public Color lineColor;//动态线的颜色
    public UITexture line;//动态线
    public float intervalTime = 0.005f;//间隔时间

    private float tempFillAmount = 0;//临时的FillAmount

    private static DrawLine instance;

    public static DrawLine GetInstance() 
    {
        return instance;
    }

    void Awake() 
    {
        if (instance == null)
            instance = this;
    }

    void Start () 
    {
        StartDrawLine();
    }

    /// <summary>
    /// 开始画线。
    /// </summary>
    public void StartDrawLine()
    {
        line.fillAmount = 0;
        line.color = lineColor;
        tempFillAmount = 0;
        InvokeRepeating("Line", 0, intervalTime);
    }

    /// <summary>
    /// 动态画线。
    /// </summary>
    private void Line()
    {
        if (tempFillAmount > 1)
        {
            CancelInvoke("Line");
            Debug.Log("画线结束");
            return;
        }

        tempFillAmount += 0.001f;
        line.fillAmount = tempFillAmount;
    }
}
