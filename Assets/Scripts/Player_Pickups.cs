using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pickups : MonoBehaviour
{
    public int FoodAmount = 0;
    public int FuelAmount = 0;
    public int WaterAmount = 0;
    public int WoodAmount = 0;

    public GameObject Camp;
    public Camp_Controller CampController;
    public Material CampAlpha;
    public Player_Controller Player;
    public Weather_Controller Weather;

    private bool sheltered;
    private bool inCamp;
    private Color oldColor;
    private Color newColor;


    private void Start()
    {
        inCamp = false;
        sheltered = false;
        CampAlpha = Camp.GetComponent<SpriteRenderer>().material;
        oldColor = CampAlpha.color;
        newColor = new Color(oldColor.r, oldColor.g, oldColor.b, 0.5f);

    }

    private void Update()
    {
        if (sheltered == true && inCamp == true)
        {
            Player.CurrentHealth = Mathf.Clamp(Player.CurrentHealth += 5 * Time.deltaTime, 0, 100);
        }
        else if (!sheltered && Weather.badWeather)
        {
            Player.CurrentHealth = Mathf.Clamp(Player.CurrentHealth -= 20 * Time.deltaTime, 0, 100);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shelter")
        {

            sheltered = true;

        }

        else if (collision.gameObject.tag == "Pickup")
        {
            if(collision.name == "Food(Clone)")
            {
                FoodAmount += 1;
            }
            else if (collision.name == "Water(Clone)")
            {
                WaterAmount += 1;
            }
            else if (collision.name == "Fuel(Clone)")
            {
                FuelAmount += 1;
            }
            else if (collision.name == "Wood(Clone)")
            {
                WoodAmount += 1;
            }



        }
        else if(collision.gameObject.tag == "Camp")
        {
            inCamp = true;
            sheltered = true;
            CampAlpha.color = newColor;

            if(FoodAmount > 0)
            {
                CampController.Food = Mathf.Clamp(CampController.Food += FoodAmount * 30, 0, 100);
                FoodAmount -= FoodAmount;
            }
            if (WaterAmount > 0)
            {
                CampController.Water = Mathf.Clamp(CampController.Water += WaterAmount * 30, 0, 100);
                WaterAmount -= WaterAmount;
            }
            if (FuelAmount > 0)
            {
                CampController.Fuel = Mathf.Clamp(CampController.Fuel += FuelAmount * 30, 0, 100);
                FuelAmount -= FuelAmount;
            }
            if (WoodAmount > 0)
            {
                CampController.Fuel = Mathf.Clamp(CampController.Fuel += WoodAmount * 20, 0, 100);
                WoodAmount -= WoodAmount;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shelter")
        {       
            
            sheltered = false;
        }
        else if(collision.gameObject.tag == "Camp")
        {
            inCamp = false;
            sheltered = false;
            CampAlpha.color = oldColor;
        }
    }
}
