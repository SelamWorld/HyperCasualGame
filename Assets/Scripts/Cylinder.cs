using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    private bool _Filled;
    private float _Value;
    
    public void IncrementCylinderVolume(float value){
        _Value += value;
        // Silindirin boyutunu 1 yap 1 den büyükse fazlalýk deðere göre yeni silindir koy
        if (_Value > 1)
        {
            float Leftval = _Value - 1;     
            // cilinir sayýsýný karakter scriptinden çek
            int cylinderCount=CharMove.CurrentPC.Cylinders.Count;          
            
            // cilindirlerin konumunu ayarla  
            transform.localPosition= new Vector3(transform.localPosition.x,-0.5f* (cylinderCount-1)-0.25f, transform.localPosition.z);
            // silindirin max büyüklük oranýný ayarla
            transform.localScale = new Vector3(0.5f, transform.localScale.y, 0.5f);
            CharMove.CurrentPC.CreateCylinder(Leftval);
            
                                                                                       
        }
        // silindiri yoket
        else if (_Value < 0)
        {
            CharMove.CurrentPC.DestroyCylinder(this);
            

        }
        // silindirin boyutunu güncelle
        else{
            // cilinir sayýsýný karakter scriptinden çek
            int cylinderCount = CharMove.CurrentPC.Cylinders.Count;
            // cilindirlerin konumunu ayarla  
            transform.localPosition = new Vector3(transform.localPosition.x, -0.5f*(cylinderCount - 1) - 0.25f*_Value, transform.localPosition.z);
            // silindirin büyüklük oranýný ayarla
            
            transform.localScale = new Vector3(0.5f * _Value, transform.localScale.y, 0.5f * _Value);
        }

    }
}
