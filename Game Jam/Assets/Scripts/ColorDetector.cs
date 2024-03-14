using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float timer ;
    List<Color> colors = new();
    Color originalColor;
    Color buildingColor;

    Transform currentCollidedBuilding = null;
    SpriteRenderer spriteRenderer;
    bool colormatch;
    bool changeColor;

    [SerializeField] float tolerance = 0.8f;
    [SerializeField] float colorDuration = 1.5f;

    private void Start() {
        originalColor = GetComponent<SpriteRenderer>().color;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!colormatch) return;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            changeColor = true;
            spriteRenderer.color = buildingColor;

            
        }

        if(changeColor)
        {
            timer += Time.deltaTime;

            if(timer > colorDuration)
            {
                timer = 0;
                colormatch = false;
                spriteRenderer.color = originalColor;
                currentCollidedBuilding = null;
                changeColor = false;
            }
        }

        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Color"))
        {
            
            if(other.gameObject.TryGetComponent<ColorObject>(out ColorObject colorObject))
            {

                Color currentColor = colorObject.ObjectColor;
                if(colors.Contains(currentColor)) return;

                colors.Add(currentColor);
                Destroy(other.gameObject);
            }
        }

        if(other.transform.CompareTag("Building"))
        {
            currentCollidedBuilding = other.transform;
            buildingColor = other.gameObject.GetComponent<SpriteRenderer>().color;
            colormatch = CheckForoColors(buildingColor);
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        
        if(other.transform.CompareTag("Building"))
        {
            if(currentCollidedBuilding != other.transform) return;

            spriteRenderer.color = originalColor;
        }
    }

    bool CheckForoColors(Color color2)
    {
        foreach(Color color in colors)
        {
            if(ColorsMatch(color , color2, tolerance)) return true;
            
        }

        return false;
    }

    bool ColorsMatch(Color color1, Color color2, float tolerance)
    {
        // Calculate the squared magnitude of the color difference
        float rDiff = color1.r - color2.r;
        float gDiff = color1.g - color2.g;
        float bDiff = color1.b - color2.b;
        float aDiff = color1.a - color2.a;

        float colorDifference = rDiff * rDiff + gDiff * gDiff + bDiff * bDiff + aDiff * aDiff;

        // Check if the squared magnitude is within the tolerance
        return colorDifference <= tolerance * tolerance;
    }
}
