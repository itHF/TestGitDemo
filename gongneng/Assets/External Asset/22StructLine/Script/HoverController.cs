using UnityEngine;
using System.Collections;

public class HoverController : MonoBehaviour
{
    public GameObject structPanel;
    public UILabel structLabel;//属性显示
    public DrawStructLine drawLine;
    public Transform mousePoint;//鼠标位置
    
    private static HoverController instance;

    public static HoverController GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    Ray ray;
    RaycastHit hit;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.gameObject.tag.Equals("YQ"))
            {
                OnHover(hit.collider.gameObject.name.ToString());
            }
        }
        else
        {
            drawLine.CancelLine();

            if(structPanel.activeInHierarchy)
                structPanel.SetActive(false);
        }
    }

    /// <summary>
    /// 悬浮显示属性
    /// </summary>
    /// <param name="hitName"></param>
    public void OnHover(string hitName)
    {
        if (structPanel.activeInHierarchy)
            return;

        structPanel.SetActive(true);
        Vector3 screen = Camera.main.WorldToScreenPoint(hit.collider.gameObject.transform.position);
        screen.z = 0;
        structLabel.text = hitName;
        mousePoint.position = UICamera.currentCamera.ScreenToWorldPoint(screen);
        drawLine.SetLine(screen, UICamera.currentCamera.WorldToScreenPoint(structLabel.gameObject.transform.position));
    }
}
