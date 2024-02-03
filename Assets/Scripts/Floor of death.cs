using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField] private Image _image;

    void Start()
    {

        Debug.Log(GameOverSystemManager.lastScene);

        DisplayPreviousSceneInfo(GameOverSystemManager.lastScene);
    }

    private void DisplayPreviousSceneInfo(int previousSceneIndex)
    {
        Debug.Log(previousSceneIndex);

        if (set1BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 1.");
            _image.sprite = Icon1;
        }
        else if (set2BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 2.");
            _image.sprite = Icon2;
        }
        else if (set3BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 3.");
            _image.sprite = Icon3;
        }
        else if (set4BuildIndices.Contains(previousSceneIndex))
        {
            Debug.Log("Previous scene is in set 4.");
            _image.sprite = Icon4;
        }
    }
}