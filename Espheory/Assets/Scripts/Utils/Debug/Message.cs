namespace Eos.Utils.Debug
{
    public class Message
    {
        public readonly string Text;
        public          float  Duration;

        public Message(string text, float duration)
        {
            Text     = text;
            Duration = duration;
        }
    }
}