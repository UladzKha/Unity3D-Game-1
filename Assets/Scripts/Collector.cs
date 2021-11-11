using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private const string ENEMY_TAG = "Enemy";
    private const string PLAYER_TAG = "Player";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.CompareTag(ENEMY_TAG) || collision.CompareTag(PLAYER_TAG))
        {
            Destroy(collision.gameObject);
        }
    }
}
