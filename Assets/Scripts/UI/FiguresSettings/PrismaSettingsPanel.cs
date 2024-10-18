using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.FiguresSettings
{
    public class PrismaSettingsPanel : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<float, float> onChanged;
        [SerializeField] private Slider radiusSlider;
        [SerializeField] private Slider heightSlider;

        private void Start()
        {
            radiusSlider.onValueChanged.AddListener(_ => ValuesChanged());
            heightSlider.onValueChanged.AddListener(_ => ValuesChanged());
        }


        public void OpenPanel(float radius, float height)
        {
            onChanged.RemoveAllListeners();
            gameObject.SetActive(true);
            radiusSlider.value = radius;
            heightSlider.value = height;
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }

        private void ValuesChanged() => onChanged.Invoke(heightSlider.value, radiusSlider.value);
    }
}