/************************************************************
  Copyright (C), 2007-2016,BJ Rainier Tech. Co., Ltd.
  FileName: CameraMoveControl.cs
  Author: 裴超琦       Version :1.0          Date: 2016年03月23日
  Description:  相机移动控制类
************************************************************/

using UnityEngine;
using System.Collections;

public class CameraMoveControl : MonoBehaviour
{
    private static CameraMoveControl instace;

    //视角关注物体
    public GameObject viewObj;
    public Vector3 CenterPoint;
    private GameObject last_viewpoint;

    //最小距离
    public float minDistance = 0.5f;
    //最大距离
    public float maxDistance = 10;

    //旋转速度
    public float rotateSpeed=2;
    //平移速度
    public float translatespeed=2;

    //x方向旋转
    private float roatatex;
    //y方向旋转
    private float roatatey;

    //拉近标识
    private bool Lerp = false;
    public float distance = 3f;
    private bool StopMouse = false;

    //限制最小角度
    public float limitMineuler = 0f;
    //限制最大角度
    public float limitMaxeuler = 80f;
    //射线
    private Ray ray;
    //射线信息
    private RaycastHit hitInfo;
    private Vector3 moveTargetPos;
    private Vector3 moveTargetRot;
    void Awake()
    {
        instace = this;
        CenterPoint = viewObj.transform.position;
    }
    
    public void UpdateViewObject()
    {
        CenterPoint = viewObj.transform.position;
    }

    public static CameraMoveControl GetInstance()
    {
        return instace;
    }
    public void Update()
    {
        if (UICamera.hoveredObject != null)
            return;

        // 滑动鼠标滚轮 平滑移动
        ViewPointLerp();

        // 视角控制旋转  youjian 拖动平滑移动
        ViewPointrotate();

        // 鼠标滚轮按住平移
        ViewPointMoveTranslate();  
    }

    /// <summary>
    /// 滑动鼠标滚轮 平滑移动
    /// </summary>
    private void ViewPointLerp()
    {
        if (!Lerp)
        {
            distance -= Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            CameraMove( CenterPoint );
        }
    }
      
    /// <summary>
    /// 视角控制旋转  拖动平滑移动
    /// </summary>
    private void ViewPointrotate()
    {
        if (Input.GetMouseButton(0) && !StopMouse)
        {
            roatatex = Input.GetAxis("Mouse X") * Time.deltaTime * 360;
            transform.RotateAround(CenterPoint, Vector3.up, roatatex);
            roatatey = -Input.GetAxis("Mouse Y") * Time.deltaTime * 180;
            roatatey = Mathf.Clamp( transform.eulerAngles.x + roatatey , limitMineuler , limitMaxeuler ) - transform.eulerAngles.x;
            if(roatatey > 80)
            {
                roatatex = 80;
            }

            if(roatatey < 0)
            {
                roatatex = 0;
            }
            transform.RotateAround( CenterPoint , transform.right , roatatey );
        }
        else if (Input.GetMouseButtonUp(0) && !StopMouse)
        {
            StopAllCoroutines();
            StartCoroutine( DampRotate( roatatex , roatatey ) );
            roatatex = 0;
            roatatey = 0;
        }
    }

    /// <summary>
    /// 鼠标滚轮按住平移
    /// </summary>
    private void ViewPointMoveTranslate()
    {
        if (Input.GetMouseButton(2))
        {
            //相机平移
            transform.transform.Translate(transform.right * translatespeed * Time.deltaTime * Input.GetAxis("Mouse X") * -1, Space.World);
            transform.transform.Translate(transform.up * translatespeed * Time.deltaTime * Input.GetAxis("Mouse Y") * -1, Space.World);
            //目标点平移           
            
            float transX = translatespeed * Time.deltaTime * Input.GetAxis( "Mouse X" ) * -1;
            float transY = translatespeed * Time.deltaTime * Input.GetAxis( "Mouse Y" ) * -1;

            Vector3 transxve3 = transform.right.normalized * transX;
            Vector3 transyve3 = transform.up.normalized * transY;

            //CenterPoint = new Vector3( CenterPoint.x + transX , CenterPoint.y + transY , CenterPoint.z );

            //中心点位置设置
            CenterPoint = CenterPoint + transxve3 + transyve3;
        }
    }

    public void Mouse_Stop()
    {
        StopMouse = true;
    }
    public void Mouse_Begin()
    {
        StopMouse = false;
    }   

