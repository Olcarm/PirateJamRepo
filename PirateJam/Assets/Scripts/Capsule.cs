using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private Vector2 position;
    private GameObject player;
    private void Start()
    {
        position = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public static event HandleCapsuleCollected OnCapsuleCollected;
    public delegate void HandleCapsuleCollected(ItemData itemdata, Vector2 position);
    [SerializeField]
    public ItemData capsuleData;
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
        OnCapsuleCollected?.Invoke(capsuleData, position);
    }
    

}
