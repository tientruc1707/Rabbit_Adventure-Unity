using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] Bgs;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bgs = this.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < Bgs.Length; ++i)
        {
            Vector2 pos = Bgs[i].transform.position;
            if (player.position.x - pos.x != Bgs[i].sprite.texture.width / 16f / 3)
            {
                pos.x = player.position.x;
                Bgs[i].transform.position = pos;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Bgs = this.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < Bgs.Length; ++i)
        {
            Bgs[i].sortingLayerName = "Background";
            Bgs[i].sortingOrder = i;
            Bgs[i].drawMode = SpriteDrawMode.Tiled;
            Bgs[i].tileMode = SpriteTileMode.Adaptive;
        }
    }
}
