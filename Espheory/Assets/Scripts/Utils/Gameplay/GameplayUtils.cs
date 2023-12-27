using UnityEngine;

namespace Eos.Utils.Gameplay
{
    public class GameplayUtils
    {
        public static void MouseLock()
        {
            Cursor.visible   = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public static void MouseUnlock()
        {
            Cursor.visible   = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}