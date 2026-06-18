using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//Object camera follows

    public Vector3 offsetDirection = new Vector3(0f, 3f, -8f);//Camera offset

    public float offsetMagnitude = 1f;//Camera multiplyer magnitude

    public float minOffsetMagnitude = 0.5f;//Minimum camera distance

    public float maxOffsetMagnitude = 3f;//Max Camera distance

    public float offsetChangeSpeed = 1f;//Speed of Camera Zoom

    public float lookAheadDistance = 5f;//Camera view distance

    public float lookHeightOffset = 1f;// How high camera is

    public float followSmoothness = 5f;//Smooths out camera movement

    public float rotationSmoothness = 5f;//Camera rotation speed

    private void LateUpdate()//Before movement update.
    {

        if (target == null)//Checks if target is there
        {
            return;
        }

        HandleOffsetInput();//Looks for key press
        FollowTarget();//Time.DeltaTime movement for camera
        LookAtTargetPoint();//Time.DeltaTaime smooth rotation
    }

    private void HandleOffsetInput()
    {
        if (Input.GetKey(KeyCode.O))// O increases the camera offset magnitude.
        {
            offsetMagnitude += offsetChangeSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.L))// L decreases the camera offset magnitude.
        {
            offsetMagnitude -= offsetChangeSpeed * Time.deltaTime;
        }

        offsetMagnitude = Mathf.Clamp(offsetMagnitude, minOffsetMagnitude, maxOffsetMagnitude);//Clamp limits the min and max offset
    }

    private void FollowTarget()
    {
        Vector3 normalizedOffset = offsetDirection.normalized * offsetMagnitude;//set direction to 1 then multiply by offsetMagnitude to controll distance

        Vector3 desiredPosition = target.position + target.TransformDirection(normalizedOffset);//Worldspace allows offset to follow ships rotation

        // Lerp smoothly moves from the current position toward the desired position.
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmoothness * Time.deltaTime);//Lerp used new position with framerate follow
    }

    private void LookAtTargetPoint()
    {
        Vector3 lookPoint =target.position + target.forward * lookAheadDistance + target.up * lookHeightOffset;//Game object to look at with height and distance

        Quaternion desiredRotation = Quaternion.LookRotation(lookPoint - transform.position);//Rotation speed needed

        // Smoothly rotate toward that direction.
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothness * Time.deltaTime);//Uses rotation speed needed to move camera
    }
}