/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: CreateAssetBundle
  Author:王露       Version :1.0          Date: 2015-12-18
  Description:AssetBundle打包---异步
************************************************************/
using UnityEngine;
using UnityEditor;

public class CreateAssetBundle: Editor
{
	/// <summary>
	/// 打包一个预设。
	/// </summary>
	[MenuItem("Custom Editor/Create AssetBundles Solo")]
	static void CreateAssetBundlesSolo()
	{
		Caching.CleanCache ();
		Object[] selectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
		string targetPath = string.Empty;

		foreach(Object obj in selectedAsset)
		{
			targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
			
			if(BuildPipeline.BuildAssetBundle(obj, null, targetPath, BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.CollectDependencies))
			{
				Debug.Log(obj.name + "资源打包成功");
			}
			else
			{
				Debug.Log(obj.name + "资源打包失败");
			}
		}
		
		AssetDatabase.Refresh ();
	}

	/// <summary>
	/// 打包所有预设。
	/// </summary>
	[MenuItem("Custom Editor/Create AssetBundles All")]
	static void CreateAssetBundlesAll()
	{
		Caching.CleanCache ();
		
		Object[] selectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
		string targetPath = Application.dataPath + "/StreamingAssets/All.assetbundle";
		
		foreach(Object obj in selectedAsset)
		{
			Debug.Log("Create AssetBundles name: " + obj.name);
		}
		
		if(selectedAsset.Length > 0)
		{
			if(BuildPipeline.BuildAssetBundle(null, selectedAsset, targetPath, BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.CollectDependencies))
			{
				Debug.Log("资源打包成功");
				AssetDatabase.Refresh ();
			}
			else
			{
				Debug.Log("资源打包失败");
			}
		}
	}

	/// <summary>
	/// 打包一个场景。
	/// </summary>
	[MenuItem("Custom Editor/Create Scene")]
	static void CreateScene ()
	{
		//清空一下缓存
		Caching.CleanCache();
        Object[] selectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        string Path = Application.dataPath + "/StreamingAssets/" + selectedAsset[0].name + ".unity3d";
		//打包场景
		string[] Levels = { "Assets/External Asset/25DynamicLoading/Scene/" + selectedAsset[0].name + ".unity"};
		BuildPipeline.BuildPlayer (Levels, Path, BuildTarget.WebPlayer, BuildOptions.BuildAdditionalStreamedScenes);
		AssetDatabase.Refresh ();
		Debug.Log(selectedAsset[0].name + "场景打包结束");
	}
}