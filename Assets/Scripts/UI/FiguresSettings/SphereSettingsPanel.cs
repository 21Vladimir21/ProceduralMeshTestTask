using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.FiguresSettings
{
    public class SphereSettingsPanel : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<int, float> onChanged;
        [SerializeField] private Slider smoothnessSlider;
        [SerializeField] private Slider radiusSlider;

        private void Start()
        {
            smoothnessSlider.onValueChanged.AddListener(_ => ValuesChanged());
            radiusSlider.onValueChanged.AddListener(_ => ValuesChanged());
        }


        public void OpenPanel(int smoothness, float radius)
        {
            onChanged.RemoveAllListeners();
            gameObject.SetActive(true);
            smoothnessSlider.value = smoothness;
            radiusSlider.value = radius;
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }
        private void ValuesChanged() => onChanged.Invoke((int)smoothnessSlider.value, radiusSlider.value);
    }
}