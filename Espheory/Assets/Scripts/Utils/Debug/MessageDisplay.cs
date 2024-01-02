#region

using System.Collections.Generic;
using UnityEngine;

#endregion

namespace Eos.Utils.Debug
{
    public interface IMessageDisplay
    {
        void Print(string      text);
        void SetDuration(float newDuration);
    }

    public class MessageDisplay : MonoBehaviour, IMessageDisplay
    {
        private readonly Queue<Message> _messages       = new();
        private readonly List<Message>  _activeMessages = new();
        private const    int            count           = 20;
        private          float          _duration       = 0.1f;


        private void OnGUI()
        {
            GUI.skin.label.fontStyle = FontStyle.Bold;
            var i = 0;
            foreach (var message in _activeMessages)
            {
                var rect  = new Rect(100, 100 + (i * 20), Screen.width, 100);
                var text  = message.Text;
                var color = Color.magenta;
                GUI.color = color;
                GUI.Label(rect, text);
                i++;
            }
        }

        private void Update()
        {
            foreach (var message in _activeMessages.ToArray())
            {
                message.Duration -= Time.deltaTime;
                if (message.Duration <= 0)
                {
                    _activeMessages.Remove(message);
                }
            }

            if (_messages.Count <= 0 || _activeMessages.Count >= count) return;

            var nextMessage = _messages.Dequeue();

            _activeMessages.Add(nextMessage);
        }

        public void Print(string text)
        {
            _messages.Enqueue(new Message(text, _duration));
        }

        public void SetDuration(float newDuration)
        {
            _duration = newDuration;
        }
    }
}