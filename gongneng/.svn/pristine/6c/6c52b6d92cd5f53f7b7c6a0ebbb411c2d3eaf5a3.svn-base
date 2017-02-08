using UnityEngine;
using System.Collections;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instace;

    private GameObject tempobj;
    private bool hoverUI = false;

    private void Awake()
    {
        instace = this;
    }
    public static Tooltip GetInstance()
    {
        return instace;
    }
    private void Start()
    {
        gameObject.GetComponent<UISprite>().alpha = 0;
    }
    private void Update()
    {
        if(UICamera.hoveredObject)
        {
            if(UICamera.hoveredObject.tag.Equals( "Chinesebt" ))
            {
                tempobj = UICamera.hoveredObject;
                HoverUI( tempobj );
            }
        }
        else
        {
            if(tempobj)
            {
                OverUI();
                tempobj = null;
            }
        }
        if(hoverUI)
        {
            CalPosition();
        }
    }
    /// <summary>
    /// 计算位置
    /// </summary>
    private void CalPosition()
    {
        float rate = transform.root.GetComponent<UIRoot>().manualHeight / 598f;
        Vector3 relv = tempobj.transform.position;
        Vector3 ps = Camera.main.WorldToScreenPoint(relv);
        ps.z = 0;
        Vector3 uipos = tempobj.transform.localPosition;
        float relposition = uipos.x - tempobj.GetComponent<UISprite>().width / 2 + transform.GetComponent<UISprite>().width;

        if (relposition > Screen.width * rate / 2)
        {
            transform.GetComponent<UISprite>().pivot = UIWidget.Pivot.TopRight;
        }
        else
        {
            transform.GetComponent<UISprite>().pivot = UIWidget.Pivot.TopLeft;
        }
        Vector3 pos = UICamera.mainCamera.ScreenToWorldPoint(relv);
        transform.position = relv;
    }
    /// <summary>
    /// 鼠标放到UI上
    /// </summary>
    public void HoverUI( GameObject gamobj )
    {
        string labeltext = gamobj.name;
        transform.GetChild( 0 ).GetComponent<UILabel>().text = labeltext;
        hoverUI = true;
        transform.GetComponent<TweenScale>().PlayForward();
        transform.GetComponent<TweenColor>().PlayForward();
    }
    /// <summary>
    /// 鼠标离开UI
    /// </summary>
    public void OverUI()
    {
        hoverUI = false;
        transform.GetComponent<TweenScale>().PlayReverse();
        transform.GetComponent<TweenColor>().PlayReverse();
    }
}
