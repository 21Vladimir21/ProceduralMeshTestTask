using System.Collections.Generic;
using Enums;
using ShapeParameters;
using UnityEngine;
using UnityEngine.Events;

namespace UI.ShapesSettings
{
    public abstract class SettingsPanel : MonoBehaviour
    {
        [field: SerializeField] public EShapesType Type { get; private set; }
        [HideInInspector] public UnityEvent<List<IParameter>> onChangedSize;
        public virtual void OpenPanel(List<IParameter> parameters)
        {
            onChangedSize.RemoveAllListeners();
            gameObject.SetActive(true);
        }
        
        protected T GetValue<T>(EParameters type, List<IParameter> parameters) where T : struct
        {
            foreach (var parameter in parameters)
                if (parameter.Type == type)
                    if (parameter is IShapeParameter<T> value)
                        return value.Value;
            return default;
        }
        
        public void HidePanel() => gameObject.SetActive(false);
    }
}