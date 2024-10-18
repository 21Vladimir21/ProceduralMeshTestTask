using System.Collections.Generic;
using Enums;
using ShapeParameters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ShapesSettings
{
    public class SphereSettingsPanel : SettingsPanel
    {
        [SerializeField] private Slider smoothnessSlider;
        [SerializeField] private Slider radiusSlider;

        private void Start()
        {
            smoothnessSlider.onValueChanged.AddListener(ChangedSize);
            radiusSlider.onValueChanged.AddListener(ChangedSize);
        }

        public override void OpenPanel(List<IParameter> parameters)
        {
            base.OpenPanel(parameters);
            smoothnessSlider.value = GetValue<int>(EParameters.Smoothness, parameters);
            radiusSlider.value = GetValue<float>(EParameters.Radius, parameters);
        }
        private void ChangedSize(float _)
        {
            var list = new List<IParameter>
            {
                new IntegerParameterValue(EParameters.Smoothness, (int)smoothnessSlider.value),
                new FloatParameterValue(EParameters.Radius, radiusSlider.value),
            };
            onChangedSize.Invoke(list);
        }
    }
}