using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int coinPoints = 5;
    private void OnTriggerEnter2D(Collider2D player)
    {
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        Destroy(gameObject);
        FindObjectOfType<GameSession>().AddToScore(coinPoints);

    }
}
