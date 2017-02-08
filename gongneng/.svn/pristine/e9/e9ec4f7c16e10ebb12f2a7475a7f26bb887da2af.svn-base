/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: SwitchScene.cs
  Author:王露       Version :1.0          Date: 2016-10-19
  Description:跳转场景
************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string sceneName;//跳转过去的场景

    /// <summary>
    /// 点击跳转场景。
    /// </summary>
    public void ClickSwitchScene()
    {
        StaticClassScene.LoadName = sceneName;
        SceneManager.LoadScene("Load");
        //SceneManager.LoadScene(sceneNumber);
    }
}
