using Enums;
using Figures;
using GameData;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShapeHandler
{
    public class ShapesHandler : MonoBehaviour
    {
        private ShapeBase _selectedShape;
        private Camera _camera;
        private ShapeBase[] _figures;
        private GameDatas _gameDatas;
        private MainView _mainView;

        public void Init(GameDatas gameDatas, ShapeBase[] figures, MainView mainView)
        {
            _gameDatas = gameDatas;
            _figures = figures;
            _mainView = mainView;
            _mainView.DeleteFigureButton.onClick.AddListener(DeleteSelectedFigure);
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject()) return;

                var hit = CastRay();
                if (hit.collider != null && hit.collider.TryGetComponent(out ShapeBase selectedFigure))
                {
                    _mainView.HideLastPanel();
                    _selectedShape = selectedFigure;

                    _mainView.ColorSelectionPanel.onColorSelection.RemoveAllListeners();
                    _mainView.ColorSelectionPanel.onColorSelection.AddListener(_selectedShape.ChangeColor);

                    var panel = _mainView.GetPanelByType(_selectedShape.Type);
                    panel.OpenPanel(_selectedShape.Parameters);
                    panel.onChangedSize.AddListener(_selectedShape.ChangeSize);
                }
                else
                {
                    _mainView.HideLastPanel();
                    var position = GetPosition();
                    SpawnFigure(position);
                    _selectedShape = null;
                }
            }
        }

        private void DeleteSelectedFigure()
        {
            if (_selectedShape == null) return;
            _mainView.HideLastPanel();
            Destroy(_selectedShape.gameObject);
            _selectedShape = null;
        }

        private Vector3 GetPosition()
        {
            var distance = Vector3.Distance(_camera.transform.position, Vector3.zero);
            var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            var worldPoint = _camera.ScreenToWorldPoint(screenPoint);
            return worldPoint;
        }

        private void SpawnFigure(Vector3 position)
        {
            var figure = GetFigureFromType(_gameDatas.CurrentEShape);
            Instantiate(figure, position, Quaternion.identity);
        }

        private ShapeBase GetFigureFromType(EShapesType type)
        {
            foreach (var figure in _figures)
                if (figure.Type == type)
                    return figure;

            return null;
        }

        private RaycastHit CastRay()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && !EventSystem.current.IsPointerOverGameObject())
                return hit;

            return default;
        }
    }
}