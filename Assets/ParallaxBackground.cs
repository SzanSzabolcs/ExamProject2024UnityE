using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private Material material;
    private Vector2 offset;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(scrollSpeed, 0f);
    }

    void Update()
    {
        // A háttér textúrát mozgatjuk az X tengelyen
        material.mainTextureOffset += offset * Time.deltaTime;

        // Ha eléri a textúra végét, visszaállítjuk az offsetet
        if (material.mainTextureOffset.x > 1f)
        {
            material.mainTextureOffset = new Vector2(0f, 0f);
        }
    }
}
