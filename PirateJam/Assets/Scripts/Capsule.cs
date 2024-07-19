using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private Vector2 position;
    private void Start()
    {
        position = transform.position;
    }
    public static event HandleCapsuleCollected OnCapsuleCollected;
    public delegate void HandleCapsuleCollected(ItemData itemdata, Vector2 position);
    [SerializeField]
    public ItemData capsuleData;


    public void Collect()
    {
        Destroy(gameObject);
        OnCapsuleCollected?.Invoke(capsuleData, position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding");
        if (collision.gameObject.tag == "Player")
        {
            Collect();
        }
    }
}
