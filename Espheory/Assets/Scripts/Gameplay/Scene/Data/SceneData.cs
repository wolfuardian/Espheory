#region

using UnityEngine;
using Zenject;

#endregion

namespace Eos.Gameplay.Scene.Data
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "SceneData", order = 0)]
    public class SceneData : ScriptableObjectInstaller
    {
        #region Private Variables

        [SerializeField] private string groundLayerName = "Ground";
        [SerializeField] private string wallLayerName   = "Wall";
        [SerializeField] private string portalLayerName = "Portal";
        [SerializeField] private string cursorLayerName = "Cursor";

        #endregion

        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<string>().WithId("LAYER_GROUND").FromInstance(groundLayerName);
            Container.Bind<string>().WithId("LAYER_WALL").FromInstance(wallLayerName);
            Container.Bind<string>().WithId("LAYER_PORTAL").FromInstance(portalLayerName);
            Container.Bind<string>().WithId("LAYER_CURSOR").FromInstance(cursorLayerName);
        }

        #endregion
    }
}