using UnityEngine;
using UnityEngine.UI;

public class UFOHealthBar : MonoBehaviour
{
    public Health health;//Health component

    public Image fillImage;//Filled image used as health bar

    private Camera mainCamera;//Main camera reference

    private void Start()
    {
        mainCamera = Camera.main;//Find main camera

        if (health == null)
        {
            health = GetComponentInParent<Health>();//Find health on parent UFO
        }
    }

    private void LateUpdate()
    {
        if (health != null && fillImage != null)
        {
            fillImage.fillAmount = health.currentHealth / health.maxHealth;//Update health bar
        }

        if (mainCamera != null)
        {
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);//Face camera
        }
    }
}
