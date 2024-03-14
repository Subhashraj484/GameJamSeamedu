
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    [SerializeField] List<Transform> players = new();
    [SerializeField] LayerMask detectionLayer;
    [SerializeField] Transform[] points = new Transform[2];
    [SerializeField] float changeDistance = 2;
    [SerializeField] float moveSpeed = 10;
    bool detected;
    Vector3 direction;
    float angle ;
    float lowAngle = 45;
    float maxAngle = 125f;
    bool inSight;
    Color rayColor = Color.green;
    int currentIndex =0;
    

    void Update()
    {
        if(transform.position ==   Vector3.zero)
        {
            transform.position = new Vector3(0.1f,0,0);
        }
        
        Vector3 moveDirection = points[currentIndex].position;
        moveDirection.Normalize();
        if(Vector3.Distance(transform.position , points[currentIndex].position) < changeDistance)
        {
            currentIndex++;
            if(currentIndex > 1) currentIndex = 0;
        }
        transform.position += moveDirection*moveSpeed*Time.deltaTime;

        foreach(Transform player in players)
        {
            direction = player.position - transform.position;
            direction.Normalize();

        // angle = MathF.Tan(direction.x/direction.y);
        angle = Vector2.Angle(player.position , transform.position);

        if(angle <= maxAngle && angle > lowAngle)
        {
            inSight = true;
            rayColor = Color.red;
        }
        else
        {
            inSight = false;
            rayColor = Color.green;
        }

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position , direction ,100f   ,detectionLayer);
        if(hitinfo.collider != null && hitinfo.collider.CompareTag("Player") && inSight )
        {
            
            detected = true;
        }
        else
        {
            detected = false;
        }
        

        Debug.DrawRay(transform.position , direction*100f , rayColor);
        }
        
        
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.Draw(transform.position , direction*100f , rayColor);
    // }
}