#region

using UnityEngine;

#endregion

namespace Espheory.Installer
{
    public class CoreResponse : GameModeBase
    {
        #region Unity Events

        private void Awake()
        {
            Debug.Log("Awake: CoreResponse");
        }

        #endregion

        #region Public Methods

        public void Log()
        {
            Debug.Log("CoreResponse");
        }

        #endregion
    }
}