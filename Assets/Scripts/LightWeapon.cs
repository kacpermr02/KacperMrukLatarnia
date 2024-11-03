using StarterAssets;
using UnityEngine;
using System.Collections;

public class LightWeapon : MonoBehaviour
{
    [SerializeField] int damageAmount = 1;
    StarterAssetsInputs starterAssetsInputs;
    Light myLight;

    private Color originalColor;
    private bool isCoroutineRunning = false;
    private float delayTime = 0.5f;

    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        ShineFight();
    }

    void ShineFight()
    {
        if (!starterAssetsInputs.shine) return;

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            ShipHealth shipHealth = hit.collider.GetComponent<ShipHealth>();
            enemyHealth?.TakeDamge(damageAmount);
            shipHealth?.TakeDamge(damageAmount);

            if (myLight == null)
            {
                GameObject lightObject = GameObject.Find("Spot Light");
                myLight = lightObject.GetComponent<Light>();
                originalColor = myLight.color;
            }

            myLight.color = Color.green;

            if (!isCoroutineRunning)
            {
                StartCoroutine(ResetLightColorAfterDelay(delayTime));
            }

            starterAssetsInputs.ShineInput(false);
        }
    }

    IEnumerator ResetLightColorAfterDelay(float delay)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(delay);
        
        if (myLight != null)
        {
            myLight.color = originalColor;
        }
        isCoroutineRunning = false;
    }
}
