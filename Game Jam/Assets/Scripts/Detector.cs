
using System.Collections.Generic;
using UnityEngine;


public class Detector : MonoBehaviour
{

    [SerializeField] Transform player1;
    [SerializeField] Transform player2;
    [SerializeField] LayerMask detectionLayer;
    [SerializeField] Transform[] points = new Transform[2];
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float changeDistance = 2;
    bool detected;
    Vector3 direction;

    float lowAngle = 40;
    float maxAngle = 125f;
    bool inSight;
    Color rayColor = Color.green;
    RaycastHit2D hitinfoPlayer1;
    RaycastHit2D hitinfoPlayer2;
    int currentIndex =0;
    float testangle;

    

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

        Vector3 player1Direction = player1.position - transform.position;
        Vector3 player2Direction = player2.position - transform.position;

        hitinfoPlayer1 = Physics2D.Raycast(transform.position , player1Direction , 100f , detectionLayer);
        hitinfoPlayer2 = Physics2D.Raycast(transform.position , player2Direction , 100f , detectionLayer);

        if(hitinfoPlayer1.collider != null && hitinfoPlayer1.transform.CompareTag("Player"))
        {
            //player detected
            float player1Angle = Vector2.Angle(player1.position , transform.position);
            // testangle = player1Angle;
            // Debug.Log(player1Angle);

            if(player1Angle > lowAngle && player1Angle < maxAngle)
            {


                if(!hitinfoPlayer1.transform.GetComponent<ColorDetector>().Hidden)
                {
                    Debug.DrawRay(transform.position , player1Direction*100f , Color.red);

                }
            }

        }

        if(hitinfoPlayer2.collider != null && hitinfoPlayer2.transform.CompareTag("Player"))
        {
            //player2detected

            float player2Angle = Vector2.Angle(player2.position , transform.position);
            if(player2Angle > lowAngle && player2Angle < maxAngle)
            {
                if(!hitinfoPlayer2.transform.GetComponent<ColorDetector>().Hidden)
                {
                    Debug.DrawRay(transform.position , player2Direction*100f , Color.red);

                    
                }
            }

        }


        
        
        
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.Draw(transform.position , direction*100f , rayColor);
    // }
}