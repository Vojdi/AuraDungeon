using UnityEngine;
using UnityEngine.UI;


public class AuraBar : MonoBehaviour
{
    [SerializeField] GameObject auraBarGraphics;
    [SerializeField] Slider aBSlider;
    [SerializeField] Slider eaBSlider;
    [SerializeField] TMPro.TMP_Text AuraFeelText; 
    float lerpSpeed = 0.1f;

    private void Update()
    {
        if (PlayerStats.Instance.Aura != aBSlider.value)
        {
            aBSlider.value = PlayerStats.Instance.Aura;
        }
        if (eaBSlider.value != aBSlider.value)
        {
            eaBSlider.value = Mathf.Lerp(eaBSlider.value, PlayerStats.Instance.Aura, lerpSpeed);
        }
        if(PlayerStats.Instance.Aura < 3)
        {
            AuraFeelText.text = "No one feels your Aura";
        }else if(PlayerStats.Instance.Aura < 5)
        {
            AuraFeelText.text = "Basic enemies feel your Aura";
        }
        else
        {
            AuraFeelText.text = "Everyone feels your Aura";
        }
    }
}
