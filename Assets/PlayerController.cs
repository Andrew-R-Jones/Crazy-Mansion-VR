using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{

    public SteamVR_Action_Vector2 input;
    public float speed = 1.5f;
    private CharacterController characterController;

    private void Start()
    {
        // added charactercontroller to be able to move on things with collisions and slope, ie the staircase.
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // get the direction from the joystick to move player in that direction
        // hmdtransform is using to always move move player in the direction of the joystick with reference to where they are looking
        // project on plane is used to ensure the player is always horizontal
        if (input.axis.magnitude > 0.1f) // if statement so that the telport will not interup the walking locomation
        {
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
            Vector3 gravity = new Vector3(0, 9.81f, 0) * Time.deltaTime;
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - gravity);
        }
    }
}
