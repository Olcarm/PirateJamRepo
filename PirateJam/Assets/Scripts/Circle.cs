using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour, ICollectible
{
    private Vector2 position;
    private void Start()
    {
        position = transform.position;
    }
    public static event HandleCircleCollected OnCircleCollected;
    public delegate void HandleCircleCollected(ItemData itemdata, Vector2 position);
    [SerializeField]
    public ItemData circleData;


    public void Collect()
    {
        Destroy(gameObject);
        OnCircleCollected?.Invoke(circleData, position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding");
        if(collision.gameObject.tag == "Player")
        {
            Collect();
        }
    }
}
