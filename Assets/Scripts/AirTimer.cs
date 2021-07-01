using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AirTimer : MonoBehaviour
{

    private Slider slider;
    private GameObject player;
    public float air = 10f;
    private float airBurn = 0.2f;


    void Awake()
    {
        GetPrefereces();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;

        if (air > 0)
        {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
        }

        if(air <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void GetPrefereces()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Air Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;
    }
}
