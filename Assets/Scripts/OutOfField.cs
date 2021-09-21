using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class OutOfField : MonoBehaviour
{
    private float posX = 3.35f;
    private float posZ = 5.7f;
    // Update is called once per frame
    void LateUpdate()
    {
        //DestroyBeyondField();
    }
    private void DestroyBeyondField()
    {
        float x = this.transform.position.x;
        float z = this.transform.position.z;

        if ((-posX < x || posX > x) && (-posZ < z || posZ > z))
        {
            Destroy(this.gameObject);
        }
    }
}
