using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;//Bullet prefab

    public Transform firePoint;// point of bullet spawn

    public float fallbackSpawnDistance = 2f;//Forgot firePoint is ok

    public AudioClip shootSFX;//Shoot sound

    public void Shoot()
    {
        if (projectilePrefab == null)//If no bullet
        {
            return;//no boom
        }

        Vector3 spawnPosition;//Transform of spawn position
        Quaternion spawnRotation;//Rotation of spawn point

        if (firePoint != null)//If add fire point
        {
            spawnPosition = firePoint.position;//Use it to shoot
            spawnRotation = firePoint.rotation;
        }
        else//If i forgot
        {
            spawnPosition = transform.position + transform.forward * fallbackSpawnDistance;//Use the fallbackSpawnpoint
            spawnRotation = transform.rotation;
        }

        Instantiate(projectilePrefab, spawnPosition, spawnRotation);//Create a bullet at the transform and rotation.

        PlayerAudio playerAudio = GetComponent<PlayerAudio>();//Get PlayerAudio script

        if (playerAudio != null)//If PlayerAudio exists
        {
            playerAudio.PlayClip(shootSFX);//Play shoot sound
        }
    }
}
