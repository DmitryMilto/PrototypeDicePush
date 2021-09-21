using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlarformManager : MonoBehaviour
{
    [SerializeField] private bool isPlayerPlatform;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Timer Timer;
    [SerializeField] private GameObject Target;
    [SerializeField] private Ballistics ballistics;
    [SerializeField] private BotLogic botLogic;

    [SerializeField] private Vector3 StartPos;
    [SerializeField] private Vector3 EndPos;

    private void Awake()
    {
        ballistics = GetComponent<Ballistics>();
        Timer = GetComponent<Timer>();
        //botLogic.GetComponent<BotLogic>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Target.SetActive(false);
        if (botLogic != null)
        {
            EndPos = botLogic.GeneralPosition;
            StartPos = botLogic.StartPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerPlatform)
        {
            if (Timer.currentSeconds <= 0f)
            {
                if (Input.GetMouseButtonDown(0)) //нажали
                {
                    SetTarget();
                    Target.SetActive(true);
                }

                if (Input.GetMouseButtonUp(0)) //отпустили
                {
                    Timer.shot = true;
                    Target.SetActive(false);
                    ballistics.Shot(isPlayerPlatform);

                }
            }
        }
        else
        {
            if (Timer.currentSeconds <= 0f)
            {
                Target.SetActive(true);
                Target.transform.position = Vector3.MoveTowards(Target.transform.position, EndPos, 5f * Time.deltaTime); 
            }
            if (Timer.currentSeconds < -2f)
            {
                Timer.shot = true;
                Target.SetActive(false);
                ballistics.Shot(isPlayerPlatform);
                if (botLogic != null)
                {
                    EndPos = botLogic.GeneralPosition;
                    Target.transform.position = StartPos;
                }
            }
        }
    }

    private void SetTarget()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider == null) return;

            Target.transform.position = hit.point;
        }
    }
}
