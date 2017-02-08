/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: SwitchPlace.cs
  Author:王露       Version :1.0          Date: 2016-8-2
  Description:点击小地图快速切换到位置
************************************************************/
using UnityEngine;
using System.Collections;

public class SwitchPlace : MonoBehaviour 
{
    public GameObject player;
    public float Y;

    private static SwitchPlace instance;

    public static SwitchPlace GetInstance() 
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
    	
    }

    Ray ray;
    RaycastHit hit;
    void Update () 
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 2000, 1 << 11))//Terrain层
            {
                //player.transform.position = new Vector3(hit.point.x, Y, hit.point.z);
                //Debug.Log(hit.point);
                player.transform.position = hit.point + new Vector3(0, Y, 0);// - (new Vector3(Screen.width - 980, 0, Screen.height - 596) * 0.29f)
            }
        }
    }
}
