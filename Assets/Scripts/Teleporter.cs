using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            other.transform.position = _spawnPosition;
    }
}
