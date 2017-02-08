/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: ModelShowByMove.cs
  Author:王露       Version :1.0          Date: 2016-8-4
  Description:模型平移展示
************************************************************/
using UnityEngine;
using System.Collections;

public class ModelShowByMove : MonoBehaviour
{
    public GameObject currentRoot;
    public UILabel modelName;//模型名称

    private int index;//下标
    private int totalCount;//当前组模型的数量  
    private GameObject currentModel;//当前显示的模型 
    private GameObject hideModel;//需隐藏的模型

    private static ModelShowByMove instance;
    public static ModelShowByMove GetInstance() 
    {
        return instance;
    }
    void Awake() 
    {
        if (instance == null)
            instance = this;
    }
	
    void Start()
    {
        totalCount = currentRoot.transform.childCount;
        currentModel = currentRoot.transform.GetChild(0).gameObject;
    }

    /// <summary>
    /// 上一个模型。
    /// </summary>
    public void ForwardModel()
    {
        index--;

        hideModel = currentModel;

        if (IsInvoking("Hide"))
            CancelInvoke("Hide");

        Invoke("Hide", 1);

        if (index < 0)
        {
            index = totalCount - 1;

            currentRoot.transform.localPosition = new Vector3(-totalCount * 10, 0, 0);
        }

        iTween.MoveAdd(currentRoot, new Vector3(10, 0, 0), 1);
        currentModel = currentRoot.transform.GetChild(index).gameObject;
        currentModel.SetActive(true);
        modelName.text = currentModel.name;
    }

    /// <summary>
    /// 下一个模型。
    /// </summary>
    public void NextModel()
    {
        index++;

        hideModel = currentModel;

        if (IsInvoking("Hide"))
            CancelInvoke("Hide");

        Invoke("Hide", 1);

        if (index >= totalCount)
        {
            index = 0;

            currentRoot.transform.localPosition = new Vector3(10, 0, 0);
        }

        iTween.MoveAdd(currentRoot, new Vector3(-10, 0, 0), 1);
        currentModel = currentRoot.transform.GetChild(index).gameObject;
        currentModel.SetActive(true);
        modelName.text = currentModel.name;
    }

    /// <summary>
    /// 隐藏当前模型。
    /// </summary>
    private void Hide()
    {
        if (hideModel != null)
            hideModel.SetActive(false);

        hideModel = null;
    }
}