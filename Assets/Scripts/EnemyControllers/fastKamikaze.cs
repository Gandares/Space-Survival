using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastKamikaze : MonoBehaviour
{
    private float speed = 2f;
    private CanvasScript c;
    private int puntuation = 60;
    public ParticleSystem explosion;

    void Start(){
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
        Destroy(gameObject, 10);
    }

    void Update(){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "AllyBullet"){
            Instantiate(explosion, this.transform.position + new Vector3(0f,0f,-1f), Quaternion.identity);
            c.setPoints(puntuation);
            Destroy(gameObject);
        }
    }
}
