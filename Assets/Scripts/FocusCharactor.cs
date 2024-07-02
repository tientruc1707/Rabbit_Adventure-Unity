using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCharactor : MonoBehaviour
{
    public float camDist;
    public Vector3 camVec;
    public Transform player;

    void Start()
    {
        camDist = Vector3.Distance(player.transform.position, transform.position);
        camVec = transform.position - player.transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position + camVec.normalized * camDist;
    }
}
