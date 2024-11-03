using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 1;
    public int currentHealth;
    
    void Awake() 
    {
        currentHealth = startingHealth;
    }

    public void TakeDamge(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
