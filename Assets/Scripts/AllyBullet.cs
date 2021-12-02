using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBullet : MonoBehaviour
{
    private float speed = 36;
    void Start()
    {
        Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
        }
    }
}
