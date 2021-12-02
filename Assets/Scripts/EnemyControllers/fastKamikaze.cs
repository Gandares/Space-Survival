using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastKamikaze : MonoBehaviour
{
    private float speed = 2f;
    void Start(){
        Destroy(gameObject, 10);
    }

    void Update(){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "AllyBullet"){
            Destroy(gameObject);
        }
    }
}
