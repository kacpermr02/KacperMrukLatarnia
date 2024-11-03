using UnityEngine;
using UnityEngine.SceneManagement;

public class LightSystem : MonoBehaviour
{
    [SerializeField] int lightDecay = 25000;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 10f;

    Light myLight;

    private void Start() 
    {
        myLight = GetComponent<Light>();
    }

    private void Update() 
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
        myLight.spotAngle -= angleDecay * Time.deltaTime;
        myLight.innerSpotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        if (myLight.intensity <= 0)
        {
            SceneManager.LoadSceneAsync(3);
        }
        else 
        {
        myLight.intensity -= lightDecay * Time.deltaTime;
        }
    }
}
