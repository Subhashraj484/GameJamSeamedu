using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager Instance {get ; private set;}

    void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("There exists more than one InputManager in the scene");
            Destroy(this);
        }
        Instance = this;
    }
    
    #endregion

    public event Action Jump;
    Vector3 moveValue;
    int x_axis;
    bool jump;
    
    private void Update() {
        if(Input.GetKey(KeyCode.A))
        {
            x_axis = -1;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            x_axis = 1;
        }
        else
        {
            x_axis = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump?.Invoke();
        }

        moveValue = new Vector3(x_axis , 0 , 0);
    }

    public Vector3 MoveDirectionV3 => moveValue;
    public Vector2 MoveDirectionV2 => new Vector2(moveValue.x , moveValue.y);
}
