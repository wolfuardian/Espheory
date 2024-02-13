// using System;
// using Eos.Gameplay.Input;
// using UnityEngine;
//
// namespace Eos.Gameplay
// {
//     public class ObjectDetector : IDisposable
//     {
//         #region Field Declarations
//
//         private readonly InputReader inputReader;
//         private readonly Camera      mainCamera;
//         private                   GameObject  selectedObject;
//
//         #endregion
//
//         #region Cycle Methods
//
//         public void Initialize()
//         {
//             inputReader.PointerEvent      += IdentifyObject;
//             inputReader.SelectEvent       += OnSelect;
//         }
//         
//
//         public void Dispose()
//         {
//             inputReader.PointerEvent      -= IdentifyObject;
//             inputReader.SelectEvent       -= OnSelect;
//         }
//
//         #endregion
//
//         private void IdentifyObject(Vector2 pointer)
//         {
//             var ray = mainCamera.ScreenPointToRay(pointer);
//             if (Physics.Raycast(ray, out var hit))
//             {
//                 selectedObject = hit.transform.gameObject;
//             }
//         }
//
//         private void OnSelect()
//         {
//             ParseSelectedObject();
//         }
//
//         private void ParseSelectedObject()
//         {
//         }
//
//         private void OnSelectCancel()
//         {
//             Debug.Log("ObjectDetector: On select cancel");
//         }
//     }
// }