using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Damageable playerDamageable; 

    private bool isGameOver = false;

    private void OnEnable()
    {

        CharacterEvents.characterDamaged += CharacterTookDamage;
    }

    private void OnDisable()
    {

        CharacterEvents.characterDamaged -= CharacterTookDamage;
    }

    private void Update()
    {

        if (!isGameOver && playerDamageable != null && playerDamageable.Health <= 0)
        {

            isGameOver = true;
            StartCoroutine(LoadGameOverSceneWithDelay(5f)); 
        }
    }

    private IEnumerator LoadGameOverSceneWithDelay(float delay)
    {

        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(4); 
    }

}
