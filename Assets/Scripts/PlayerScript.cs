using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
public class PlayerScript : MonoBehaviour
{
    public float speed = 6f;
    CharacterController controller;
    float h, v;

    public float gravity = -9.8f;
    float velocity;

    public Transform[] waypoints;

    public GameObject gamePanel;

    public bool canMove = true;

    public int currentWaypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gamePanel.SetActive(false);
        MoveForward();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = v * speed;
        float moveZ = h * speed;
        Vector3 movement = new Vector3(0, 0, moveZ);
        movement = Vector3.ClampMagnitude(movement, speed);

       

        movement.y = velocity;
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        controller.Move(movement);

        if (canMove)
        {
            MoveToWaypoint();
        }

    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        if (canMove == true)
        {
            h = ctx.ReadValue<Vector2>().x;
            v = ctx.ReadValue<Vector2>().y;
        }
    }

    public void MoveForward()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            if(this.transform.position == waypoints[i].position)
            {
               transform.position = Vector2.MoveTowards(transform.position, waypoints[i + 1].position, speed * Time.deltaTime);
            }

        }
    }

    void MoveToWaypoint()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];

        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        //Move toward waypoint
        if (direction.magnitude > 0.2f)
        {
            direction = direction.normalized;
            controller.Move(direction * speed * Time.deltaTime);
        }
        else
        {
            //Snap to waypoint
            transform.position = target.position;

            //Move to next waypoint
            if (currentWaypointIndex < waypoints.Length - 1)
            {
                currentWaypointIndex++;

                //Rotate toward next waypoint
                Vector3 lookDir = waypoints[currentWaypointIndex].position - transform.position;
                lookDir.y = 0;

                if (lookDir != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(lookDir);
                }
            }

            //Stop and trigger game
            canMove = false;
            gamePanel.SetActive(true);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            canMove = false;
            gamePanel.SetActive(true);
            //destroy customer
            other.gameObject.SetActive(false);
        }
    }

}
