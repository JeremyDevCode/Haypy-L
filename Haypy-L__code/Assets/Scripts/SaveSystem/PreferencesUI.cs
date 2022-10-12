using UnityEngine;
using UnityEngine.UI;


public class PreferencesUI : MonoBehaviour
{
    [Header("Dependencies")]
    public PreferencesSystem prefSystem;
    public Slider volumeSlider;

    private void Start()
    {
        this.UpdateUI(this.prefSystem.volume);
    }

    public void UpdateUI(float volume)
    {
        this.volumeSlider.value = volume;
    }
}
