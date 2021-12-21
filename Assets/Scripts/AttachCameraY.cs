using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCameraY : MonoBehaviour
{
    private GameObject Player;
    public Transform bg1;
    public Transform bg2;
    private float size;
    private float lastWidth;
    private float lastHeight;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        size = bg1.GetComponent<BoxCollider2D>().size.y * 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Posición de la cámara

        transform.position = new Vector3(0, Player.transform.position.y + 6.5f, -10);

        // Posición del fondo

        if(transform.position.y >= bg2.position.y){
            bg1.position = new Vector3(0, bg2.position.y + size, 0);
            switchBg();
        }
    }

    private void switchBg(){
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
