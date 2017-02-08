/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: Loading.cs
  Author:王露       Version :1.0          Date: 2016-11-22
  Description:异步加载场景
************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
    public UIProgressBar bar;//进度条

    private AsyncOperation async;//异步对象
    private float tempProcess;

    private static Loading instance;
    public static Loading GetInstance() 
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
        StartCoroutine(loadScene());
    }
	
    void Update () 
    {
        if (async.progress < 0.9f)
            bar.value = async.progress;//坑爹的progress，最多到0.9f
        else
        {
            tempProcess += 0.01f;
            bar.value = tempProcess + 0.9f;
        }

        if ((100 * bar.value) >= 100)//async.isDone应该是在场景被激活时才为true
        {
            async.allowSceneActivation = true;
        }
    }

    //注意这里返回值一定是 IEnumerator
    private IEnumerator loadScene()
    {
        //异步读取场景。
        //StaticClass.LoadName 就是A场景中需要读取的C场景名称。
        async = SceneManager.LoadSceneAsync(StaticClassScene.LoadName);
        async.allowSceneActivation = false;
        //读取完毕后返回， 系统会自动进入C场景
        yield return async;
    }
}
