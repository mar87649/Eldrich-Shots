using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject obstacle;
    private Vector3 enemySpawnPosition;
    private Vector3 obstacleSpawnPosition;
    private GameObject player;
    private GameObject box;
    private    float minRange = -10;
    private    float maxRange = 10;
    void Start()
    {
        player = GameObject.Find("Player");
        box = GameObject.Find("Box");
        InvokeRepeating("SpawnEnemy", 5, 3);
        InvokeRepeating("SpawnObstacle", 5, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy(){
        enemySpawnPosition =  new Vector3(Random.Range(minRange, maxRange), Random.Range(3, maxRange), Random.Range(minRange, maxRange));
        Instantiate(enemy, enemySpawnPosition, Quaternion.identity);
    }
    private void SpawnObstacle(){

        Quaternion var = Quaternion.Inverse(player.transform.rotation);
        obstacleSpawnPosition = new Vector3(Random.Range(minRange, maxRange), Random.Range(3, maxRange), Random.Range(minRange, maxRange));        
        GameObject clone = Instantiate(obstacle, obstacleSpawnPosition, Quaternion.identity.normalized);
    }
        
}