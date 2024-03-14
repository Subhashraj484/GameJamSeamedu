using Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;
using UnityEditor.ShaderGraph.Internal;

public class Detector : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] LayerMask detectionLayer;
    bool detected;
    Vector3 direction;
    float angle ;
    float lowLeftAngle = 3.5f;
    float lowRightAngle = -3.5f;
    float topLeftAngle = 21f;
    float topRightAngle = 8f;
    bool inSight;

    void Update()
    {
        direction = player.position - transform.position;
        direction.Normalize();

        // angle = MathF.Tan(direction.x/direction.y);
        angle = Vector2.Angle(player.position , transform.position);

        if(angle <=lowLeftAngle && angle > lowRightAngle)
        {
            inSight = true;
        }
        else
        {
            inSight = false;
        }

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position , direction ,100f   ,detectionLayer);
        if(hitinfo.collider.CompareTag("Player"))
        {
            
            detected = true;
        }
        else
        {
            detected = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position , direction*100f);
    }
}