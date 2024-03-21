using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed and rotation controls
    [Range(0, 10f)]
    [SerializeField] float speed;

    // Player movement
    Vector3 vertVel;

    // Obstacle Collision
    private Obstacle curObstacle;

    // Update is called once per frame
    void Update()
    {
        RunMovementLogic();
        
    }

    void RunMovementLogic()
    {
        vertVel = -this.transform.forward * Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical") < 0)
            return;

        transform.Translate(vertVel * speed * Time.deltaTime, Space.World);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BreakableWall")
        {
            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (!obstacle)
            {
                Debug.Log("No obstacle component");
                return;
            }

            if(curObstacle == obstacle)
            {
                Debug.Log("Already have collided with this object");
                return;
            }

            curObstacle = obstacle;
            curObstacle.SetUpSliderValues();
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
}
