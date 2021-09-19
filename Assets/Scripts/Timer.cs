using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer inst { get; private set; }

    [SerializeField] private bool IsPlayer;
    [SerializeField] private int seconds;
    [SerializeField] public float currentSeconds { get; set; }
    [SerializeField] private TMP_Text TextTimer;

    [SerializeField] public bool shot { get; set; }

    private void OnEnable()
    {
        inst = this;
    }
    private void OnDisable()
    {
        if (inst != null)
            inst = null;
    }
    // Start is called before the first frame update
    private void Start()
    {
        shot = true;
        if (IsPlayer)
        {
            currentSeconds = 0;
            seconds = 3;
        }
        else
        {
            currentSeconds = 2;
            seconds = 12;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (shot)
        {
            currentSeconds = seconds;
            shot = false;
        }

        currentSeconds -= Time.deltaTime;

        if (currentSeconds <= 0f)
        {
            currentSeconds = 0f;
        }

        TextTimer.text = Mathf.Round(currentSeconds).ToString();
    }
}
