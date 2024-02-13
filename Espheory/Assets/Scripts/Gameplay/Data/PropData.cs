using UnityEngine;

namespace Eos.Gameplay.Data
{
    [CreateAssetMenu(fileName = "PropData", menuName = "Game/Data/Prop Data")]
    public class PropData : ScriptableObject
    {
        [SerializeField] private bool isInteractable;
        [SerializeField] private bool isPickable;
        
    }
}