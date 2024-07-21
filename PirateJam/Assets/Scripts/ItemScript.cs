using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour ,ICollectible
{
    private Vector2 position;
    private GameObject player;
    private void Start()
    {
        position = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public static event HandleItemCollected OnItemCollected;
    public delegate void HandleItemCollected(ItemData itemdata, Vector2 position);
    [SerializeField]
    public ItemData itemData;

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
        OnItemCollected?.Invoke(itemData, position);
    }
}
