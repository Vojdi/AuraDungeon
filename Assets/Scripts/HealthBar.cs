using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBarGraphics;
    [SerializeField] Slider hBSlider;
    [SerializeField] Slider eHBSlider;
    [SerializeField] TMPro.TMP_Text hpText;
    Hp hp;
    float lerpSpeed = 0.04f;
    
    private void Start()
    {
        hp = transform.root.GetComponent<Hp>();
        hBSlider.maxValue = hp.MaxHealth;
        eHBSlider.maxValue = hp.MaxHealth;
        hBSlider.value = hp.Health;
        hpText.text = hp.MaxHealth.ToString();
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        if (hp.Health != hBSlider.value) {
            hpText.text = hp.Health.ToString();
            hBSlider.value = hp.Health;
        }
        if (!healthBarGraphics.activeSelf && hp.MaxHealth != hp.Health)
        {
            healthBarGraphics.SetActive(true);
        }
       
        if (eHBSlider.value != hBSlider.value)
        {
            eHBSlider.value = Mathf.Lerp(eHBSlider.value, hp.Health, lerpSpeed);
        }        
    }
}
