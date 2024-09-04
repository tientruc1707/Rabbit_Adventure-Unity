
using Unity.VisualScripting;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer thisSprite;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        thisSprite = this.GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        //Length of the ray
        float laserLength = 50f;
        Vector2 startPosition = (Vector2)transform.position -
                                new Vector2(thisSprite.sprite.texture.width / 2, thisSprite.sprite.texture.height / 2);
        int layerMask = LayerMask.GetMask("Default");
        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.left, laserLength, layerMask, 0);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.tag);
            //Get the sprite renderer component of the object
            SpriteRenderer sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            //Change the sprite color
            sprite.color = Color.green;
        }
        Debug.DrawRay(startPosition, Vector2.left * laserLength, Color.red);
    }
}
