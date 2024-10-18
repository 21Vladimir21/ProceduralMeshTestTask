using GameData;
using UI.ColorSelection;
using UI.FigureSelection;
using UI.FiguresSettings;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class MainView : MonoBehaviour
    {
        [FormerlySerializedAs("selectFigurePanel")] [SerializeField] private FigureSelectionPanel figureSelectionPanel;
        [field: SerializeField] public CubeSettingsPanel CubeSettingsPanel { get; private set; }
        [field: SerializeField] public SphereSettingsPanel SphereSettingsPanel { get; private set; }
        [field: SerializeField] public CapsuleSettingsPanel CapsuleSettingsPanel { get; private set; }
        [field: SerializeField] public PrismaSettingsPanel PrismaSettingsPanel { get; private set; }
        [field: SerializeField] public ColorSelectionPanel ColorSelectionPanel { get; private set; }
        [field: SerializeField] public Button DeleteFigureButton { get; private set; }


        public void Init(GameDatas gameDatas)
        {
            figureSelectionPanel.Init(gameDatas);
        }

        public void HideAllPanels()
        {
            CubeSettingsPanel.HidePanel();
            SphereSettingsPanel.HidePanel();
            CapsuleSettingsPanel.HidePanel();
            PrismaSettingsPanel.HidePanel();
        }
    }
}