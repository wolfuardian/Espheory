#region

using Zenject;
using UnityEngine;

#endregion

namespace Eos.Gameplay.Player.Data
{
    [CreateAssetMenu(fileName = "PlayerCharacterData", menuName = "PlayerCharacterData", order = 0)]
    public class PlayerCharacterData : ScriptableObjectInstaller
    {
        #region Private Variables

        [SerializeField] private float m_moveSpeed;

        #endregion

        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId("MOVE_SPEED").FromInstance(m_moveSpeed);
        }

        #endregion
    }
}