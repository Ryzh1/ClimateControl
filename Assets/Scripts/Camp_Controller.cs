using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camp_Controller : MonoBehaviour
{
    public float Fuel = 100;
    public float Food = 100;
    public float Water = 100;
    public Slider CampHealth;

    private float campMaxHealth = 100f;
    public float campCurrentHealth;
    private float pointsPerSecond = 1;

    private void Start()
    {
        campCurrentHealth = campMaxHealth;
    }


    void Update()
    {
        Food = Mathf.Clamp(Food -= pointsPerSecond * Time.deltaTime, 0, 100);
        Fuel = Mathf.Clamp(Fuel -= (pointsPerSecond + 1 ) * Time.deltaTime, 0, 100);
        Water = Mathf.Clamp(Water -= pointsPerSecond * Time.deltaTime, 0, 100);

        CampHealth.value = Mathf.Clamp(campCurrentHealth, 0, 100);

        if (Fuel == 0 || Food == 0 || Water == 0)
        {
            campCurrentHealth = Mathf.Clamp(campCurrentHealth -= 5 * Time.deltaTime, 0, 100);
        }



    }
}
