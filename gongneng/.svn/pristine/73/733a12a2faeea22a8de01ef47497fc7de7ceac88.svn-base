/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: DataTransfer.cs
  Author:王露       Version :1.0          Date: 2016-8-8
  Description:和平台数据交互
************************************************************/
using UnityEngine;
using System.Collections;

public class DataTransfer : MonoBehaviour 
{
    private static DataTransfer instance;

    public static DataTransfer GetInstance() 
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
        Application.ExternalCall("setScriptFromPlugin");          //通知web平台unity已经加载完成，可以接受数据了
    }

    /// <summary>
    /// 编写数据传入代码(web->unity3d)
    /// </summary>
    /// <param name="info"></param>
    public void getStrFromPlatform(string info)
    {
          ///info就是传入的实验配置数据了
    }

    /// <summary>
    /// 编写数据传出代码(unity3d->web)
    /// </summary>
    public void sendToPlatform()
    {
          Application.ExternalCall("getScriptFromPlugin", "我是要传出的数据");
    }

}
