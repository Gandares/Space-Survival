using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowKamikaze : MonoBehaviour
{    
    private CanvasScript c;
    private int puntuation = 50;

    void Start(){
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
        Destroy(gameObject, 15);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "AllyBullet"){
            c.setPoints(puntuation);
            Destroy(gameObject);
        }
    }
}
