using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBarGraphics;
    [SerializeField] Slider hBSlider;
    [SerializeField] Slider eHBSlider;
    Hp hp;
    float lerpSpeed = 0.1f;
    private void Start()
    {
        hp = transform.root.GetComponent<Hp>();
        hBSlider.maxValue = hp.MaxHealth;
        eHBSlider.maxValue = hp.MaxHealth;
        hBSlider.value = hp.Health;
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        if(hBSlider.maxValue != hp.MaxHealth || eHBSlider.maxValue != hp.MaxHealth )
        {
            hBSlider.maxValue = hp.MaxHealth;
            eHBSlider.maxValue = hp.MaxHealth;
         
        }
        if (hp.Health != hBSlider.value) {
            hBSlider.value = hp.Health;
        }
        if (!healthBarGraphics.activeSelf && hp.MaxHealth != hp.Health)
        {
            if (GetComponent<PlayerStats>() == null) {
                healthBarGraphics.SetActive(true);
            }
        }
       
        if (eHBSlider.value != hBSlider.value)
        {
            eHBSlider.value = Mathf.Lerp(eHBSlider.value, hp.Health, lerpSpeed);
        }        
    }
}
