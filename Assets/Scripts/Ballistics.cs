using System.Collections.Generic;
using UnityEngine;

public class Ballistics : MonoBehaviour
{
    public Transform SpawnTransform;
    public Transform TargetTransform;

    public float AngleInDegrees;

    float g = Physics.gravity.y;

    public GameObject Bullet;

    void Update()
    {
        SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);
    }

    public GameObject Shot(bool isPlayer)
    {
        Vector3 fromTo = TargetTransform.position - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

        float x = fromToXZ.magnitude;
        float y = fromTo.y;

        float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        float v = Mathf.Sqrt(Mathf.Abs(v2));

        GameObject newBullet = Instantiate(Bullet, SpawnTransform.position, Quaternion.Euler(Random.RandomRange(0f, 180f), Random.RandomRange(0f, 180f), Random.RandomRange(0f, 180f)));
        newBullet.GetComponent<Rigidbody>().velocity = SpawnTransform.forward * v;
        newBullet.GetComponent<CubeManager>().isPlayerShot = isPlayer;
        return newBullet;
    }
}
