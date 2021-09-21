using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLogic : MonoBehaviour
{
    [SerializeField] private Transform LayoutStart;
    [SerializeField] private Transform LayoutOnePosition;
    [SerializeField] private Transform LayoutTwoPosition;

    public Vector3 GeneralPosition => new Vector3(
        Random.RandomRange(LayoutOnePosition.position.x, LayoutTwoPosition.position.x), 
        0,
        Random.RandomRange(LayoutTwoPosition.position.z, LayoutOnePosition.position.z));

    public Vector3 StartPosition => LayoutStart.position;
}
