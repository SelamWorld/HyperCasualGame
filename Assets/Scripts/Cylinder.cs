using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    private bool _Filled;
    private float _Value;
    
    public void IncrementCylinderVolume(float value){
        _Value += value;
        if (_Value > 1)
        {
            // Silindirin boyutunu 1 yap 1 den büyükse yeni silindir koy
        }
        // silindiri yoket
        else if (_Value < 0)
        {


        }
        // silindirin boyutunu güncelle
        else{
            
        }

    }
}
