/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: OperationShow.cs
  Author:王露       Version :1.0          Date: 2016-6-15
  Description:显示操作说明
************************************************************/

using UnityEngine;
using System.Collections;

public class OperationShow : MonoBehaviour
{
    public TweenScale operatePanel;//操作说明窗口

    //静态模式
	private static OperationShow instance;
	public static OperationShow GetInstance()
	{
		return instance;
	}
	
	void Awake ()
	{
		if (instance == null)
            instance = this;
	}

    /// <summary>
    /// 弹出操作说明窗口
    /// </summary>
    public void Show()
    {
        operatePanel.PlayForward();
    }

    /// <summary>
    /// 弹出操作说明窗口
    /// </summary>
    public void Close()
    {
        operatePanel.PlayReverse();
    }
}
