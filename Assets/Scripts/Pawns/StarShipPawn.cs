using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StarShipPawn : Pawn
{
    public float thrustForce = 20f;//Movement force

    public float yawSpeed = 90f;//Yaw rotation speed 

    public float rollSpeed = 90f;//Roll rotation speed 

    public float pitchSpeed = 90f;//Pitch rotation speed 

    public float customGravity = 2f;//New gravity

    public float linearDamping = 1f;//Drag

    public float angularDamping = 1f;//Rotation Drag

    private Rigidbody rb;//Name the private variable

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();// Get the Rigidbody attached to the same GameObject.

        rb.useGravity = false;//Normal gravity too strong

        rb.linearDamping = linearDamping;//Names the rigid body dampening
        rb.angularDamping = angularDamping;
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * customGravity, ForceMode.Acceleration);//Adds weaker custom gravity downward
    }

    public override void MoveForward(float direction)
    {
        // direction will usually be 1 for forward or -1 for backward.
        rb.AddForce(transform.forward * thrustForce * direction, ForceMode.Force);
    }

    public override void Yaw(float direction)
    {
        // Yaw is rotation around the ship's y axis.
        transform.Rotate(Vector3.up * yawSpeed * direction * Time.fixedDeltaTime, Space.Self);
    }

    public override void Roll(float direction)
    {
        // Roll is rotation around the ship's z axis.
        transform.Rotate(Vector3.forward * rollSpeed * direction * Time.fixedDeltaTime, Space.Self);
    }

    public override void Pitch(float direction)
    {
        // Pitch is rotation around the ship's x axis.
        transform.Rotate(Vector3.right * pitchSpeed * direction * Time.fixedDeltaTime, Space.Self);
    }
}
