#region

using Zenject;
using UnityEngine;

#endregion

namespace Eos.Gameplay.Scene.Data
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "SceneData", order = 0)]
    public class SceneData : ScriptableObjectInstaller
    {
        #region Private Variables

        [SerializeField] private string m_groundLayerName = "Ground";
        [SerializeField] private string m_wallLayerName   = "Wall";
        [SerializeField] private string m_portalLayerName = "Portal";
        [SerializeField] private string m_cursorLayerName = "Cursor";

        #endregion

        #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<string>().WithId("LAYER_GROUND").FromInstance(m_groundLayerName);
            Container.Bind<string>().WithId("LAYER_WALL").FromInstance(m_wallLayerName);
            Container.Bind<string>().WithId("LAYER_PORTAL").FromInstance(m_portalLayerName);
            Container.Bind<string>().WithId("LAYER_CURSOR").FromInstance(m_cursorLayerName);
        }

        #endregion
    }
}