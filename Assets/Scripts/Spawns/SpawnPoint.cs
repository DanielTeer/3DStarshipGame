using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;//The prefab this spawn point will create

    public GameObject Spawn(Transform spawnedObjectsParent)
    {
        if (prefabToSpawn == null)//No prefab assigned
        {
            return null;//Spawn nothing
        }

        GameObject spawnedObject = Instantiate(prefabToSpawn, transform.position, transform.rotation, spawnedObjectsParent);//Create object

        return spawnedObject;//Return the object that was created
    }
}
