using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItems : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -20)
            {
                Destroy(gameObject);
            }
        }
    }
}
