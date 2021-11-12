using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalObstacle : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 position;
    private float minX = -8.2f;
    private float maxX = 8.2f;

    //public float obstacleSpeed = 7f;
    private int obstacleSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        obstacleSpeed = Random.Range(7, 9);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (transform.position.x >= maxX)
        {
            rb.AddForce(Vector3.left * Time.deltaTime * obstacleSpeed, ForceMode.Impulse);
            //position = position + Vector3.left;
        }
        if (transform.position.x <= minX)
        {
            rb.AddForce(Vector3.right * Time.deltaTime * obstacleSpeed, ForceMode.Impulse);
        }
        
    }
}
