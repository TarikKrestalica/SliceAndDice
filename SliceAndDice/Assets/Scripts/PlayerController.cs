using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed and rotation controls
    [Range(0, 10f)]
    [SerializeField] float speed;
    [Range(0, 180f)]
    [SerializeField] float rotationSpeed;

    // Player movement
    Vector3 horVel;
    Vector3 vertVel;
    Vector3 combVel;

    // Update is called once per frame
    void Update()
    {
        RunMovementLogic();
        RunRotationLogic();
    }

    void RunMovementLogic()
    {
        horVel = this.transform.right * Input.GetAxis("Horizontal");
        vertVel = this.transform.forward * Input.GetAxis("Vertical");

        combVel = horVel + vertVel;

        if(combVel.magnitude > 1)
        {
            combVel = combVel.normalized;
        }

        transform.Translate(combVel * speed * Time.deltaTime, Space.World);
        
    }

    void RunRotationLogic()
    {
        if (combVel != Vector3.zero && Input.GetAxis("Vertical") > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(combVel, Vector3.up);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
