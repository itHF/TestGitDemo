using UnityEngine;
using System.Collections;

public class Minmap : MonoBehaviour
{
    public GameObject hero;//主角

    public float walkDistance = 1;//俯视摄像机离主角身后的距离
    public float height = 1;//俯视摄像机离主角的高度
    public RenderTexture minmap_texture;
    public Material minmap_material;
    private GameObject minmap_Camera;
    public float offset;
    public Texture2D gangquan;

    void Awake()
    {
        minmap_Camera = GameObject.Find("minmap_Camera");  //储存俯视摄像机
        hero = GameObject.Find("hero");//储存主角
    }
    void Start()
    {
        //找不到主角
        if (hero == null)
        {
           // Debug.Log("minmap's hero is gone!");
            return;
        }
        else
            Camerafowller();
    }
    void OnGUI()
    {
        if (Event.current.type == EventType.Repaint)
        {
            Graphics.DrawTexture(new Rect(Screen.width - 245* Screen.width / 1920, 10f * Screen.height / 1080, 240 * Screen.width / 1920, 240 * Screen.height / 1080), minmap_texture, minmap_material);
            Graphics.DrawTexture(new Rect(Screen.width - 255 * Screen.width / 1920, 0f * Screen.height / 1080, 260 * Screen.width / 1920, 260 * Screen.height / 1080), gangquan);
        }
    }
    void Update()
    { 
        //找不到主角
        if (hero == null)
            return;
        else
        Camerafowller();
    }

    //保证俯视摄像机时刻跟随着主角
    public void Camerafowller()
    {
        minmap_Camera.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y + height,
            hero.transform.position.z - walkDistance);
        minmap_Camera.transform.LookAt(hero.transform);
    }
}