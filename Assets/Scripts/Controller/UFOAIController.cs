using UnityEngine;

public class UFOAIController : MonoBehaviour
{
    public UFOPawn pawn;//UFO pawn being controlled

    public Transform target;//Player

    private void Awake()
    {
        if (pawn == null)
        {
            pawn = GetComponent<UFOPawn>();//Find pawn if not assigned
        }

        if (target == null)
        {
            PlayerController player = FindFirstObjectByType<PlayerController>();//Find player controller in scene

            if (player != null)
            {
                target = player.transform;//Use player transform as target
            }
        }
    }

    private void Update()
    {
        if (pawn == null)//No pawn
        {
            return;
        }

        if (target == null)//No player target
        {
            return;
        }

        pawn.MoveToward(target.position);//Move UFO toward player
    }
}
