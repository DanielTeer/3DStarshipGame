using UnityEngine;

public class DeathDestroy : Death//Inherits from death.cs
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
