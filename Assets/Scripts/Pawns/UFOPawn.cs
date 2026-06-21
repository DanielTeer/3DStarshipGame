using UnityEngine;

public class UFOPawn : Pawn
{
    public float moveSpeed = 5f;//How fast UFO moves toward player

    public override void MoveForward(float direction)
    {
        transform.position += transform.forward * moveSpeed * direction * Time.deltaTime;//Moves without physics force
    }

    public override void Yaw(float direction)
    {
        transform.Rotate(Vector3.up * direction * 90f * Time.deltaTime, Space.Self);//Turns without physics force
    }

    public override void Roll(float direction)
    {
        transform.Rotate(Vector3.forward * direction * 90f * Time.deltaTime, Space.Self);//Rolls without physics force
    }

    public override void Pitch(float direction)
    {
        transform.Rotate(Vector3.right * direction * 90f * Time.deltaTime, Space.Self);//Pitches without physics force
    }

    public void MoveToward(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);//Moves toward player position

        Vector3 directionToTarget = targetPosition - transform.position;//Direction from UFO to player

        if (directionToTarget != Vector3.zero)//Prevents rotation error
        {
            transform.rotation = Quaternion.LookRotation(directionToTarget);//Faces player
        }
    }
}
