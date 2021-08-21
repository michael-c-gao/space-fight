using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arrow : MonoBehaviour
{

    public Transform target;
    public Transform Player;
    public Transform realArrow;
    public TextMeshProUGUI distance;

    void Update()
    {
        realArrow.LookAt(target);

        float dist = Vector3.Distance(target.position, Player.position);

        distance.text = dist.ToString("F1") +" meters";
    }
}
