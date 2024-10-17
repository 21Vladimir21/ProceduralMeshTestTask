using FigureSpawner;
using GameData;
using UI;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private MainView mainView;
    [SerializeField] private FiguresHolder figuresHolder;
    [SerializeField] private FiguresHandler figuresHandler;


    private GameDatas _gameDatas;

    private void Awake()
    {
        _gameDatas = new GameDatas();
        mainView.Init(_gameDatas);
        figuresHandler.Init(_gameDatas, figuresHolder.Figures,mainView);
    }
}