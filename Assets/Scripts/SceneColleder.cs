using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Players")
        {
            
        }
    }
}
