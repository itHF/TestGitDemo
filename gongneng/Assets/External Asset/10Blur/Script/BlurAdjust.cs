/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: BlurAdjust.cs
  Author:王露       Version :1.0          Date: 2016-8-4
  Description:模糊度调整
************************************************************/
using UnityEngine;
using System.Collections;

public class BlurAdjust : MonoBehaviour 
{
    public UITexture blur;//模糊图片--------------------注意，这个地方用UISprite也一样

    private Color currentColor;

    private static BlurAdjust instance;

    public static BlurAdjust GetInstance() 
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
        currentColor = blur.color;
    }

    /// <summary>
    /// 模糊度调整。
    /// </summary>
    /// <param name="slider"></param>
    public void BlurSliderChanged(UISlider slider)
    {
        currentColor.a = slider.value;
        blur.color = currentColor;
    }
}
