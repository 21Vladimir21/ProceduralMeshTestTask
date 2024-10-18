using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.ColorSelection
{
    public class ColorSelectionPanel : MonoBehaviour
    {
        [HideInInspector] public UnityEvent<Color> onColorSelection;
        [SerializeField] private Button[] colorButtons;


        private void Start()
        {
            foreach (var button in colorButtons) button.onClick.AddListener(() => SelectColor(button.image.color));
        }

        private void SelectColor(Color color) => onColorSelection.Invoke(color);
    }
}