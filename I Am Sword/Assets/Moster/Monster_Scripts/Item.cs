using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type { Crystal, Coin, Grenade, Heat, Weapon };
    public Type type;
    public int value;

    Rigidbody rigid;
    SphereCollider sphereCollider;

    PlayerCtrl PlayerCtr;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }
    void Update()
    {
        
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        //PlayerCtr.Item_Crystal += 5;
        

    }




}
