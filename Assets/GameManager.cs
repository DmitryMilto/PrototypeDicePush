using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private ISquardPositionGenerator _generator;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    [SerializeField] private List<NavMeshAgent> playerAgent;
    [SerializeField] private List<NavMeshAgent> enemyAgent;

    [SerializeField] public List<GameObject> AgentAll;

    [SerializeField] private Transform _targetPlayer;
    [SerializeField] private Transform _targetEnemy;

    [SerializeField] private Slider sliderPlayer;
    [SerializeField] private Slider sliderEnemy;
    [SerializeField] private int Win = 20;

    [SerializeField] private Canvas canvas;
    [SerializeField] private Image winImage;
    [SerializeField] private Image playImage;

    [SerializeField] private Sprite textureWin;
    [SerializeField] private Sprite textureFeat;
    [SerializeField] private Sprite texturePlay;
    [SerializeField] private Sprite textureReplay;

    private void Start()
    {
        _generator = GetComponent<ISquardPositionGenerator>();
        sliderEnemy.maxValue = sliderPlayer.maxValue = Win;
        canvas.gameObject.SetActive(false);
    }
    public void SetSquardCenterPlayer(Vector3 center)
    {
        var position = _generator.GetPosition(playerAgent.Count);
        for (int i = 0; i < position.Length; i++)
        {
            playerAgent[i].SetDestination(center + (position[i] * 3));
        }
    }
    public void SetSquardCenterEnemy(Vector3 center)
    {
        var position = _generator.GetPosition(enemyAgent.Count);
        for (int i = 0; i < position.Length; i++)
        {
            enemyAgent[i].SetDestination(center + (position[i]));
        }
    }

    public void SpawnAgent(int countAgent, Vector3 position ,bool isPlayer)
    {
        if (isPlayer)
        {
            SpawnPlayerAgent(countAgent, position, player, playerAgent);
            SetSquardCenterPlayer(position);
            playerAgent.Clear();
        }
        else
        {
            SpawnPlayerAgent(countAgent, position, enemy, enemyAgent);
            SetSquardCenterEnemy(position);
            enemyAgent.Clear();
        }
    }

    private void SpawnPlayerAgent(int count, Vector3 positionTarget, GameObject prefab, List<NavMeshAgent> agents)
    {
        for (int i = 0; i < count; i++)
        {
            var enemyUnit = Instantiate(prefab, positionTarget, Quaternion.identity);
            agents.Add(enemyUnit.GetComponent<NavMeshAgent>());
            AgentAll.Add(enemyUnit);
        }
    }

    public void DeleteUnitPlayer(NavMeshAgent agent)
    {
        playerAgent.Remove(agent);
    }

    public void DeleteUnitEnemy(NavMeshAgent agent)
    {
        enemyAgent.Remove(agent);
    }
    public void DeleteAllAgent(GameObject agent)
    {
        AgentAll.Remove(agent);
    }

    private void Update()
    {
        PlayervsEnemy();
        if (sliderPlayer.value == Win)
        {
            winImage.sprite = textureWin;
            playImage.sprite = texturePlay;
            canvas.gameObject.SetActive(true);
        }
        if(sliderEnemy.value == Win)
        {
            winImage.sprite = textureFeat;
            playImage.sprite = textureReplay;
            canvas.gameObject.SetActive(true);
        }
    }
    private void PlayervsEnemy()
    {
        int sizePlayer = 0;
        int sizeEnemy = 0;
        foreach(GameObject game in AgentAll)
        {
            if(game.name == "Player(Clone)")
            {
                sizePlayer++;
            }
            if(game.name == "Enemy(Clone)")
            {
                sizeEnemy++;
            }
        }
        sliderPlayer.value = sizePlayer;
        sliderEnemy.value = sizeEnemy;
    }
    public void StartGame()
    {
        Application.LoadLevel(0);
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}

public interface ISquardPositionGenerator
{
    Vector3[] GetPosition(int count);
}
