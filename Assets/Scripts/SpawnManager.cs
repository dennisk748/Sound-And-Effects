using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private GameObject[] obstacle;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", time, Random.Range(2f,5f));
    }

    void SpawnObstacles()
    {
        if(playerController.isGameOver == false)
        {
            int index = Random.Range(0, 2);
            Vector3 spawnPosition = new Vector3(transform.position.x + 24f, 0, 0);
            Instantiate(obstacle[index], spawnPosition, obstacle[index].transform.rotation);
        }
    }
}
