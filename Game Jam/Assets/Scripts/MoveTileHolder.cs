using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D) , typeof(BoxCollider2D))]

public class MoveTileHolder : MonoBehaviour
{
    [SerializeField] MoveAction moveAction;
    [SerializeField] MoveAction allowedMoveAction;
    public event Action< MoveAction, bool> OnMoveChanged;
    bool kept ;


    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<BoxCollider2D>().isTrigger =true;
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag("MoveTile"))
        {
            MoveAction currentMoveAction = other.gameObject.GetComponent<MoveTile>().moveAction;
            if(currentMoveAction != allowedMoveAction) return;

            other.gameObject.GetComponent<MoveTile>().isDragging = false;
            other.transform.position = transform.position;
            OnMoveChanged?.Invoke(allowedMoveAction , true);
            // Debug.Log(allowedMoveAction);
            kept = true;
        }
    }

void OnTriggerExit2D(Collider2D other)
{
    if(!kept) return;
    if(other.transform.CompareTag("MoveTile"))
        {
            OnMoveChanged?.Invoke(allowedMoveAction , false);
            Debug.Log(false);
            kept = false;
            
        }
}


}
