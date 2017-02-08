/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: ViewController.cs
  Author:王露       Version :1.0          Date: 2016-8-4
  Description:人物视角调整
************************************************************/
using UnityEngine;
using System.Collections;

public class ViewController : MonoBehaviour 
{
    public UISlider bar;//滑动条    

    private static ViewController instance;

    public static ViewController GetInstance() 
    {
        return instance;
    }

    void Awake() 
    {
        if (instance == null)
            instance = this;
    }

    void Update()
    {
        if (isPressUp)
        {
            MouseLook mouseLook = Camera.main.gameObject.GetComponent<MouseLook>();
            Vector3 vector = Camera.main.gameObject.transform.localPosition;

            if (vector.y <= mouseLook.highY)
                Camera.main.gameObject.transform.Translate(Vector3.up * Time.deltaTime * mouseLook.step, Space.World);
        }

        if (isPressDown)
        {
            MouseLook mouseLook = Camera.main.gameObject.GetComponent<MouseLook>();
            Vector3 vector = Camera.main.gameObject.transform.localPosition;

            if (vector.y >= mouseLook.shortY)
                Camera.main.gameObject.transform.Translate(Vector3.down * Time.deltaTime * mouseLook.step, Space.World);
        }
    }

    bool isPressUp = false;
    bool isPressDown = false;

    /// <summary>
    /// 长按上移。
    /// </summary>
    public void OnPressUP()
    {
        isPressUp = true;
    }

    /// <summary>
    /// 长按下降。
    /// </summary>
    public void OnPressDown()
    {
        isPressDown = true;
    }

    /// <summary>
    /// 长按释放。
    /// </summary>
    public void Release()
    {
        isPressUp = false;
        isPressDown = false;
    }

    /// <summary>
    /// 滑动条。
    /// </summary>
    public void ScrollChanged()
    {
        if (bar == null)
            return;

        if (UICamera.hoveredObject && UICamera.hoveredObject.name.Equals("Slider"))
        {
            MouseLook mouseLook = Camera.main.gameObject.GetComponent<MouseLook>();
            Camera.main.fieldOfView = Mathf.Clamp(50 - 40 * (1 - bar.value), mouseLook.minFOV, mouseLook.maxFOV);
        }
    }

    /// <summary>
    /// 给滑动条赋值。
    /// </summary>
    /// <param name="value">Value.</param>
    public void SetBarValue(float value)
    {
        if (bar == null)
            return;

        bar.value = value;
    }
}
