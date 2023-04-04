using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
public  float CharSpeed;
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
        // caharacter movement
        Vector3 NewPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z+_CurrentCharSpeed*Time.deltaTime);
        transform.position = NewPosition;
    }
}
