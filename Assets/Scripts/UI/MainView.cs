using GameData;
using UI.ChangeFormSliders;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private SelectFigurePanel selectFigurePanel;
        [field: SerializeField] public ChangeCubePanel ChangeCubePanel { get; private set; }
        [field: SerializeField] public ChangeSpherePanel ChangeSpherePanel { get; private set; }
        [field: SerializeField] public ChangeCapsulePanel ChangeCapsulePanel { get; private set; }
        [field: SerializeField] public ChangePrismaPanel ChangePrismaPanel { get; private set; }
        [field: SerializeField] public Button DeleteFigureButton { get; private set; }


        public void Init(GameDatas gameDatas)
        {
            selectFigurePanel.Init(gameDatas);
        }

        public void HideAllPanels()
        {
            ChangeCubePanel.HidePanel();
            ChangeSpherePanel.HidePanel();
            ChangeCapsulePanel.HidePanel();
            ChangePrismaPanel.HidePanel();
        }
    }
}