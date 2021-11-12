using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    
    private Rigidbody rb;
    
    public float speed = 1f;

    private bool isFinished = false;

    public GameObject raycast1;
    public GameObject raycast2;

    public int tile1Left = 10;
    public int tile2Left = 10;

    public int percentage = 0;
    public Text percentageText;

    public Animator animator;
    public float animatorSpeed = 1f;

    public GameObject destination;

    public deathMenu deathMenu;

    private float nextActionTime = 0.0f;
    public float period = 2f;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
        raycast1.SetActive(false);
        raycast2.SetActive(false);
        percentageText.gameObject.SetActive(false);
        


    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", animatorSpeed);



        //add force on the z direction continously as long as player comes to final stage or hit an obstacle
        if (isFinished == false)
        {
            rb.AddForce(Vector3.forward * Time.deltaTime * speed, ForceMode.Impulse);
            
            //Since I am using force to move the player, here I added drag to slow down the acceleration and 
            //make player speed more balanced with the enemy AIs.
            if (Time.time > nextActionTime)
            {
                if (nextActionTime <= 15f)
                {
                    nextActionTime = Time.time + period;
                    rb.drag += 0.01f;
                }
                
            }
        }
        else
        {
            //switch from running state to idle state
            animatorSpeed = 0f;

            //set player speed to zero if they reached to final stage
            rb.velocity = Vector3.zero;

            //to show percentage text
            percentageText.gameObject.SetActive(true);

            //--Raycast mechanics for painting to red--.

            //In this part I used two empty game objects child of to the main player.
            //Both game objects has different y positions to set origin location of the rays.

            //They will be inactive at first, when the player reaches the final part,
            //game object with the lower 'y' value will be activated and will start to fire rays.

            raycast1.SetActive(true);
            RaycastHit hit;
            if (Physics.Raycast(raycast1.transform.position, Vector3.forward, out hit))
            {
                //Get the renderer of the object ray hitted.
                var hitRenderer = hit.transform.GetComponent<Renderer>();
                //If the object ray hitted is initally white, it's coler will change to red.
                if (hitRenderer.material.color == Color.white)
                {
                    hit.transform.GetComponent<Renderer>().material.color = Color.red;

                    //to count how many tiles left.
                    tile1Left -= 1;
                    //to count percentage of how much of the wall is painted.
                    percentage += 5;
                    percentageText.text = ((int)percentage).ToString() + "% red wall!";


                }
                //When there is no tile left at the below part, next game object will be 
                //activated for raycasting.
                if (tile1Left == 0)
                {
                    raycast1.SetActive(false);
                    raycast2.SetActive(true);
                    RaycastHit hit2;

                    //same as the first raycasting.
                    if (Physics.Raycast(raycast2.transform.position, Vector3.forward, out hit2))
                    {
                        var hitRenderer2 = hit2.transform.GetComponent<Renderer>();
                        if (hitRenderer2.material.color == Color.white)
                        {
                            hit2.transform.GetComponent<Renderer>().material.color = Color.red;
                            tile2Left -= 1;
                            percentage += 5;
                            percentageText.text = ((int)percentage).ToString() + "% red wall!";

                            if (percentage == 100)
                            {
                                deathMenu.ToggleEndMenu();
                            }
                        }

                    }
                }


            }



        }

        ranking.rankingArray[0] = Vector3.Distance(gameObject.transform.position, destination.transform.position);



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("trigger");
        isFinished = true;

    }



}
