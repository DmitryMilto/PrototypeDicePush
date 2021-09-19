using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlarformManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Timer Timer;
    [SerializeField] private GameObject Target;
    [SerializeField] private Ballistics ballistics;

    public List<GameObject> playerCube = new List<GameObject>();

    private void Awake()
    {
        ballistics = GetComponent<Ballistics>();
        Timer = GetComponent<Timer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
                ballistics.Shot();
                playerCube = ballistics.get;
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
