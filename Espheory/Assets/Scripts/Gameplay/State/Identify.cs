using UnityEngine;
using Eos.Gameplay.Input;
using Eos.Gameplay.Managers;

namespace Eos.Gameplay.State
{
    public class Identify : MonoBehaviour
    {
        #region Field Declarations

        [SerializeField] private InputReader   inputReader;
        [SerializeField] private CameraManager cameraManager;

        public GameObject HoveringObject { get; private set; }
        public GameObject SelectedObject { get; private set; }
        public GameObject ActiveObject   { get; private set; }

        #endregion
        
        
        private void OnEnable()
        {

        }
    }
}