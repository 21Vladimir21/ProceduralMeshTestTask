using System;
using Figures;
using UnityEngine;
using UnityEngine.UI;

namespace UI.FigureSelection
{
    [RequireComponent(typeof(Button))]
    public class FigureSelectionButton : MonoBehaviour
    {
        public Action<FiguresType> OnSelectFigure;
        [SerializeField] private FiguresType type;
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