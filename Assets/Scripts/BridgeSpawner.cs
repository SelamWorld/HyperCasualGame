using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    public GameObject StartRef, EndRef;
    public BoxCollider Hiddenplatform;
    
    void Start()
    {    
        if(StartRef != null)
        {

        }
        
        // köprünün baþlangýç noktasýndan bitiþ noktasýný çýkar ve bir vectör elde et
        Vector3 Direction= EndRef.transform.position-StartRef.transform.position;
        float Distance= Direction.magnitude;        // elde edilen vektörün uzunluðu
        Direction = Direction.normalized;           // uzunluðu bir birim yap ve yön elde et
        Hiddenplatform.transform.forward = Direction;   // köprünün yönünü aktörün yönü yap
        Hiddenplatform.size=new Vector3(Hiddenplatform.size.x,Hiddenplatform.size.y,Distance);  // küpün boyutunu ayarla
        Hiddenplatform.transform.position = StartRef.transform.position + ( Direction*Distance / 2) + (new Vector3(0, -Direction.z, Direction.y)*Hiddenplatform.size.y/2);   //küpü ortaya getir ve üst noktasýný platformun üstün eþitle
    }                                                                                                           

}                                                                                                
