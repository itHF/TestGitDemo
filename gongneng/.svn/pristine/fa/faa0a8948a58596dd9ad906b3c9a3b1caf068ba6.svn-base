/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: TimeControl
  Author:王露       Version :1.0          Date: 2015-12-14
  Description:计时功能和倒计时功能
************************************************************/
using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour 
{
	public UILabel time;

	private int timeSecond;
	private string timeStr;

	private static TimeControl instance;
	public static TimeControl GetInstance()
	{
		return instance;
	}

	void Awake ()
	{
		instance = this;
	}

    void Start()
    {
        StartTime();
    }

	/// <summary>
	/// 重新计时。
	/// </summary>
	public void ReSet()
	{
		if(IsInvoking("ReTime"))
		{
			time.text = "00:00:00";
			timeSecond = 0;
		}
	}

	/// <summary>
	/// 开始计时。
	/// </summary>
	public void StartTime()
	{
		if (IsInvoking ("ReTime"))
			return;

		time.text = "00:00:00";
		time.gameObject.SetActive (true);
		timeSecond = 0;
		InvokeRepeating ("ReTime", 0, 1);
	}

	/// <summary>
	/// 停止计时。
	/// </summary>
	public void StopTime()
	{
		time.gameObject.SetActive (false);
		CancelInvoke ("ReTime");
	}

	/// <summary>
	/// 继续计时。
	/// </summary>
	public void ContinueTime()
	{
		if (IsInvoking ("ReTime"))
			return;

		time.gameObject.SetActive (true);
		InvokeRepeating ("ReTime", 0, 1);
	}

	/// <summary>
	/// 时间处理，必须是00:00格式.
	/// </summary>
	private void ReTime()
	{
		if(timeSecond/3600 >= 10)
			timeStr = timeSecond/3600 + ":";
		else
			timeStr = "0" + timeSecond/3600 + ":";

		if(timeSecond/60 >= 10)
			timeStr += timeSecond/60 + ":";
		else
			timeStr += "0" + timeSecond/60 + ":";
		
		if(timeSecond%60 >= 10)
			timeStr += timeSecond%60;
		else
			timeStr += "0" + timeSecond%60;
		
		time.text = timeStr;
		timeSecond++;
	}
}
