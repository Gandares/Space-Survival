using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 6;
    private float passiveUpSpeed = 2.5f;
    public GameObject allyBullet;
    public Transform FirePoint;
    private bool canShoot = true;
    private float delayInSeconds = 0.6f;
    private int life = 3;
    private CanvasScript c;

    void Start() {
        c = GameObject.FindWithTag("Canvas").GetComponent<CanvasScript>();
    }

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

        transform.Translate(new Vector3(0,-1,0) * passiveUpSpeed * Time.deltaTime);

        // Disparo

        if(Input.GetKey(KeyCode.Space) && canShoot == true){
            Instantiate(allyBullet, FirePoint.position, Quaternion.Euler(0,0,0));
            Debug.Log("Dispara");
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ShootDelay(){
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet"){
            life--;
            c.setLifes(life);
            Debug.Log(life);

            // Muerte

            if(life == 0){
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
