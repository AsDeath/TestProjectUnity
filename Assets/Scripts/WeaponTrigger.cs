using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    GrabWeapon grabWeapon;
    void Start()
    {
        grabWeapon = GameObject.FindObjectOfType<GrabWeapon>();
    }

    void OnTriggerStay(Collider col){
        if(col.transform.CompareTag("Player") && ButtonInteract.grab==true){
            ButtonInteract.grab = false;
            grabWeapon.ChangeWeapon(this.transform.tag);
            Destroy(this.gameObject);
        }
    }
}
