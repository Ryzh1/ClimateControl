using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Spawner : MonoBehaviour
{
    private int random;
    public GameObject Food;
    public GameObject Water;
    public GameObject Fuel;
    public GameObject Wood;
    private GameObject chosenItem;

    private int numberOfTaggedObjects;
    private void Start()
    {
        InvokeRepeating("SpawnItems",0, Random.Range(1, 5));
    }
    private void Update()
    {
        numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("Pickup").Length;
    }

    void SpawnItems()
    {
        random = Random.Range(0, 101);
        if(numberOfTaggedObjects >= 15)
        {

        }
        else
        {
            if(random > 75)
            {
                chosenItem = Food;
            }
            else if(random <= 75 && random > 50)
            {
                chosenItem = Water;
            }
            else if (random <= 50 && random > 25)
            {
                chosenItem = Fuel;
            }
            else if (random <= 25)
            {
                chosenItem = Wood;
            }

            Instantiate(chosenItem, new Vector2(Random.Range(-25, 25),Random.Range(-20,20)), transform.rotation);
        }


        
    }

}
