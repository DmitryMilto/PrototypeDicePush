using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCube : MonoBehaviour
{
    public bool isCollision = false;
    public int NumberEdge;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Scane")
        {
            isCollision = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Scane")
        {
            isCollision = false;
        }
    }
}
