using Figures;
using UnityEngine;

namespace FigureSpawner
{
    [CreateAssetMenu(fileName = "ShapesHolder", menuName = "Create new shapes holder", order = 0)]
    public class ShapesHolder : ScriptableObject
    {
        [field:SerializeField] public ShapeBase[] Figures { get; private set; }
        
    }
}