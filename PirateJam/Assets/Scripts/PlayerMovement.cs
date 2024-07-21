using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;

    private float horizontal;
    private float vertical;
    [SerializeField]
    private float runSpeed = 20.0f;
    private CraftingCauldron craftingCauldron;
    [SerializeField]
    private Transform cauldron;
    public Inventory inventory;
    [SerializeField]
    private Transform playerSprite;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        craftingCauldron = cauldron.GetComponent<CraftingCauldron>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        float interactDistance = 1.5f;
        if (Input.GetKeyDown(KeyCode.E) && Vector2.Distance(cauldron.transform.position, transform.position) <= interactDistance)
        {
            Debug.Log("Atildi");
            ItemData itemHolding = inventory.GetItemHold();
            Debug.Log(itemHolding.name);
            craftingCauldron.AddToRecipe(itemHolding);
            inventory.Remove();
                
                
            
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        if(body.velocity.x < 0)
        {
           playerSprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
           playerSprite.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    

}
