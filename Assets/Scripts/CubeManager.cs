using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public bool isRotate = true;

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
            if (GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                Destroy(this.gameObject);
            }

        }
    }
}
