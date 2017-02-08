/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: AssetBundleControl
  Author:王露       Version :1.0          Date: 2015-12-18
  Description:AssetBundle读取---异步
************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AssetBundleControl: MonoBehaviour
{
    public string nextSceneName;//要跳转的场景名称
    public GameObject retryButton;//加载失败，重试按钮
    public UISlider slider;//滑动条
	public UILabel status;//状态提示

	private WWW www;
	private bool isLoading = true;//是否正在加载
	private string address;

	private static AssetBundleControl instance;
	public static AssetBundleControl GetInstance()
	{
		if (instance == null)
			instance = new AssetBundleControl ();

		return instance;
	}

	void Awake()
	{
		instance = this;
		address = "file://" + Application.dataPath + "/StreamingAssets/";//服务器网址
		//address = "file://D:\\";
	}

	void Start()
	{
		ReadScene ();
	}

	/// <summary>
	/// 读取AssetBundle。
	/// </summary>
	public void ReadScene ()
	{
        if(retryButton.activeInHierarchy)
            retryButton.SetActive(false);

        isLoading = true;
		StartCoroutine (LoadScene(address + nextSceneName + ".unity3d"));
	}

	/// <summary>
	/// 读取AssetBundle。
	/// </summary>
	public void ReadAssetBundle (string name)
	{
		isLoading = true;
		StartCoroutine (LoadAssetBundle(address + name + ".assetbundle"));
	}

	/// <summary>
	/// AssetBundle读取整个场景。
	/// </summary>
	IEnumerator LoadScene(string path)
	{
        using (www = WWW.LoadFromCacheOrDownload (path, 1)) 
        {
            yield return www;
			
			if(www.error != null)
			{
				status.text = "加载失败，请重试";
                retryButton.SetActive(true);
                yield break;
			}
			
			AssetBundle bundle = www.assetBundle;

			//加载场景
			if(bundle != null)
            {
                isLoading = false;//加载结束
                status.text = "加载成功";
			}
			else
			{
                retryButton.SetActive(true);
                status.text = "加载失败，请重试";
            }
		}
	}

	/// <summary>
	/// AssetBundle读取AssetBundle。
	/// </summary>
	IEnumerator LoadAssetBundle(string path)
	{
		using (www = WWW.LoadFromCacheOrDownload (path, 1))  
		{  
			yield return www;
			
			if(www.error != null)
			{
				status.text = "加载失败，请重试";
                retryButton.SetActive(true);
                yield break;
			}
			
			AssetBundle bundle = www.assetBundle;

			if(bundle != null)
            {
                isLoading = false;//加载结束
                status.text = "加载成功";
				//加载
				bundle.Unload(false);
			}
			else
			{
				status.text = "加载失败，请重试";
                retryButton.SetActive(true);
            }
		}
	}

	void Update()
	{
		if(isLoading && www != null)
		{
			slider.value = www.progress;

			if(www.progress >= 1)
			{
				slider.value = 1;
				isLoading = false;
			}
		}
	}

    /// <summary>
    /// 点击跳转场景。
    /// </summary>
    public void ClickSwitchScene()
    {
        if(isLoading)
        {
            status.text = "正在准备资源，请稍后";
            return;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}