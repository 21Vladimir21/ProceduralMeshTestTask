using System.Collections.Generic;
using Enums;
using ShapeParameters;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ShapesSettings
{
    public class CapsuleSettingsPanel : SettingsPanel
    {
        [SerializeField] private Slider smoothnessSlider;
        [SerializeField] private Slider radiusSlider;
        [SerializeField] private Slider heightSlider;

        private void Start()
        {
            smoothnessSlider.onValueChanged.AddListener(ChangedSize);
            radiusSlider.onValueChanged.AddListener(ChangedSize);
            heightSlider.onValueChanged.AddListener(ChangedSize);
        }

        public override void OpenPanel(List<IParameter> parameters)
        {
            base.OpenPanel(parameters);
            smoothnessSlider.value = GetValue<int>(EParameters.Smoothness, parameters);
            radiusSlider.value = GetValue<float>(EParameters.Radius, parameters);
            heightSlider.value = GetValue<float>(EParameters.Height, parameters);
        }


        private void ChangedSize(float _)
        {
            var list = new List<IParameter>
            {
                new IntegerParameterValue(EParameters.Smoothness, (int)smoothnessSlider.value),
                new FloatParameterValue(EParameters.Radius, radiusSlider.value),
                new FloatParameterValue(EParameters.Height, heightSlider.value)
            };
            onChangedSize.Invoke(list);
        }
    }
}