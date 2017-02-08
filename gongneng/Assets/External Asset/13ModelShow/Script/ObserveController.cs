/************************************************************
  Copyright (C), 2007-2015,BJ Rainier Tech. Co., Ltd.
  FileName: ObserveController.cs
  Author:罗克诚       Version :1.0          Date:2015年6月30日
  Description:  观察摄像机控制类
************************************************************/
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ObserveController : MonoBehaviour {
    public GameObject viewObj;
    public bool showMesh = true;
    public bool autoRotate = true; 
    public bool usePlayerSettings = false;
    public Color camerabgColor = new Color(0.1176f, 0.1176f, 0.1176f);
    public Color meshColor = Color.gray;
    public float minX = -20;
    public float maxX = 20;
    public float minZ = -20;
    public float maxZ = 20;
    public float minDistance = 2.0f;
    public float maxDistance = 5.0f;
	public bool isObverse = true;
	public bool isMove = false;
    public float mSpeed;//滑轮滑动速度

    //限制最小角度
    public float limitMineuler = 0f;
    //限制最大角度
    public float limitMaxeuler = 80f;

    public float distance = 3.0f;
    private Material mat;
    private TweenColor tween;
	private float x;
	private float y;

	void Start() 
	{
        if (!usePlayerSettings) 
		{
            GetComponent<Camera>().nearClipPlane = 0.01f;
            GetComponent<Camera>().farClipPlane = 100;
            GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
            GetComponent<Camera>().cullingMask = 1 << LayerMask.NameToLayer("XWJ");
            GetComponent<Camera>().backgroundColor = camerabgColor;
            GetComponent<Light>().type = LightType.Directional;
            GetComponent<Light>().intensity = 0.5f;
        }
    }

	Ray ray;
	RaycastHit hit;
    void Update() 
	{
        if (Input.GetMouseButtonUp(0))
            isMove = false;

		if (UICamera.hoveredObject && UICamera.hoveredObject.layer == 5)
			return;

		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            
            if (!Physics.Raycast(ray, out hit, 100, 1 << 8))
			{
				isMove = true;
			}
		}

		if (isMove)
		{
			transform.transform.Translate(transform.right * 2.0f * Time.deltaTime * Input.GetAxis("Mouse X") * -1, Space.World);
			transform.transform.Translate(transform.up * 2.0f * Time.deltaTime * Input.GetAxis("Mouse Y") * -1, Space.World);
		}

		if(!isObverse || isMove)
			distance = Vector3.Distance(transform.position, viewObj.transform.position);

        transform.RotateAround(viewObj.transform.position, Vector3.up, Input.GetAxis("Horizontal"));

        distance -= Input.GetAxis("Mouse ScrollWheel") * mSpeed;
		distance = Mathf.Clamp(distance, minDistance, maxDistance);
        //规范化向量
        transform.position = viewObj.transform.position + (transform.position - viewObj.transform.position).normalized * distance;

        if (Input.GetMouseButton(1))
		{
            //摄像机在X轴上的旋转
            transform.RotateAround(viewObj.transform.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * 360);

			float roatatey = -Input.GetAxis("Mouse Y") * Time.deltaTime * 180;
            //摄像机在Y轴上的旋转，不能超过(limitMineuler,limitMaxeuler)的角度范围
            roatatey = Mathf.Clamp(transform.eulerAngles.x + roatatey, limitMineuler, limitMaxeuler) - transform.eulerAngles.x;
			
            transform.RotateAround(viewObj.transform.position, transform.right, roatatey);
        }  
		else if (autoRotate) 
		{
            //偶数帧执行，防止旋转过快
            if (Time.frameCount % 2 == 0) 
			{
                transform.RotateAround(viewObj.transform.position, Vector3.up, 1);
            }
        }
    }

    public void OnToggle(bool state) 
	{
       	autoRotate = state;
    }
}