using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float rotateSpeed = 45f;//How fast the object spins

    private void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);//Spin around world Y axis
    }
}