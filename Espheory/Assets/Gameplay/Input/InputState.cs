namespace Gameplay.Input
{
    public interface IInputState
    {
        bool IsSelectPerforming { get; set; }
        bool IsSelectPressed    { get; set; }
        bool IsSelectReleased   { get; set; }
        bool IsSelectCooldown   { get; set; }
        bool IsSelectIdle       { get; set; }
        int  SelectPerforming   { get; set; }
        int  SelectCooldown     { get; set; }
        int  SelectIdle         { get; set; }
        bool IsTargetPressed    { get; set; }
    }

    public class InputState : IInputState
    {
        public bool IsSelectPerforming { get; set; }
        public bool IsSelectPressed    { get; set; }
        public bool IsSelectReleased   { get; set; }
        public bool IsSelectCooldown   { get; set; }
        public bool IsSelectIdle       { get; set; }
        public int  SelectPerforming   { get; set; }
        public int  SelectCooldown     { get; set; }
        public int  SelectIdle         { get; set; }
        public bool IsTargetPressed    { get; set; }
    }
}
