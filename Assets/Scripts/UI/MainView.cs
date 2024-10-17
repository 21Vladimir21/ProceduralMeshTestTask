using GameData;
using UI.ChangeFormSliders;
using UnityEngine;

namespace UI
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private SelectFigurePanel selectFigurePanel;
        [field:SerializeField] public ChangeCubeFormPanel ChangeCubeFormPanel { get; private set; }
        [field:SerializeField] public ChangeSpherePanel ChangeSpherePanel { get; private set; }
        

        public void Init(GameDatas gameDatas)
        {
            selectFigurePanel.Init(gameDatas);
        }
    }
}