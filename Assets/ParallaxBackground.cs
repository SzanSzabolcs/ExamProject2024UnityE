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
        // A h�tt�r text�r�t mozgatjuk az X tengelyen
        material.mainTextureOffset += offset * Time.deltaTime;

        // Ha el�ri a text�ra v�g�t, vissza�ll�tjuk az offsetet
        if (material.mainTextureOffset.x > 1f)
        {
            material.mainTextureOffset = new Vector2(0f, 0f);
        }
    }
}
