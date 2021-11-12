using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    private Rigidbody rb;
    NavMeshAgent agent;
    public float agentSpeed = 0.5f;

    public Animator animator;
    public float animatorSpeed = 1f;

    public GameObject destination;

    private Vector3 initialPos;

    public static float distance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();

        animator.SetFloat("Speed", animatorSpeed);

        agent.SetDestination(destination.transform.position);

        initialPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        ranking.rankingArray[1] = Vector3.Distance(gameObject.transform.position, destination.transform.position);
        
        if (gameObject.transform.position == destination.transform.position)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
           gameObject.transform.position = initialPos;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        
        Destroy(gameObject);
    }
}
