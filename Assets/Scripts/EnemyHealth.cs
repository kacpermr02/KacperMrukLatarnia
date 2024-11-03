using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 2;
    public int currentHealth;
    NavMeshAgent speedValue;
    Transform transformShip;
    
    void Awake() 
    {
        currentHealth = startingHealth;
    }

    public void TakeDamge(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
        else if (currentHealth == 1)
        {
            speedValue = GetComponentInParent<NavMeshAgent>();
            speedValue.speed = 0;
            transformShip = GetComponentInParent<Transform>();
            Vector3 newRotation = transformShip.eulerAngles;
            newRotation.x = -44;
            transformShip.eulerAngles = newRotation;
        }
    }
}
