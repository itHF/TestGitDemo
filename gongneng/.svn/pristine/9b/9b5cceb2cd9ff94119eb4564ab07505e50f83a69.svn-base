/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: ExperimentIntroduction.cs
  Author:王露       Version :1.0          Date: 2016-3-31
  Description:UI控制
************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExperimentIntroduction : MonoBehaviour
{
    public string normalButtonName;//按钮正常状态图集名称
    public string clickButttonName;//按钮按下状态图集名称

    public TweenScale messagePanel;//实验步骤窗口
    public UIScrollView scroll;
    public UILabel title;
    public UISlider bar;//滑动条

    public GameObject textPrefab;//文字预设 
    public GameObject texturePrefab;//图片预设
    public Texture2D[] textureList;//图片合集

    private UISprite currentButton;
    private string normalName;
    private Dictionary<string, ArrayList> dict;//当前显示的内容合集
    private GameObject root;//当前显示内容的根物体
    private Hashtable picTable;//图片合集
    
    private static ExperimentIntroduction instance;
	public static ExperimentIntroduction GetInstance()
	{
		return instance;
	}
	
	void Awake ()
	{
		if(instance == null)
			instance = this;
	}

    void Start()
    {
        StaticClass.Init();
        picTable = new Hashtable();

        foreach (Texture2D text in textureList)
        {
            picTable.Add(text.name, text);
        }

        dict = StaticClass.paramDict;
    }
	
	//鼠标点击UI按钮响应事件
	public void OnClick(GameObject button)
	{
        //更新图片。
        if (currentButton != null && currentButton.name != button.name)
        {
            currentButton.spriteName = normalButtonName;
        }

        title.text = button.name;
        currentButton = button.GetComponent<UISprite>();
        currentButton.spriteName = clickButttonName;
        normalName = currentButton.spriteName;
        StaticClass.State = button.name;
        UpdateDisplay();
	}

    /// <summary>
    /// 关闭当前窗口。
    /// </summary>
    public void CloseWindow()
    {
        if (currentButton != null)
        {
            currentButton.spriteName = normalButtonName;
            currentButton = null;
        }

        messagePanel.PlayReverse();
    }

    /// <summary>
    /// 用代码实现信息的自动显示（图片，文字）。
    /// </summary>
    private void UpdateDisplay()
    {
        if (!dict.ContainsKey(StaticClass.State.ToString()))
            return;

        if (messagePanel.transform.localScale.x < 0.5f)
            messagePanel.PlayForward();

        ArrayList list = dict[StaticClass.State.ToString()];

        if (list != null)
        {
            if (root != null)
                Destroy(root);

            //新建一个根物体
            root = new GameObject();
            root.name = "Root";
            root.transform.parent = textPrefab.transform.parent;
            root.transform.localPosition = Vector3.zero;
            root.transform.localScale = Vector3.one;
            int Y = 94;
            string str;
            GameObject obj;

            for (int i = 0; i < list.Count; i++)
            {
                str = list[i].ToString();
                //第一个字符是0则代表是文字，第一个字符是1代表是图片
                if (str.Substring(0, 1).Equals("0"))
                {
                    //创建文字预设
                    obj = GameObject.Instantiate(textPrefab);
                    obj.name = i.ToString();
                    obj.transform.parent = root.transform;
                    obj.transform.localPosition = new Vector3(-138, Y, 0);
                    obj.transform.localScale = Vector3.one;
                    obj.GetComponent<UILabel>().text = str.Substring(2, str.Length - 2);
                    Y -= obj.GetComponent<UILabel>().height;
                    Y -= 10;
                }
                else if (str.Substring(0, 1).Equals("1"))
                {
                    //创建图片预设
                    obj = GameObject.Instantiate(texturePrefab);
                    obj.name = i.ToString();
                    obj.transform.parent = root.transform;
                    obj.transform.localPosition = new Vector3(267, Y, 0);
                    obj.transform.localScale = Vector3.one;
                    Texture2D texture = picTable[str.Substring(2, str.Length - 2)] as Texture2D;
                    obj.GetComponent<UITexture>().mainTexture = texture;

                    float angle = 1;

                    if (texture.width > 770)
                    {
                        angle = (float)(770f / texture.width);
                    }

                    obj.GetComponent<UITexture>().width = (int)(texture.width * angle);
                    obj.GetComponent<UITexture>().height = (int)(texture.height * angle);
                        
                    Y -= obj.GetComponent<UITexture>().height;
                    Y -= 10;
                }
            }

            scroll.ResetPosition();
            Invoke("UpdateScroll", 0.2f);
        }
    }

    /// <summary>
    /// 更新Slider的位置。
    /// </summary>
    private void UpdateScroll()
    {
        scroll.verticalScrollBar.ForceUpdate();
    }
}
