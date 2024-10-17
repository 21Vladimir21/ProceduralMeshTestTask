using System;
using Figures;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class SelectFigureButton : MonoBehaviour
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