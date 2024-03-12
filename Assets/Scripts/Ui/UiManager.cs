using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI waveTimerText;

    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private Animator currencyTextAnimator;

    [SerializeField] private Slider roundTimerSlider;
    private bool needToUpdateSlider;
    public float timeSpeed = 1;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (needToUpdateSlider)
        {
            roundTimerSlider.value += Time.deltaTime / timeSpeed;

            // Update the condition accordingly if needed
            if (roundTimerSlider.value >= roundTimerSlider.maxValue)
            {
                needToUpdateSlider = false;
            }
        }
    }

    public void SetLivesText(int amount)
    {
        livesText.text = amount.ToString();
    }

    public void SetWaveTimer(int time)
    {
        waveTimerText.gameObject.SetActive(true);
        waveTimerText.text = time.ToString();
    
        if(time <= 0)
        {
            waveTimerText.gameObject.SetActive(false);
        }
    }

    public void SetCurrencyText(int currency)
    {
        currencyText.text = currency.ToString();
    }

    public void NotEnoughCurrencyAnimation()
    {
        currencyTextAnimator.SetTrigger("Play");
    }

    public void SetRoundSliderInitialValue(float maxValue)
    {
        needToUpdateSlider = true;
        roundTimerSlider.maxValue = maxValue;
        roundTimerSlider.value = 0;
    }
}
