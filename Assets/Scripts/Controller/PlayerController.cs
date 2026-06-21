using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Pawn pawn;//The pawn that this controller is assigned

    public Shooter shooter;//Shooter reference

    private void Awake()
    {
        if (pawn == null)//Grabs pawn if not assigned
        {
            pawn = GetComponent<Pawn>();
        }

        if (shooter == null)//Finds shooter if available
        {
            shooter = GetComponent<Shooter>();
        }
    }

    private void FixedUpdate()//Fixed for physics
    {

        if (pawn == null)//Prevents the error if pawn isn't used
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))//Foward
        {
            pawn.MoveForward(1f);
        }

        if (Input.GetKey(KeyCode.S))//Back
        {
            pawn.MoveForward(-1f);
        }

        if (Input.GetKey(KeyCode.A))//Left
        {
            pawn.Yaw(-1f);
        }

        if (Input.GetKey(KeyCode.D))//Right
        {
            pawn.Yaw(1f);
        }

        // Q and E cause roll.
        if (Input.GetKey(KeyCode.Q))//Roll Left
        {
            pawn.Roll(1f);
        }

        if (Input.GetKey(KeyCode.E))//Roll right
        {
            pawn.Roll(-1f);
        }

        // Z and X cause pitch.
        if (Input.GetKey(KeyCode.Z))//Up
        {
            pawn.Pitch(-1f);
        }

        if (Input.GetKey(KeyCode.X))//Down
        {
            pawn.Pitch(1f);
        }
    }

    private void Update()
    {
        if (Time.timeScale <= 0f)//If game is paused or in menu
        {
            return;//Do not allow shooting
        }

        if (Input.GetMouseButtonDown(0))//Left mouse button shoots
        {
            if (shooter != null)//Checks if shooter exists
            {
                shooter.Shoot();//Calls the Shoot function
            }
        }
    }
}
