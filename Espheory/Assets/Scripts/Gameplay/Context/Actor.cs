using UnityEngine;
using Eos.Gameplay.Context.Base;

namespace Eos.Gameplay.Context
{
    [DisallowMultipleComponent]
    public class Actor : ActorBase
    {
        [SerializeField] private string _id;
    }
}