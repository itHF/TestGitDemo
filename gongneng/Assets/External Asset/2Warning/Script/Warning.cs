/************************************************************
  Copyright (C), 2007-2015,BJ Rainier Tech. Co., Ltd.
  FileName: Warning.cs
  Author:王露       Version :1.0          Date: 2015-12-28
  Description:警告处理
************************************************************/

using UnityEngine;
using System.Collections;

public class Warning : MonoBehaviour
{
	public GameObject warnPanel;
	public UILabel warn;

	private static Warning instance;
	public static Warning GetInstance()
	{
		return instance;
	}

	void Awake ()
	{
        if (instance == null)
            instance = this;
	}

	/// <summary>
	/// 显示警告。
	/// </summary>
	/// <param name="str">警告内容.</param>
	public void ShowWarn(string str)
	{
		if(IsInvoking("HideWarn"))
			CancelInvoke("HideWarn");

		warn.text = str;
		warnPanel.SetActive (true);
		Invoke ("HideWarn", 3);
	}

    /// <summary>
    /// 显示警告。
    /// </summary>
    /// <param name="str">警告内容.</param>
    public void ShowWarnNoClose(string str)
    {
        if (IsInvoking("HideWarn"))
            CancelInvoke("HideWarn");

        warn.text = str;
        warnPanel.SetActive(true);
    }

    /// <summary>
    /// 几秒之后隐藏。
    /// </summary>
    /// <param name="str"></param>
    /// <param name="time"></param>
    public void ShowWarnTime(string str, float time)
	{
		if(IsInvoking("HideWarn"))
			CancelInvoke("HideWarn");

		warn.text = str;
		warnPanel.SetActive (true);
		Invoke ("HideWarn", time);
	}

	/// <summary>
	/// 显示警告，并有延时。
	/// </summary>
	/// <param name="str">警告内容.</param>
	public void ShowWarnDelay(string str, float delay)
	{
		warn.text = str;
		Invoke ("ShowWarnDelay", delay);
	}
    
	/// <summary>
	/// 隐藏警告。
	/// </summary>
	public void HideWarn()
	{
		warnPanel.SetActive (false);
	}

    /// <summary>
    /// 立即隐藏警告框。
    /// </summary>
	public void HideWarnNow()
	{
		CancelInvoke ("HideWarn");
		warnPanel.SetActive (false);
	}
}
