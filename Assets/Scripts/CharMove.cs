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
    {   // bu scriptin referans�n� CurrentPC e ata
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
    // bloklara de�dik�e silindirin hacmini artt�r
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AddCylinder")
        {
            CIncrementCylinder(0.2f);
            Destroy(other.gameObject);      // gameobject olmadan �al���o mu dene

        }
    }
    // silindiri artt�r
    private void CIncrementCylinder(float val){
        // silindir yoksa ve bloklar topland�ysa yeni silindir olu�tur
        if(Cylinders.Count==0){
            if (val>0){
                CreateCylinder(val);
            }
            else{ // gameover
            }

        } 
        // e�er alt�mda silindir varsa en alttakinin boytunu artt�r
        else{
            Cylinders[Cylinders.Count - 1].IncrementCylinderVolume(val);

        }

    }
    private void CreateCylinder(float val) {
        // silindir olu�tur ve cilindir script listesine ekle 
        Cylinder createdCylinder = Instantiate(RCylinderPref,transform).GetComponent<Cylinder>();
        Cylinders.Add(createdCylinder);
        // silindirin scriptinin i�indeki haci martt�rma fonksiyonun �al��t�r.
        createdCylinder.IncrementCylinderVolume(val);
    }                                                            
}
// silindir olut�ruma fonksiyonu

