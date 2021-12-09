using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastKamikaze : MonoBehaviour
{
    private float speed = 2f;
    private CanvasScript c;
    private int puntuation = 60;

    void Start(){
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
        Destroy(gameObject, 10);
    }

    void Update(){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "AllyBullet"){
            c.setPoints(puntuation);
            Destroy(gameObject);
        }
    }
}
