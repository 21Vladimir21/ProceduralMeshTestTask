using Figures;
using UnityEngine;

namespace FigureSpawner
{
    [CreateAssetMenu(fileName = "FiguresHolder", menuName = "Create new figures holder", order = 0)]
    public class FiguresHolder : ScriptableObject
    {
        [field:SerializeField] public FigureBase[] Figures { get; private set; }
        
    }
}