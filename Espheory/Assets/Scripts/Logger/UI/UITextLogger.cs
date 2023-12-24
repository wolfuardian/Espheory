#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Eos.Logger.UI
{
    public class UITextLogger : MonoBehaviour
    {
        #region Public Variables

        public Text DisplayText
        {
            get
            {
                if (displayText == null) displayText = GetComponent<Text>();
                return displayText;
            }
        }

        #endregion

        #region Private Variables

        private Text displayText;

        #endregion

        #region Public Methods

        public void SetDisplayText(string newText)
        {
            DisplayText.text = newText;
        }

        #endregion
    }
}