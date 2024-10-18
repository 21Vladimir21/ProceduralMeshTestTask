using System;
using Enums;
using Figures;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ShapeSelection
{
    [RequireComponent(typeof(Button))]
    public class ShapeSelectionButton : MonoBehaviour
    {
        public Action<EShapesType> OnSelectFigure;
        [SerializeField] private EShapesType type;
        [SerializeField] private Button button;


        private void Start() => button.onClick.AddListener(() => OnSelectFigure.Invoke(type));

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (button == null) button = GetComponent<Button>();
        }
#endif
    }
}