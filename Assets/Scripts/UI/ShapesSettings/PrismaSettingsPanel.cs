using System.Collections.Generic;
using Enums;
using ShapeParameters;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ShapesSettings
{
    public class PrismaSettingsPanel : SettingsPanel
    {
        [HideInInspector] public UnityEvent<float, float> onChanged;
        [SerializeField] private Slider radiusSlider;
        [SerializeField] private Slider heightSlider;

        private void Start()
        {
            radiusSlider.onValueChanged.AddListener(ChangedSize);
            heightSlider.onValueChanged.AddListener(ChangedSize);
        }


        public override void OpenPanel(List<IParameter> parameters)
        {
            base.OpenPanel(parameters);
            radiusSlider.value = GetValue<float>(EParameters.Radius, parameters);
            heightSlider.value = GetValue<float>(EParameters.Height, parameters);
        }

        private void ChangedSize(float _)
        {
            var list = new List<IParameter>
            {
                new FloatParameterValue(EParameters.Radius, radiusSlider.value),
                new FloatParameterValue(EParameters.Height, heightSlider.value)
            };
            onChangedSize.Invoke(list);
        }
    }
}