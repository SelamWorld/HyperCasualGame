using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
public static CharMove CurrentPC;
public  float CharSpeed,xSpeed;
public float limitX;                   
private  float _CurrentCharSpeed;
    
public GameObject RCylinderPref;
public List<Cylinder> Cylinders;


    void Start()
    {   // bu scriptin referansýný CurrentPC e ata     
        CurrentPC = this;
        _CurrentCharSpeed = CharSpeed;

    }

    void Update()
    {
        float newX = 0;
        float touchXDelta=0;
        // if finger on the screeen move right and left
        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved){
            touchXDelta = Input.GetTouch(0).deltaPosition.x/Screen.width;
        
        // if mouse on the screen move right nad left    
        }else if(Input.GetMouseButton(0)) {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX=transform.position.x+ xSpeed*touchXDelta*Time.deltaTime;
        newX = Mathf.Clamp(newX,-limitX, limitX);


        // caharacter movement
        Vector3 NewPosition = new Vector3(newX,transform.position.y,transform.position.z+_CurrentCharSpeed*Time.deltaTime);
        transform.position = NewPosition;
    }
    // bloklara deðdikçe silindirin hacmini arttýr
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AddCylinder")
        {
            CIncrementCylinder(0.2f);
            Destroy(other.gameObject);      

        }
    }
    // silindiri arttýr
    private void CIncrementCylinder(float val){
        // silindir yoksa ve bloklar toplandýysa yeni silindir oluþtur
        if(Cylinders.Count==0){
            if (val>0){
                CreateCylinder(val);
            }
            else{ // gameover
            }

        } 
        // eðer altýmda silindir varsa en alttakinin boytunu arttýr
        else{
            Cylinders[Cylinders.Count - 1].IncrementCylinderVolume(val);

        }

    }
    public void CreateCylinder(float val) {
        // silindir oluþtur ve cilindir script listesine ekle 
        Cylinder createdCylinder = Instantiate(RCylinderPref,transform).GetComponent<Cylinder>();
        Cylinders.Add(createdCylinder);
        // silindirin scriptinin içindeki haci marttýrma fonksiyonun çalýþtýr.
        createdCylinder.IncrementCylinderVolume(val);
    }                                                            
    // silindir yok et
    public void DestroyCylinder(Cylinder cylinder){
        Cylinders.Remove(cylinder);
        Destroy(cylinder.gameObject);
        
    }

}





