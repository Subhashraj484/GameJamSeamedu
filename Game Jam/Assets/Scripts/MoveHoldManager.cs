using System;
using UnityEngine;

public class MoveHoldManager : MonoBehaviour
{
    [SerializeField] MoveTileHolder leftTileHolder;
    [SerializeField] MoveTileHolder RightTileHolder;
    [SerializeField] MoveTileHolder JumpTileHolder;

    bool leftMovevalue;
    bool rightMovevalue;
    bool jumpMovevalue;

    private void Start() {
        leftTileHolder.OnMoveChanged += SetMoveTilesActive;
        RightTileHolder.OnMoveChanged += SetMoveTilesActive;
        JumpTileHolder.OnMoveChanged += SetMoveTilesActive;
    }

    void SetMoveTilesActive(MoveAction moveAction , bool active)
    {
        Debug.Log(moveAction);
        // Debug.Log(active);
        switch(moveAction)
        {
            case MoveAction.Left:
            leftMovevalue = active;
            break;

            case MoveAction.Right :
            rightMovevalue = active;

            break;

            case MoveAction.Jump :
            jumpMovevalue = active;

            break;

            default :
            Debug.Log("nooo");
            break;

        }
    }


    public event Action Jump;
    Vector3 moveValue;
    int x_axis;
    bool jump;
    
    private void Update() {
        if(Input.GetKey(KeyCode.A) && leftMovevalue)
        {
            x_axis = -1;
        }
        else if(Input.GetKey(KeyCode.D) && rightMovevalue)
        {
            x_axis = 1;
        }
        else
        {
            x_axis = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space) && jumpMovevalue)
        {
            Jump?.Invoke();
        }

        moveValue = new Vector3(x_axis , 0 , 0);
    }

    public Vector3 MoveDirectionV3 => moveValue;
    public Vector2 MoveDirectionV2 => new Vector2(moveValue.x , moveValue.y);
}
