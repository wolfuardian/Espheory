using UnityEngine;
using Zenject;

namespace Espheory
{
    public class PlayerFacade : MonoBehaviour
    {
        private IPlayer _model;

        [Inject]
        public void Construct(IPlayer player)
        {
            _model = player;
        }

        public Vector3 Position => _model.Position;
    }
}
