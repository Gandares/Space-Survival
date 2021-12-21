using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform Player;
    public GameObject slowKamikaze;
    public GameObject fastKamikaze;
    public GameObject slowShooting;
    public GameObject slowFastShooting;
    public GameObject fastShooting;
    public GameObject shotgun;
    public GameObject zigzagFastShooting;
    public GameObject zigzagShotgun;
    public GameObject madness;
    private bool canInstantiate = true;
    private float delay = 3.4f;
    private float moreEnemies = 10f;
    private GameObject[] Enemies;
    private int min = 0;
    private int max = 0;
    private bool upDifficulty = true;
    private bool faster = true;
    private float fasterTime = 15f;

    void Start(){
        Enemies = new GameObject[]{slowKamikaze, fastKamikaze, slowShooting, slowFastShooting, 
        fastShooting, shotgun, zigzagFastShooting, zigzagShotgun, madness};
    }
    void Update()
    {
        if(max < Enemies.Length && upDifficulty){
            max++;
            upDifficulty = false;
            StartCoroutine(harder());
        }

        if(canInstantiate){
            Instantiate(Enemies[Random.Range(min,max)], new Vector3(Random.Range(-4.85f,4.85f), Player.position.y + 18, 0), Quaternion.Euler(new Vector3(0f,0f,180f)));
            canInstantiate = false;
            StartCoroutine(spawnDelay());
        }

        if(faster && delay > 1f){
            delay-=0.2f;
            faster = false;
            StartCoroutine(Faster());
        }
    }

    IEnumerator spawnDelay(){
        yield return new WaitForSeconds(delay);
        canInstantiate = true;
    }

    IEnumerator harder(){
        yield return new WaitForSeconds(moreEnemies);
        upDifficulty = true;
        delay-=0.2f;
    }

    IEnumerator Faster(){
        yield return new WaitForSeconds(fasterTime);
        faster = true;
    }
}