    /// <summary>
    /// 射线检测
    /// </summary>
    private void RayCheck()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo,1000f, 1 << LayerMask.NameToLayer("CenterObj")))
        {
            if (Input.GetMouseButtonUp(1))
            {
                if (last_viewpoint)
                {
                    Destroy(last_viewpoint);
                }
                last_viewpoint=new GameObject("ViewPoints");
                last_viewpoint.transform.position=hitInfo.point;
                viewObj = last_viewpoint;
           }
        }
    }

    /// <summary>
    /// 平滑旋转减速
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private IEnumerator DampRotate(float x, float y)
    {
        int xi = 1;
        int yi = 1;
        if (x >= 0)
        {
            xi = 1;
        }
        else
        {
            xi = -1;
        }
        if (y >= 0)
        {
            yi = -1;
        }
        else
        {
            yi = 1;
        }
        while ((x > -20f && x < 20) && (y > -20 && y < 20f) && !Input.GetMouseButtonDown(0))
        {
            x = Mathf.Abs(x);
            y = Mathf.Abs(y);
            x -= Time.deltaTime * 10f;
            y -= Time.deltaTime * 10f;
            if (Mathf.Abs(x) < 1f && Mathf.Abs(y) < 1f)
            {
                break;
            }
            transform.RotateAround( CenterPoint , Vector3.up , x * xi );
            float temprotatey = -y * yi;
            temprotatey = Mathf.Clamp( transform.eulerAngles.x + temprotatey , limitMineuler , limitMaxeuler ) - transform.eulerAngles.x;
            transform.RotateAround( CenterPoint , transform.right , temprotatey );
            if(transform.localEulerAngles.x < limitMineuler)
            {
                Vector3 veceuler= transform.localEulerAngles;
                transform.localEulerAngles = new Vector3( 0 , veceuler.y , veceuler.z );
                StopAllCoroutines();
            }
            if(transform.localEulerAngles.x > limitMaxeuler)
            {
                Vector3 veceuler = transform.localEulerAngles;
                transform.localEulerAngles = new Vector3( 80 , veceuler.y , veceuler.z );
                StopAllCoroutines();
            }
            yield return 0;
        }
        yield return 0;
    }

    /// <summary>
    /// 将函数放置到Update函数中
    /// 默认的距离为X：0f  Y：0f  Z：0.2f
    /// </summary>
    /// <param name="camera">相机对象</param>
    /// <param name="target">要移动到的位置</param>
    public void CameraMove(Vector3 target)
    {
        //求目标物体 与挂脚本物体的向量
        Vector3 direction = target - transform.position;
        //想要到达的位置
        Vector3 wantedPosition = target - direction.normalized * distance * translatespeed;
        //通过vector3的 Lerp 进行平滑移动    
        transform.position = Vector3.Lerp( transform.position , wantedPosition , 2.0f * Time.deltaTime );
        //使用Quaternion.LookRotation  获取一帧中  目标和相机的四元数的值
        Quaternion rotate = Quaternion.LookRotation( target - transform.position );
        //将相机的四元数的值进行平滑设置    
        transform.rotation = Quaternion.Slerp( transform.rotation , rotate , Time.deltaTime * 3.0f );
    }

    /// <summary>
    /// 执行相机移动动画
    /// </summary>
    /// <param name="targetPos"></param>
    public void BeginCameraMove(Vector3 targetPos,Vector3 targetRot)
    {
        StopAllCoroutines();
        SetItweenInfoToAnimator( targetPos , targetRot );
    }
    /// <summary>
    /// 设置Itween 信息， 同时执行Itween
    /// </summary>
    /// <param name="targetPos"></param>
    /// <param name="targetRot"></param>
    private void SetItweenInfoToAnimator( Vector3 targetPos , Vector3 targetRot )
    {
        Hashtable args = new Hashtable();
        args.Add( "easeType" , iTween.EaseType.easeOutCubic );
        //移动的整体时间。如果与speed共存那么优先speed
        args.Add( "time" , 2f );
        args.Add( "oncomplete" , "ToAnimatorOver" );
        args.Add( "position" , targetPos );
        Hashtable args1 = new Hashtable();
        args1.Add( "easeType" , iTween.EaseType.easeOutCubic );
        //移动的整体时间。如果与speed共存那么优先speed
        args1.Add( "time" , 2f );
        args1.Add( "rotation" , targetRot );
        iTween.MoveTo( gameObject , args );
        iTween.RotateTo( gameObject , args1 );
    }
   
    /// <summary>
    /// 相机平滑移动
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool CameraMoveing(Vector3 target,Vector3 targetrota)
    {
        Vector3 direction = target - transform.position;
        //平滑移动
        transform.position = Vector3.Lerp(transform.position, target, 2.0f * Time.deltaTime);
        Quaternion rotate = Quaternion.LookRotation(targetrota);
        //平滑转向
        transform.localEulerAngles=Vector3.Slerp(transform.localEulerAngles,targetrota, Time.deltaTime * 3.0f);

        if (Vector3.Distance(target, transform.position) < 0.1f && Vector3.Angle(transform.localEulerAngles, targetrota) < 10f)
        {
            Vector3 vectora = CenterPoint - transform.position;
            Vector3 vectorb = transform.forward;
            viewObj.transform.position = transform.position + Vector3.Project(vectora, vectorb);
            distance = Vector3.Distance(viewObj.transform.position, transform.position);
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// 相机移动到观察点
    /// </summary>
    public void BeginCameraMoveToLookPoint( Vector3 targetPos , Vector3 targetRot )
    {
        StopAllCoroutines();
        SetItweenInfo( targetPos , targetRot );
    }
    /// <summary>
    /// 设置Itween 信息， 同时执行Itween
    /// </summary>
    /// <param name="targetPos"></param>
    /// <param name="targetRot"></param>
    private void SetItweenInfo( Vector3 targetPos , Vector3 targetRot )
    {
        Hashtable args = new Hashtable();
        args.Add( "easeType" , iTween.EaseType.easeOutCubic );
        //移动的整体时间。如果与speed共存那么优先speed
        args.Add( "time" , 2f );
        args.Add( "oncomplete" , "GameObjMoveOver" );
        args.Add( "position" , targetPos );
        Hashtable args1 = new Hashtable();
        args1.Add( "easeType" , iTween.EaseType.easeOutCubic );
        //移动的整体时间。如果与speed共存那么优先speed
        args1.Add( "time" , 2f );
        args1.Add( "rotation" , targetRot );
        iTween.MoveTo( gameObject , args );
        iTween.RotateTo( gameObject , args1 );
    }
}
