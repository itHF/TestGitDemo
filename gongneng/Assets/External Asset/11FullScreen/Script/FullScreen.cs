/************************************************************
  Copyright (C), 2007-2015,BJ Rainier Tech. Co., Ltd.
  FileName: FullScreen.cs
  Author:王露       Version :1.0          Date: 2015-4-20
  Description:全屏
************************************************************/

using UnityEngine;
using System.Collections;

public class FullScreen : MonoBehaviour
{
    public void FullScreenClick()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(980, 596, false);
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
    }

    void Update()
  {
    if(Screen.fullScreen)
    {
      if(this.gameObject.GetComponent<UIButton>().normalSprite == "minfull1")
        return;
      else
      {
        this.gameObject.GetComponent<UISprite>().spriteName = "minfull1";
        this.gameObject.GetComponent<UIButton>().normalSprite = "minfull1";
        this.gameObject.GetComponent<UIButton>().hoverSprite = "minfull2";
        this.gameObject.GetComponent<UIButton>().pressedSprite = "minfull2";

      }
    }
    else
    {
      if(this.gameObject.GetComponent<UIButton>().normalSprite == "maxfull1")
        return;
      else
      {
        this.gameObject.GetComponent<UISprite>().spriteName = "maxfull1";
        this.gameObject.GetComponent<UIButton>().normalSprite = "maxfull1";
        this.gameObject.GetComponent<UIButton>().hoverSprite = "maxfull2";
        this.gameObject.GetComponent<UIButton>().pressedSprite = "maxfull2";
      }
    }
  }
}
