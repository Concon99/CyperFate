using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorOfDeath : MonoBehaviour
{
    public List<int> set1BuildIndices = new List<int>();
    public List<int> set2BuildIndices = new List<int>();
    public List<int> set3BuildIndices = new List<int>();
    public List<int> set4BuildIndices = new List<int>();

    public Sprite Icon1;
    public Sprite Icon2;
    public Sprite Icon3;
    public Sprite Icon4;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the GameObject.");
            return;
        }

        // Retrieve the previous scene index from PlayerPrefs
        int previousSceneIndex = PlayerPrefs.GetInt("PreviousSceneIndex", 0);

        DisplayPreviousSceneInfo(previousSceneIndex);
    }

    private void DisplayPreviousSceneInfo(int previousSceneIndex)
    {
        Debug.Log(previousSceneIndex);

        if (set1BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 1.");
            spriteRenderer.sprite = Icon1;
        }
        else if (set2BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 2.");
            spriteRenderer.sprite = Icon2;
        }
        else if (set3BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 3.");
            spriteRenderer.sprite = Icon3;
        }
        else if (set4BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 4.");
            spriteRenderer.sprite = Icon4;
        }
    }
}