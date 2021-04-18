using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAnchors : MonoBehaviour
{
    [SerializeField]
    private Transform barrelAnchor;
    [SerializeField]
    private Transform wheelAnchor;

    public Transform BarrelAnchor => barrelAnchor;
    public Transform WheelAnchor => wheelAnchor;
}
