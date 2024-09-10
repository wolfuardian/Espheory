namespace Modules.Scripts
{
    public interface IInputState
    {
        bool   IsSelectPerforming { get; set; }
        bool   IsSelectPressed    { get; set; }
        object IsSelectReleased   { get; set; }
        object IsSelectCooldown   { get; set; }
        object IsSelectIdle       { get; set; }
    }

    public class InputState : IInputState
    {
        public bool   IsSelectPerforming { get; set; }
        public bool   IsSelectPressed    { get; set; }
        public object IsSelectReleased   { get; set; }
        public object IsSelectCooldown   { get; set; }
        public object IsSelectIdle       { get; set; }
    }
}
