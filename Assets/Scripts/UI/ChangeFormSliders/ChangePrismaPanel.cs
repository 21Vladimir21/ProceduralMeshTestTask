using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ChangeFormSliders
{
    public class ChangePrismaPanel : MonoBehaviour
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