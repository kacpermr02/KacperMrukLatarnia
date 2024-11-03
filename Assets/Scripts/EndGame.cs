using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        CheckIfAnyEnemyLives();
    }

    private void CheckIfAnyEnemyLives()
    {
        GameObject enemyCheck = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyCheck == null)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}
