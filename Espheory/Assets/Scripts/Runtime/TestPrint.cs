using UnityEngine;

namespace Eos.Scripts.Runtime
{
    public class TestPrint : MonoBehaviour
    {
        public string printWord = "Hello World!";

        public void PrintHelloWorld()
        {
            Debug.Log(printWord);
        }
    }
}