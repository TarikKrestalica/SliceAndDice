using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed and rotation controls
    [Range(0, 10f)]
    [SerializeField] float speed;
    [Range(0, 10000f)]
    [SerializeField] float jumpPower;

    // Player movement
    Vector3 vertVel;
    Vector3 horVel;
    Vector3 combVel;

    // Obstacle Collision
    private Obstacle curObstacle;

    private Rigidbody rigidbody;

    [SerializeField] private RectTransform groundCheckTransform;
    [SerializeField] private LayerMask groundMask;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (!rigidbody)
        {
            Debug.LogError("No rigidbody attached");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RunMovementLogic();
        RunJumpingLogic();
        
    }

    void RunMovementLogic()
    {
        horVel = -this.transform.right * Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical") >= 0)
        {
            vertVel = -this.transform.forward * Input.GetAxis("Vertical");
        }

        combVel = horVel + vertVel;
        if(combVel.magnitude > 1)
        {
            combVel = combVel.normalized;
        }

        transform.Translate(combVel * speed * Time.deltaTime, Space.World);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BreakableWall")
        {
            GameManager.goblin.SetIconEnabled(true);
            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (!obstacle)
            {
                Debug.Log("No obstacle component");
                return;
            }

            curObstacle = obstacle;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Breakable Wall")
        {
            GameManager.goblin.SetIconEnabled(false);
        }
    }


    public Obstacle GetCurrentObstacle()
    {
        return curObstacle;
    }

    public void GoToNextPoint()
    {
        GameManager.player.transform.position = curObstacle.GetTeleportationPoint().transform.position;
    }

    // Fix and tamper with
    void RunJumpingLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rigidbody.velocity.y != 0)
                return;

            rigidbody.velocity = Vector3.up * jumpPower * Time.deltaTime;
        }
    }


    public bool IsGroundedOnPlatform()
    {
        return Physics.CheckBox(groundCheckTransform.position, groundCheckTransform.position, Quaternion.identity, groundMask);
    }

}
