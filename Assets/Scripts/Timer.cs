using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField] private bool IsPlayer;
    [SerializeField] private int seconds;
    [SerializeField] public float currentSeconds { get; set; }

    [SerializeField] public bool shot { get; set; }

    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    private void Start()
    {
        shot = true;
        if (IsPlayer)
        {
            currentSeconds = 1;
            seconds = 3;
        }
        else
        {
            currentSeconds = 2;
            seconds = 4;
        }
        slider.maxValue = seconds;
        slider.value = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (shot)
        {
            currentSeconds = seconds;
            shot = false;
            slider.value = 0;
        }

        currentSeconds -= Time.deltaTime;
        slider.value += Time.deltaTime;

        if (IsPlayer)
        {
            PlayerTimer();
        }   
    }
    private void PlayerTimer()
    {
        if (currentSeconds <= 0f)
        {
            currentSeconds = 0f;
        }
    }
}
