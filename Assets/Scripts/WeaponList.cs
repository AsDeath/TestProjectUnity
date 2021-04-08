using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    public List<GameObject> weaponList = new List<GameObject>();
    void Start()
    {
        
    }

    public List<GameObject> GetWeaponList(){
        return weaponList;
    }

    

}
