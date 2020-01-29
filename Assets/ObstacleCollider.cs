using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log("HERE TOO?");
            GameManager.Instance.GameOver();
        }
    }
}
