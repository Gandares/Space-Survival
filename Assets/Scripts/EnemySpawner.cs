using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform Player;
    public GameObject slowKamikaze;
    public GameObject fastKamikaze;
    private bool canInstantiate = true;
    private float delay = 4f;
    private float moreEnemies = 20f;
    private GameObject[] Enemies;
    private int min = 0;
    private int max = 0;
    private bool upDifficulty = true;

    void Start(){
        Enemies = new GameObject[]{slowKamikaze, fastKamikaze};
    }
    void Update()
    {
        if(max < Enemies.Length && upDifficulty){
            max++;
            upDifficulty = false;
            StartCoroutine(harder());
        }

        if(canInstantiate){
            Instantiate(Enemies[Random.Range(min,max)], new Vector3(Random.Range(-4.85f,4.85f), Player.position.y + 20, 0), Quaternion.Euler(new Vector3(0f,0f,180f)));
            canInstantiate = false;
            StartCoroutine(spawnDelay());
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
}
