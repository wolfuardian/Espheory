#region

using UnityEngine;
using Zenject;

#endregion

namespace Eos.Gameplay.Players.Data
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "PlayerCharacterData", order = 0)]
    public class PlayerCharacterData : ScriptableObjectInstaller
    {
        #region Private Variables

        [SerializeField] private float moveSpeed;

        #endregion

        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId("MOVE_SPEED").FromInstance(moveSpeed);
        }

        #endregion
    }
}