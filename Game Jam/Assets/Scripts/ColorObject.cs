using UnityEngine;

public class ColorObject : MonoBehaviour
{
    Color color;

    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
    }

    public Color ObjectColor => color;
}
