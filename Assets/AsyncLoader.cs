using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoader : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private GameObject loadLevelCanvas;
    [SerializeField] private Animator animator;

     [SerializeField] private Image[] loadingImages; // Array of loading images

    private bool IsAnimationPlaying = false;

    public static AsyncLoader instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(int levelID)
    {
        IsAnimationPlaying = true;
        loadingSlider.value = 0;
        loadLevelCanvas.SetActive(true);
        animator.SetTrigger("Play");
        StartCoroutine(LoadLevelAsync(levelID));
    }

    IEnumerator LoadLevelAsync(int levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;

            //UpdateImagesAlpha(progressValue);

            yield return null;
        }

        while (IsAnimationPlaying)
        {
            yield return null;
        }       
        loadLevelCanvas.SetActive(false);
    }

    private void OnAnimationEnd()
    {
        IsAnimationPlaying = false;
    }

    private void UpdateImagesAlpha(float progressValue)
    {
        // Update the alpha values of the loading images based on the loading progress
        for (int i = 0; i < loadingImages.Length; i++)
        {
            float alphaValue = progressValue * (i + 1) / loadingImages.Length;
            Color imageColor = loadingImages[i].color;
            imageColor.a = alphaValue;
            loadingImages[i].color = imageColor;
        }
    }
}
