
using System;
using UnityEngine;

public class ColorSyn : MonoBehaviour
{
    [SerializeField] ColorDetector player1;
    [SerializeField] ColorDetector player2;

    SpriteRenderer r1;
    SpriteRenderer r2;


    void Start()
    {
        player1.OnColorChange += ColorChange;
        player2.OnColorChange += ColorChange;
        r1 = player1.GetComponent<SpriteRenderer>();
        r2 = player2.GetComponent<SpriteRenderer>();


    }

    private void Joim(Color color)
    {
        Debug.Log("sln");
    }

    private void ColorChange(Color color)
    {
        Debug.Log(color);

        //if(player1.spriteRenderer != null ) 
        r1.color = color;
        r2.color = color;
        
        //player1.spriteRenderer.color = color;

        

        //if( player2.spriteRenderer != null) 
        
        //player2.spriteRenderer.color =  color;

        

    }
}
