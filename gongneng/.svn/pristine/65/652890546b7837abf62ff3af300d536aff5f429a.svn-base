using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public bool isZero = true;
	public bool isCamera = false;//是否是挂在Main Camera上
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;
	
	public float minSensitivityX = 0.5F;
	public float maxSensitivityX = 9.5F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	//摄像机的高度
	public float shortY = 0;//最低高度 localPosition.y
	public float highY = 1;//最高高度  localPosition.y
	public float step = 0.1f;//摄像机高度 改变速度
	
	//摄像机的Field Of View
	public float minFOV = 10;//field of view 最小值
	public float maxFOV = 50;//field of view 最大值
	public float speed = 5;//field of view改变速度
	
	private bool isPress = false;
	private Vector3 currentObj;
	private float temp;
	
	private float flactorFOV;//field of view的计算因子
	private float flactorDistance;//距离的计算因子
	private float flactorSlider;//Slider的计算因子
	
	float rotationY = 0F;
	
	void Awake ()
	{
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	Ray ray;
	RaycastHit hit;
	void Update ()
	{
		if(Input.GetMouseButtonDown(1))
		{
			isPress = true;
		}
		
		if(Input.GetMouseButtonUp(1))
		{
			isPress = false;
		}
		
		//摄像机升高
		if(Input.GetKey(KeyCode.Equals) && isCamera)
		{
			Vector3 vector = this.gameObject.transform.localPosition;
			if(vector.y <= highY)
				Camera.main.gameObject.transform.Translate(Vector3.up*Time.deltaTime*step,Space.World);
		}
		
		//摄像机降低
		if(Input.GetKey(KeyCode.Minus) && isCamera)
		{
			Vector3 vector = this.gameObject.transform.localPosition;
			if(vector.y >= shortY)
				Camera.main.gameObject.transform.Translate(Vector3.down*Time.deltaTime*step,Space.World);
		}
		
		if(isPress)
		{
			if (axes == RotationAxes.MouseXAndY)
			{
				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
				
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			else if (axes == RotationAxes.MouseX)
			{
				transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

				if(isZero)
					transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
				else
					transform.localEulerAngles = new Vector3(14-rotationY, transform.localEulerAngles.y, 0);
			}
		}

        //更新field of view并且动态修改旋转角度，以便仔细观察目标物体
        if (isCamera && Input.GetAxis("Mouse ScrollWheel") != 0 && UICamera.hoveredObject == null)
        {
            UpdateFOV();
        }
    }

    /// <summary>
    /// 计算fieldOfView。
    /// </summary>
    private void UpdateFOV()
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * speed, minFOV, maxFOV);

        if (ViewController.GetInstance() != null)
        {
            ViewController.GetInstance().SetBarValue(Mathf.Clamp01((Camera.main.fieldOfView - minFOV) * ((float)1 / (maxFOV - minFOV))));
        }
    }
}