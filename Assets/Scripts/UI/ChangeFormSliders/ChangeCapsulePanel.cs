using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ChangeFormSliders
{
    public class ChangeCapsulePanel : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<int, float,float> onChanged;
        [SerializeField] private Slider smoothnessSlider;
        [SerializeField] private Slider radiusSlider;
        [SerializeField] private Slider heightSlider;

        private void Start()
        {
            smoothnessSlider.onValueChanged.AddListener(_ => ValuesChanged());
            radiusSlider.onValueChanged.AddListener(_ =>  ValuesChanged());
            heightSlider.onValueChanged.AddListener(_ =>  ValuesChanged());
        }


        public void OpenPanel(int smoothness, float radius,float height)
        {
            gameObject.SetActive(true);
            smoothnessSlider.value = smoothness;
            radiusSlider.value = radius;
            heightSlider.value = height;
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
        }
        private void ValuesChanged() => onChanged.Invoke((int)smoothnessSlider.value, radiusSlider.value, heightSlider.value);
    }
}
