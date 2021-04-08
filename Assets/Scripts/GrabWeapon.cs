using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public GameObject r_arm;
    private Transform t_player;
    private WeaponList weaponList;
    private int type = -1;
    void Start()
    {
        t_player = GetComponent<Transform>();
        weaponList = GameObject.FindObjectOfType<WeaponList>();
        if(type!=-1) {
            Transform child =  r_arm.transform.GetChild(type);
            child.gameObject.SetActive(true);
        }
    }

    

    public void ChangeWeapon(string wtag){
        if(type!=-1){
            r_arm.transform.GetChild(type).gameObject.SetActive(false);
            Instantiate(weaponList.weaponList[type], t_player.position+Vector3.up, Random.rotation);
            type = -1;
        }
        switch(wtag){
            case "WeaponAxe":
                setActive(0);
                break;
            case "WeaponStick":
                setActive(1);
                break;
            case "WeaponSword1":
                setActive(2);
                break;
            case "WeaponSword2":
                setActive(3);
                break;
            case "WeaponSword3":
                setActive(4);
                break;
        }
    }

    private void setActive(int a){
        r_arm.transform.GetChild(a).gameObject.SetActive(true);
        type = a;
    }

    public int GetWeaponType(){
        return type;
    }
}
