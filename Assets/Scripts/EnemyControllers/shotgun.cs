using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject EnemyBullet;
    private float reload = 3f;
    private float speed = 1f;
    private bool canShoot = true;
    private CanvasScript c;
    private int puntuation = 200;
    public ParticleSystem explosion;

    void Start(){
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
        Destroy(gameObject, 10);
    }

    void Update(){
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(canShoot){
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,180f + Random.Range(-25f,25f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,180f + Random.Range(-25f,25f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,180f + Random.Range(-25f,25f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,180f + Random.Range(-25f,25f)));
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "AllyBullet"){
            Instantiate(explosion, this.transform.position + new Vector3(0f,0f,-1f), Quaternion.identity);
            c.setPoints(puntuation);
            Destroy(gameObject);
        }
    }

    IEnumerator ShootDelay(){
        yield return new WaitForSeconds(reload);
        canShoot = true;
    }
}
