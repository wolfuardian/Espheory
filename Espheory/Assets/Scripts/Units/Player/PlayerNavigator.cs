using Zenject;

namespace Espheory
{
    public class PlayerNavigator : ITickable
    {
        readonly IPlayer _player;
        readonly IInputState _inputState;

        public PlayerNavigator(
            IPlayer player,
            IInputState inputState)
        {
            _player = player;
            _inputState = inputState;
        }

        public void Tick()
        {
            if (_inputState.IsSelecting)
            {
                _player.Destination = _player.GetDestination(_inputState.Pointer);
            }
        }
    }
}
