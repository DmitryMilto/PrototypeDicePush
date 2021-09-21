using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private List<CollisionCube> listCube;
    [SerializeField] private GameManager _manager;
    [SerializeField] public bool isPlayerShot { private get; set; }
    public bool isRotate = true;

    private void Awake()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Scene")
        {
            isRotate = false;
        }
    }

    private void LateUpdate()
    {
        CubePlayer();
    }

    private void CubePlayer()
    {
        if (isRotate)
        {
            transform.Rotate(new Vector3(45, 30, 45) * Time.deltaTime);
        }
        else
        {
            DestroyBeyondField();
            if (GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                Vector3 position = this.transform.position;
                _manager.SpawnAgent(SideCube(), position ,isPlayerShot);
                Debug.Log(SideCube() + " Player " + isPlayerShot);
                Destroy(this.gameObject);

            }

        }
    }
    private float posX = 3.35f;
    private float posZ = 5.7f;
    private void DestroyBeyondField()
    {
        float x = this.transform.position.x;
        float z = this.transform.position.z;

        if ((-posX > x || posX < x) && (-posZ > z || posZ < z))
        {
            Destroy(this.gameObject);
        }
    }
    private int SideCube()
    {
        int number = 0;
        foreach(CollisionCube cube in listCube)
        {
            if (cube.isCollision)
            {
                return cube.NumberEdge;
            }
        }
        return number;
    }
}
