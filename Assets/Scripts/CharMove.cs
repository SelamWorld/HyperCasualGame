using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
public  float CharSpeed,xSpeed;
public float limitX;                   
private  float _CurrentCharSpeed;
    
    void Start()
    {
        _CurrentCharSpeed = CharSpeed;
        
    }

    
    void Update()
    {
        float newX = 0;
        float touchXDelta=0;
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved){
            touchXDelta = Input.GetTouch(0).deltaPosition.x/Screen.width;
            
        }else if(Input.GetMouseButton(0)) {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX=transform.position.x+ xSpeed*touchXDelta*Time.deltaTime;
        newX = Mathf.Clamp(newX,-limitX, limitX);


        // caharacter movement
        Vector3 NewPosition = new Vector3(newX,transform.position.y,transform.position.z+_CurrentCharSpeed*Time.deltaTime);
        transform.position = NewPosition;
    }
}
