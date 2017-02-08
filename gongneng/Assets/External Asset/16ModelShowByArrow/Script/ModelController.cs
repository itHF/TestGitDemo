/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: ModelController.cs
  Author:王露       Version :1.0          Date: 2016-8-4
  Description:模型展示
************************************************************/

using UnityEngine;
using System.Collections;

public class ModelController : MonoBehaviour 
{
    public UILabel modelName;
    public GameObject modelRoot;

    private GameObject[] modelList;
    private int index;
    private int totalIndex;

	private static ModelController instance;
	public static ModelController GetInstance()
	{
		return instance;
	}
	
	void Awake ()
	{
		if (instance == null)
            instance = this;
	}

    void Start()
    {
        modelList = new GameObject[modelRoot.transform.childCount];

        for (int i = 0; i < modelRoot.transform.childCount; i++)
        {
            modelList[i] = modelRoot.transform.GetChild(i).gameObject;
        }

        totalIndex = modelList.Length;
    }

    /// <summary>
    /// 下一个模型展示。
    /// </summary>
	public void NextModel()
    {
        if (index >= (totalIndex - 1))
            return;

        modelList[index].SetActive(false);

        index++;
        modelList[index].SetActive(true);
        modelName.text = modelList[index].name;
    }

    /// <summary>
    /// 上一个模型展示。
    /// </summary>
    public void ForwardModel()
    {
        if (index < 1)
            return;

        modelList[index].SetActive(false);

        index--;
        modelList[index].SetActive(true);
        modelName.text = modelList[index].name;
    }
}
