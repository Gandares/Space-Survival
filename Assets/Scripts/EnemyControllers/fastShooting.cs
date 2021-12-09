using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastShooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject EnemyBullet;
    private float reload = 1f;
    private float speed = 3f;
    private bool canShoot = true;
    private CanvasScript c;
    private int puntuation = 130;

    void Start(){
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
        Destroy(gameObject, 10);
    }

    void Update(){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(canShoot){
            Instantiate(EnemyBullet, FirePoint.position, FirePoint.rotation);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "AllyBullet"){
            c.setPoints(puntuation);
            Destroy(gameObject);
        }
    }

    IEnumerator ShootDelay(){
        yield return new WaitForSeconds(reload);
        canShoot = true;
    }
}
