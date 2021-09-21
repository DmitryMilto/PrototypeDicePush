using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentLogic : MonoBehaviour
{
    private float posX = 3.35f;
    private float posZ = 5.7f;

    [SerializeField] private GameManager _manager;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject enemy;

    [SerializeField] private bool isPlayer;
    private void Awake()
    {
        _agent = this.GetComponent<NavMeshAgent>();
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DestroyBeyondField();
        if (!isPlayer)
            enemy = SetDestinationPlayer();
        if (enemy != null)
        {
            ConnectionPlayers(enemy);
            _agent.SetDestination(enemy.transform.position);
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if (distance < 1f)
            {
                if (!isPlayer)
                {
                    _manager.AgentAll.Remove(this.gameObject);
                    _manager.AgentAll.Remove(enemy);
                    Destroy(enemy);
                    Destroy(this.gameObject);
                }
            }
        }
        if (enemy == null)
        {
            _agent.SetDestination(this.transform.position);
        }
    }

    private void DestroyBeyondField()
    {
        float x = this.transform.position.x;
        float z = this.transform.position.z;
        if (-posX >= x || posX <= x)
        {
            Debug.LogError("+");
        }
        if (-posZ >= x || posZ <= x)
        {
            Debug.LogError("+");
        }
    }

    private void ConnectionPlayers(GameObject game)
    {
        if (isPlayer)
        {

        }
        else
        {
            game.GetComponent<AgentLogic>().enemy = this.gameObject;
        }
    }

    private GameObject SetDestinationPlayer()
    {

        float closestUnitsDistance = 0;
        GameObject nearestUnits = null;
        List<GameObject> sortingUnits = _manager.AgentAll;
        if (sortingUnits != null)
            if (sortingUnits.Count != 0)
                foreach (var units in sortingUnits)
                {
                    if (units.name == "Player(Clone)" && !isPlayer)
                        if ((Vector3.Distance(transform.position, units.transform.position) < closestUnitsDistance) || closestUnitsDistance == 0)
                        {
                            closestUnitsDistance = Vector3.Distance(transform.position, units.transform.position);
                            nearestUnits = units;
                        }
                    if (units.name == "Enemy(Clone)" && isPlayer)
                        if ((Vector3.Distance(transform.position, units.transform.position) < closestUnitsDistance) || closestUnitsDistance == 0)
                        {
                            closestUnitsDistance = Vector3.Distance(transform.position, units.transform.position);
                            nearestUnits = units;
                        }
                }
        return nearestUnits;
    }
}
