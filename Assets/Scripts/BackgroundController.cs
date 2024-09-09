using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Bg;
    [SerializeField] private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        Bg = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 pos = cam.position;
        pos.z = 0;
        this.transform.position = pos;
    }
    private void OnDrawGizmos()
    {
        Bg.sortingLayerName = "Backgroud";
    }
}
