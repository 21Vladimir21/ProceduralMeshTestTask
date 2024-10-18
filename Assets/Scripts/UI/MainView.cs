using Enums;
using GameData;
using UI.ColorSelection;
using UI.FigureSelection;
using UI.ShapesSettings;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private ShapesSelectionPanel shapesSelectionPanel;
        [field: SerializeField] public ColorSelectionPanel ColorSelectionPanel { get; private set; }
        [field: SerializeField] public Button DeleteFigureButton { get; private set; }
        [field: SerializeField] public SettingsPanel[] SettingsPanels { get; private set; }

        private SettingsPanel _lastOpenedPanel;

        public void Init(GameDatas gameDatas) => shapesSelectionPanel.Init(gameDatas);

        public SettingsPanel GetPanelByType(EShapesType type)
        {
            foreach (var panel in SettingsPanels)
                if (panel.Type == type)
                {
                    _lastOpenedPanel = panel;
                    return panel;
                }

            return null;
        }

        public void HideLastPanel()
        {
            if (_lastOpenedPanel == null) return;
            _lastOpenedPanel.HidePanel();
        }
    }
}