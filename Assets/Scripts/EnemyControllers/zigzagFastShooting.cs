using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zigzagFastShooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject EnemyBullet;
    private float reload = 1f;
    private float speedSides = 3f;
    private float speed = 1f;
    private bool canShoot = true;
    private bool leftRight = true;

    void Start(){
        Destroy(gameObject, 8);
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
