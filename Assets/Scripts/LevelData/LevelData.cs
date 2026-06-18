using UnityEngine;

// This script stores information about the level.
public class LevelData : MonoBehaviour
{
    [Header("Level Size")]
    [Tooltip("The size of this test level in meters.")]
    public Vector3 levelSize = new Vector3(100f, 100f, 100f);

    [Header("Level References")]
    [Tooltip("The ground object for this level.")]
    public GameObject groundObject;

    [Tooltip("Extra mesh objects placed in the level so the player can see movement.")]
    public GameObject[] referenceObjects;
}
