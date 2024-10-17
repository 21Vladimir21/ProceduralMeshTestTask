using Figures;
using GameData;
using UnityEngine;

namespace UI
{
    public class SelectFigurePanel : MonoBehaviour
    {
        [SerializeField] private SelectFigureButton[] buttons;
        private FiguresType _currentFigure;
        private GameDatas _gameDatas;

        public void Init(GameDatas gameDatas)
        {
            _gameDatas = gameDatas;
            foreach (var button in buttons)
            {
                button.OnSelectFigure += SelectCurrentFigure;
            }
        }
        private void SelectCurrentFigure(FiguresType figuresType)
        {
            _currentFigure = figuresType;
            _gameDatas.CurrentFigure = _currentFigure;
        }
    }
}