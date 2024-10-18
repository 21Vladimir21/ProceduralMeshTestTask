using System.Collections.Generic;
using Enums;
using ShapeParameters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ShapesSettings
{
    public class CubeSettingsPanel : SettingsPanel
    {
        [SerializeField] private Slider xSlider;
        [SerializeField] private Slider ySlider;
        [SerializeField] private Slider zSlider;

        private void Start()
        {
            xSlider.onValueChanged.AddListener(ChangedSize);
            ySlider.onValueChanged.AddListener(ChangedSize);
            zSlider.onValueChanged.AddListener(ChangedSize);
        }

        public override void OpenPanel(List<IParameter> parameters)
        {
            base.OpenPanel(parameters);
            xSlider.value = GetValue<float>(EParameters.Wight, parameters);
            ySlider.value = GetValue<float>(EParameters.Height, parameters);
            zSlider.value = GetValue<float>(EParameters.Length, parameters);
        }


        private void ChangedSize(float _)
        {
            var list = new List<IParameter>
            {
                new FloatParameterValue(EParameters.Wight, xSlider.value),
                new FloatParameterValue(EParameters.Height, ySlider.value),
                new FloatParameterValue(EParameters.Length, zSlider.value)
            };
            onChangedSize.Invoke(list);
        }
    }
}