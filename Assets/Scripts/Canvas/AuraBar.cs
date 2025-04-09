using UnityEngine;
using UnityEngine.UI;


public class AuraBar : MonoBehaviour
{
    [SerializeField] GameObject auraBarGraphics;
    [SerializeField] Slider aBSlider;
    [SerializeField] Slider eaBSlider;
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
    }
}
