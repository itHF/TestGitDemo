using UnityEngine;
using System.Collections;

public class DoorTrriger_pcq : MonoBehaviour 
{
    public GameObject[] TaigetDoor;
   void OnTriggerEnter(Collider other) 
   {
        for (int i  = 0; i  < TaigetDoor.Length; i ++)
        {
            TaigetDoor[i].GetComponent<OpenTheDoor>().BeginOpen();
        }
    }

   void OnTriggerExit(Collider other)
   {
       for (int i = 0; i < TaigetDoor.Length; i++)
       {
           TaigetDoor[i].GetComponent<OpenTheDoor>().BeginClose();
       }
      
   }
}
