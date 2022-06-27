using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI FoodText;
    public TextMeshProUGUI WaterText;
    public TextMeshProUGUI FuelText;
    public TextMeshProUGUI WoodText;

    public TextMeshProUGUI Tutorial;

    public Slider FoodSlider;
    public Slider FuelSlider;
    public Slider WaterSlider;
    public Slider HealthSlider;

    public float ScoreAmount;
    private float pointsPerSecond = 1f;

    private GameObject camp;
    private GameObject player;
    private Camp_Controller campScript;
    private Player_Controller playerScript;
    private Player_Pickups playerPickups;



    // Start is called before the first frame update
    void Start()
    {
        ScoreAmount = 0f;
        DontDestroyOnLoad(this.gameObject);
        camp = GameObject.Find("Camp");
        player = GameObject.Find("Player");

        campScript = camp.GetComponent<Camp_Controller>();
        playerScript = player.GetComponent<Player_Controller>();
        playerPickups = player.GetComponent<Player_Pickups>();
        StartCoroutine(TutorialPause());

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + (int)ScoreAmount;
        ScoreAmount += pointsPerSecond * Time.deltaTime;

        FoodText.text = "Food X" + playerPickups.FoodAmount;
        WaterText.text = "Water X" + playerPickups.WaterAmount;
        FuelText.text = "Fuel X" + playerPickups.FuelAmount;
        WoodText.text = "Wood X" + playerPickups.WoodAmount;


        WaterSlider.value = campScript.Water;
        FuelSlider.value = campScript.Fuel;
        FoodSlider.value = campScript.Food;
        HealthSlider.value = playerScript.CurrentHealth;

        



    }



    IEnumerator TutorialPause()
    {
        Tutorial.text = "We need food, water and fuel to survive.";
        yield return new WaitForSeconds(3);
        Tutorial.text = "Look around for resources and bring them back to the house.";
        yield return new WaitForSeconds(3);
        Tutorial.text = "Watch out for the weather and use shelters such as umbrellas to hide.";
        yield return new WaitForSeconds(3);
        Tutorial.text = "Watch your health and don't let the resources run out.";
        yield return new WaitForSeconds(3);
        Tutorial.text = "Heal by staying in the house.";
        yield return new WaitForSeconds(3);
        Tutorial.text = "";
        
    }
}
