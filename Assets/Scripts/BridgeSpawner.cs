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
        
        // k�pr�n�n ba�lang�� noktas�ndan biti� noktas�n� ��kar ve bir vect�r elde et
        Vector3 Direction= EndRef.transform.position-StartRef.transform.position;
        float Distance= Direction.magnitude;        // elde edilen vekt�r�n uzunlu�u
        Direction = Direction.normalized;           // uzunlu�u bir birim yap ve y�n elde et
        Hiddenplatform.transform.forward = Direction;   // k�pr�n�n y�n�n� akt�r�n y�n� yap
        Hiddenplatform.size=new Vector3(Hiddenplatform.size.x,Hiddenplatform.size.y,Distance);  // k�p�n boyutunu ayarla
        Hiddenplatform.transform.position = StartRef.transform.position + ( Direction*Distance / 2) + (new Vector3(0, -Direction.z, Direction.y)*Hiddenplatform.size.y/2);   //k�p� ortaya getir ve �st noktas�n� platformun �st�n e�itle
    }                                                                                                           

}                                                                                                
