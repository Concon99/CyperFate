using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAttackManager : MonoBehaviour
{
    [SerializeField] private B1Attack1 _B1Attack1;
    [SerializeField] private B1Attack2 _B1Attack2;
    [SerializeField] private B1Attack3 _B1Attack3; 
    [SerializeField] private BossHealth _BossHealth;
    public float WaitTime = 5f;
    public float TimeBeforeAttacks;
    public int sceneBuildIndex = 5;  // Set to 5 for testing

    private void Start()
    {
        StartCoroutine(ContinuousAttacks());
    }

    private IEnumerator ContinuousAttacks()
    {
        print("ContinuousAttacks started");
        yield return new WaitForSeconds(TimeBeforeAttacks);

        while (_BossHealth.BHealth > 0f)
        {
            print("New attack");
            int randomAttack = Random.Range(1, 4);
            print(randomAttack);

            if (randomAttack == 1)
            {
                print("Performing Attack 1");
                _B1Attack1.Attack1();
            }
            if (randomAttack == 2)
            {
                print("Performing Attack 2");
                _B1Attack2.Attack2();
            }
            if (randomAttack == 3)
            {
                print("Performing Attack 3");
                _B1Attack3.Attack3();
            }

            yield return new WaitForSeconds(WaitTime);
        }

        // Log the active scene name and build index
        Scene activeScene = SceneManager.GetActiveScene();
        print("Active Scene Name: " + activeScene.name);
        print("Active Scene Build Index: " + activeScene.buildIndex);

        // Log the previous scene index
        PlayerPrefs.SetInt("PreviousSceneIndex", activeScene.buildIndex);
        print("Previous Scene Index: " + PlayerPrefs.GetInt("PreviousSceneIndex"));

        // Load the next scene
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        print("ContinuousAttacks ended");
    }
}