using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour, ICollectible
{
    private Vector2 position;
    private GameObject player;
    private void Start()
    {
        position = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public static event HandleCircleCollected OnCircleCollected;
    public delegate void HandleCircleCollected(ItemData itemdata, Vector2 position);
    [SerializeField]
    public ItemData circleData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(player.transform.position, transform.position) < 1.5f)
        {
            Collect();
        }
    }
    public void Collect()
    {
        Destroy(gameObject);
        OnCircleCollected?.Invoke(circleData, position);
    }

}
