using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather_Controller : MonoBehaviour
{
    public GameObject Rain;
    public GameObject Snow;
    public GameObject Sand;
    public GameObject Tornado;
    public AudioSource RainSound;
    public AudioSource SnowSound;

    public int randomizer;
    private int weatherLength;

    public bool badWeather;


    void Start()
    {
        InvokeRepeating("RandomWeather", 20, 15);
        badWeather = false;
        Tornado.SetActive(false);
    }



    void RandomWeather()
    {
        
        randomizer = Random.Range(0, 101);
        if (randomizer <= 90 && randomizer > 60)
        {
            ClearWeather();
        }

        else if (randomizer <= 60 && randomizer > 40)
        {
            badWeather = true;
            Rain.SetActive(true);
            RainSound.Play();
            StartCoroutine(RandomLength());
        }
        else if (randomizer <= 40 && randomizer > 20)
        {
            badWeather = true;
            Snow.SetActive(true);
            SnowSound.Play();
            StartCoroutine(RandomLength());
        }
        else if (randomizer <= 20 && randomizer > 0)
        {
            badWeather = true;
            Sand.SetActive(true);
            SnowSound.Play();
            StartCoroutine(RandomLength());
        }
        else if(randomizer > 90)
        {
            Tornado.SetActive(true);
            Tornado.transform.position = new Vector2(Random.Range(-25, 25), Random.Range(-20, 20));
            StartCoroutine(RandomLength());
        }

    }

    IEnumerator RandomLength()
    {
        weatherLength = Random.Range(5, 15);
        yield return new WaitForSeconds(weatherLength);
        ClearWeather();
    }

    void ClearWeather()
    {
        badWeather = false;
        Rain.SetActive(false);
        RainSound.Stop();
        Snow.SetActive(false);
        Sand.SetActive(false);
        SnowSound.Stop();
        Tornado.SetActive(false);
        StopCoroutine(RandomLength());
        
    }
}
