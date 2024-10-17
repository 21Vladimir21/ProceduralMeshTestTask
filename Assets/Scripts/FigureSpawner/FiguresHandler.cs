using Figures;
using GameData;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FigureSpawner
{
    public class FiguresHandler : MonoBehaviour

    {
        private FigureBase _selectedFigure;
        private Camera _camera;
        private FigureBase[] _figures;
        private GameDatas _gameDatas;
        private MainView _mainView;


        public void Init(GameDatas gameDatas, FigureBase[] figures, MainView mainView)
        {
            _gameDatas = gameDatas;
            _figures = figures;
            _mainView = mainView;

            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject()) return;

                var hit = CastRay();
                if (hit.collider != null && hit.collider.TryGetComponent(out FigureBase selectedFigure))
                {
                    _selectedFigure = selectedFigure;
                    if (_selectedFigure is Cube cube)
                    {
                        _mainView.ChangeCubeFormPanel.OpenPanel(cube.Size);
                        _mainView.ChangeCubeFormPanel.onChangedSize.AddListener(cube.ChangeSize);
                    }
                    if (_selectedFigure is Sphere sphere)
                    {
                        _mainView.ChangeSpherePanel.OpenPanel(sphere.Smoothness,sphere.Radius);
                        _mainView.ChangeSpherePanel.onChanged.AddListener(sphere.ChangeForm);
                    }

                    if (_selectedFigure is Capsule capsule)
                    {
                        
                    }
                    if (_selectedFigure is Prisma prisma)
                    {
                        
                    }
                }
                else
                {
                    if (_selectedFigure is Cube) _mainView.ChangeCubeFormPanel.HidePanel();

                    var position = GetPosition();
                    SpawnFigure(position);
                    _selectedFigure = null;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (_selectedFigure != null)
                {
                    Destroy(_selectedFigure.gameObject);
                    _selectedFigure = null;
                }
            }
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
            var figure = GetFigureFromType(_gameDatas.CurrentFigure);
            Instantiate(figure, position, Quaternion.identity);
        }

        private FigureBase GetFigureFromType(FiguresType type)
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