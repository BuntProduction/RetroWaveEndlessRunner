using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    private bool isDead;

    private int desiredLane = 1; //0:left; 1:middle; 2:right
    public float laneDistance = 4; //distance between two lanes

    public float jumpForce;
    public float Gravity = -20;

    Animator animator;
    private bool isSliding = false;
    private ScoreManager theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.isGameStarted)
            return; //to don't start the game until you tap the screen
        //else forwardSpeed += 0.1f * Time.deltaTime; -> attemp to debug the fact that the player doesn't move

        if (forwardSpeed < maxSpeed) 
             forwardSpeed += 0.1f * Time.deltaTime;


        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        //Gather the inputs on which lane we should be
        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3) 
                desiredLane = 2;
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1) 
                desiredLane = 0;
        }

        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else controller.Move(diff);
        }

        controller.Move(direction * Time.deltaTime);

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
    }


    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacles")
        {
            isDead = true;
            animator.SetBool("isDead", true);
            

            forwardSpeed = 0;
            PlayerManager.gameOver = true;

            // forwardSpeed = 0;
            //FindObjectOfType<Music>().PlaySound("GameOver");

        }
    }

    private IEnumerator Slide()
    {
       
        isSliding = true;
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;
        direction.y += Gravity * Time.deltaTime * 20;
        yield return new WaitForSeconds(0.8f);//duration of the sliding
        direction.y += Gravity * Time.deltaTime;
        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;

        animator.SetBool("isSliding", false);
        isSliding = false;
    }
}
