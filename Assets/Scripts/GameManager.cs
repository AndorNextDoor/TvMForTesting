using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private UiManager uiManager;

    [SerializeField] private int startingCurrency = 100;
    private int currentCurrency;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject levelCompleteScreen;

    [SerializeField] private int lives;

    public int enemiesAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        uiManager = UiManager.instance;
        currentCurrency = startingCurrency;
        uiManager.SetCurrencyText(currentCurrency);
        uiManager.SetLivesText(lives);
    }

    public void SetEnemiesAmount(int amount)
    {
        enemiesAmount = amount;
    }

    public void TakeDamage(int damage)
    {
        lives -= damage;
        UiManager.instance.SetLivesText(lives);

        if(lives <= 0)
        {
            OnGameOver();
        }
    }

    public void OnEnemyDestroyed()
    {
        Invoke("DecreaseEnemies", 0.3f);
    }

    private void DecreaseEnemies()
    {
        enemiesAmount--;
        if (enemiesAmount <= 0)
        {
            WaveSpawner.instance.needToSpawnWave = true;
        }
    }


    public void OnLevelCompletion()
    {
        levelCompleteScreen.SetActive(true);
        Time.timeScale = 0.2f;
    }

    private void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.2f;
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void GetCurrency(int amount)
    {
        currentCurrency += amount;
        uiManager.SetCurrencyText(currentCurrency);
    }

    public void SpendCurrency(int amount)
    {
        currentCurrency -= amount;
        uiManager.SetCurrencyText(currentCurrency);
    }

    public bool HaveEnoughCurrency(int cost)
    {
        if(currentCurrency < cost)
        {
            uiManager.NotEnoughCurrencyAnimation();
            return false;
        }
        else
        {
            return true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}