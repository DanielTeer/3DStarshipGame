using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public abstract void MoveForward(float direction);
    public abstract void Yaw(float direction);
    public abstract void Roll(float direction);
    public abstract void Pitch(float direction);
}
