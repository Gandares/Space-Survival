using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 6;
    private float passiveUpSpeed = 2.5f;
    public GameObject allyBullet;
    public Transform FirePoint;
    private bool canShoot = true;
    private float delayInSeconds = 0.6f;
    private int life = 3;

    void Update()
    {
        // Movimiento horizontal

        if((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < 4.85f){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > -4.85f){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        //Movimiento vertical

        transform.Translate(Vector3.up * passiveUpSpeed * Time.deltaTime);

        // Disparo

        if(Input.GetKey(KeyCode.Space) && canShoot == true){
            Instantiate(allyBullet, FirePoint.position, FirePoint.rotation);
            canShoot = false;
            StartCoroutine(ShootDelay());
        }

        // Muerte

        if(life <= 0){
            Destroy(gameObject);
        }
    }

    IEnumerator ShootDelay(){
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet"){
            life--;
            Debug.Log(life);
        }
    }
}
