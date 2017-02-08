/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: ScreenShot.cs
  Author:罗克诚       Version :1.0          Date: 2016-8-6
  Description:截图
************************************************************/
using System.IO;
using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour
{
    public void StartScreenShot()
    {
        StartCoroutine(UploadPNG());
    }

    /// <summary>
    /// 截图功能。
    /// </summary>
    /// <returns></returns>
    private IEnumerator UploadPNG()
    {
        yield return new WaitForEndOfFrame();
        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();

#if UNITY_EDITOR
        File.WriteAllBytes(Application.dataPath + "/External Asset/19ScreenShot/ScreenShot.png", bytes);
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}
