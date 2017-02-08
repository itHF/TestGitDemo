/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: GLTest.cs
  Author:罗克诚       Version :1.0          Date: 2016-8-6
  Description:屏幕画线(左下角到右上角)
************************************************************/
using UnityEngine;
using System.Collections;

public class GLTest : MonoBehaviour 
{
    public Material mat;
    private static GLTest instance;

    public static GLTest GetInstance() 
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
    }

    void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }

        GL.PushMatrix(); //保存当前Matirx
        mat.SetPass(0); //刷新当前材质
        GL.LoadPixelMatrix();//设置pixelMatrix
        GL.Color(Color.yellow);
        GL.Begin(GL.LINES);
        GL.Vertex3(0, 0, 0);
        GL.Vertex3(Screen.width, Screen.height, 0);
        GL.End();
        GL.PopMatrix();//读取之前的Matrix
    }

}
