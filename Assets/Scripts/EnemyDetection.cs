using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool isPlayer = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayer = true;
    }
}
