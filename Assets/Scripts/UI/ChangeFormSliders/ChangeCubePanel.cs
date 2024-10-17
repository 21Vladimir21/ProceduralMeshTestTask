using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ChangeFormSliders
{
    public class ChangeCubePanel : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<Vector3> onChangedSize;

        [SerializeField] private Slider xSlider;
        [SerializeField] private Slider ySlider;
        [SerializeField] private Slider zSlider;

        private void Start()
        {
            xSlider.onValueChanged.AddListener(_ =>
                onChangedSize.Invoke(new Vector3(xSlider.value, ySlider.value, zSlider.value)));
            ySlider.onValueChanged.AddListener(_ =>
                onChangedSize.Invoke(new Vector3(xSlider.value, ySlider.value, zSlider.value)));
            zSlider.onValueChanged.AddListener(_ =>
                onChangedSize.Invoke(new Vector3(xSlider.value, ySlider.value, zSlider.value)));
        }

        public void OpenPanel(Vector3 size)
        {
            onChangedSize.RemoveAllListeners();
            gameObject.SetActive(true);
            xSlider.value = size.x;
            ySlider.value = size.y;
            zSlider.value = size.z;
        }

        public void HidePanel()
        {
            gameObject.SetActive(false);
            onChangedSize.RemoveAllListeners();
        }
    }
}