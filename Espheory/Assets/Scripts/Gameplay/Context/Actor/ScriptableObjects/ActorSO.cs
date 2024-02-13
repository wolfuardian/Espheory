using UnityEngine;

namespace Eos.Gameplay.Context.Actor.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Item", menuName = "Game/Inventory/Item")]
    public class ActorSO : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;

        public string Id          => _id;
        public string Name        => _name;
        public string Description => _description;
        public Sprite Icon        => _icon;
    }
}