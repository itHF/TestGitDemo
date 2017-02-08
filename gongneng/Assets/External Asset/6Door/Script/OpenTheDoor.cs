using UnityEngine;
using System.Collections;

public class OpenTheDoor : MonoBehaviour 
{
    public float Eurlar;
    private bool Open = false;

    private int close = 0;
    public void TriggerExit()
    {
        close = 1;
    }
    public void BeginOpen()
    {
        if (!Open)
        {
            Vector3 addEurlar = new Vector3(0, Eurlar, 0);
            Hashtable args = new Hashtable();
            args.Add("amount", addEurlar);
            args.Add("easeType", iTween.EaseType.easeInOutQuad);
            args.Add("time", 0.1f);
            args.Add("oncomplete", "Opened");
            iTween.RotateAdd(gameObject, args);
        }
    }
    private void Opened()
    {
        Open = true;
        if (close == 1)
        {
            BeginClose();
        }
    }
    public void BeginClose()
    {
        if (Open)
        {
            Vector3 addEurlar = new Vector3(0, -Eurlar, 0);
            Hashtable args = new Hashtable();
            args.Add("amount", addEurlar);
            args.Add("easeType", iTween.EaseType.easeInOutQuad);
            args.Add("time", 0.1f);
            args.Add("oncomplete", "Closed");
            iTween.RotateAdd(gameObject, args);
        }
    }
    private void Closed()
    {
        close = 0;
        Open = false;
    }
}
