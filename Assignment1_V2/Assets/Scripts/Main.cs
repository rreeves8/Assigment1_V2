using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour{

    public GameObject pickup;

    void Start(){
        Vector3 random = new Vector3(0.0f,5f,0.0f);


        for (int i = 0; i <= num_Pickups; i++){
            
            
            Instantiate(pickup, random, Quaternion.identity);
        }
    }
}
