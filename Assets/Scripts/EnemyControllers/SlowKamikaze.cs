using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowKamikaze : MonoBehaviour
{    
    void Start(){
        Destroy(gameObject, 15);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "AllyBullet"){
            Destroy(gameObject);
        }
    }
}
