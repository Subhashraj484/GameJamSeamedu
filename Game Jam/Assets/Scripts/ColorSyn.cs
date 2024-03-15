
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] ColorDetector player1;
    [SerializeField] ColorDetector player2;


    void Start()
    {
        player1.OnChnageColor += ColorChange;
        player1.OnChnageColor += ColorChange;
    }

    private void ColorChange(Color color)
    {
        if(player1.spriteRenderer == null && player2.spriteRenderer == null) return;
        player1.spriteRenderer.color = color;
        player2.spriteRenderer.color =  color;

    }
}
