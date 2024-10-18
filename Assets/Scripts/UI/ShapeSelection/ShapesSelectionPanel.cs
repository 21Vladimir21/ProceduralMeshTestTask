using Enums;
using Figures;
using GameData;
using UI.ShapeSelection;
using UnityEngine;

namespace UI.FigureSelection
{
    public class ShapesSelectionPanel : MonoBehaviour
    {
        [SerializeField] private ShapeSelectionButton[] buttons;
        private EShapesType _currentEShape;
        private GameDatas _gameDatas;

        public void Init(GameDatas gameDatas)
        {
            _gameDatas = gameDatas;
            foreach (var button in buttons)
            {
                button.OnSelectFigure += SelectCurrentFigure;
            }
        }
        private void SelectCurrentFigure(EShapesType eShapesType)
        {
            _currentEShape = eShapesType;
            _gameDatas.CurrentEShape = _currentEShape;
        }
    }
}