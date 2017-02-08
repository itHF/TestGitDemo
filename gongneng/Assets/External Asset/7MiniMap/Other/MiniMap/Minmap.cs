using UnityEngine;
using System.Collections;

public class Minmap : MonoBehaviour
{
    public GameObject hero;//����

    public float walkDistance = 1;//������������������ľ���
    public float height = 1;//��������������ǵĸ߶�
    public RenderTexture minmap_texture;
    public Material minmap_material;
    private GameObject minmap_Camera;
    public float offset;
    public Texture2D gangquan;

    void Awake()
    {
        minmap_Camera = GameObject.Find("minmap_Camera");  //���温�������
        hero = GameObject.Find("hero");//��������
    }
    void Start()
    {
        //�Ҳ�������
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
        //�Ҳ�������
        if (hero == null)
            return;
        else
        Camerafowller();
    }

    //��֤���������ʱ�̸���������
    public void Camerafowller()
    {
        minmap_Camera.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y + height,
            hero.transform.position.z - walkDistance);
        minmap_Camera.transform.LookAt(hero.transform);
    }
}