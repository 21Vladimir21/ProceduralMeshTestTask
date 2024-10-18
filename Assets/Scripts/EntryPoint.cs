using FigureSpawner;
using GameData;
using ShapeHandler;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private MainView mainView;
    [FormerlySerializedAs("figuresHolder")] [SerializeField] private ShapesHolder shapesHolder;
    [FormerlySerializedAs("figuresHandler")] [SerializeField] private ShapesHandler shapesHandler;


    private GameDatas _gameDatas;

    private void Awake()
    {
        _gameDatas = new GameDatas();
        mainView.Init(_gameDatas);
        shapesHandler.Init(_gameDatas, shapesHolder.Figures,mainView);
    }
}