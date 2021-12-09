using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Madness : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject EnemyBullet;
    private float reload = 2.5f;
    private float speedSides = 5f;
    private float speed = 1f;
    private bool canShoot = true;
    private bool leftRight = true;
    private CanvasScript c;
    private int puntuation = 500;

    void Start(){
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
        Destroy(gameObject, 7.4f);
    }

    void Update(){
        if(leftRight){
            if(transform.position.x < 4.86f)
                transform.Translate(Vector3.left * speedSides * Time.deltaTime);
            else
                leftRight = false;
        }
        else{
            if(transform.position.x > -4.86f)
                transform.Translate(Vector3.right * speedSides * Time.deltaTime);
            else
                leftRight = true;  
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(canShoot){
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
            Instantiate(EnemyBullet, FirePoint.position, Quaternion.Euler(0f,0f,Random.Range(0f,360f)));
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
