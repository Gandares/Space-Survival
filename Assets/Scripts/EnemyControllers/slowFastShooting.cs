using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowFastShooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject EnemyBullet;
    private float reload = 1f;
    private float speed = 1f;
    private bool canShoot = true;

    void Start(){
        Destroy(gameObject, 10);
        StartCoroutine(ShootDelay());
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
            Destroy(gameObject);
        }
    }

    IEnumerator ShootDelay(){
        yield return new WaitForSeconds(reload);
        canShoot = true;
    }
}
