using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float Speed;
    private float waitTime;
    public float StartWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;

    public GameHandler endGame;

    void Start()
    {
        waitTime = StartWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) <= 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            endGame.GameEnd("PlayerDied");
        }
    }

}
