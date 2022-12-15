using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestFunction : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;
    public bool killNextFrame = false;

    GameController gc;

    void ChangeSprite(uint frame)
    {
        spriteRenderer.sprite = newSprite[frame];
    }

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindWithTag("GC").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (killNextFrame)
        {
            gc.openChest();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { ChangeSprite(1); }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { ChangeSprite(0); }
    }
}