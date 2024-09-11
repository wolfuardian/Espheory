// using System;
// using Zenject;
// using UnityEngine.Events;
// using UnityEngine.InputSystem;
//
// namespace Gameplay.Scripts
// {
//     public interface IInputReader
//     {
//         public event UnityAction<InputAction.CallbackContext> OnSelectKey;
//         public event UnityAction<InputAction.CallbackContext> OnMiddleButton;
//         public event UnityAction<InputAction.CallbackContext> OnRightButton;
//         public event UnityAction<InputAction.CallbackContext> OnSpaceKey;
//         public event UnityAction<InputAction.CallbackContext> OnAKey;
//         public event UnityAction<InputAction.CallbackContext> OnBKey;
//         public event UnityAction<InputAction.CallbackContext> OnCKey;
//         public event UnityAction<InputAction.CallbackContext> OnDKey;
//         public event UnityAction<InputAction.CallbackContext> OnEKey;
//         public event UnityAction<InputAction.CallbackContext> OnFKey;
//         public event UnityAction<InputAction.CallbackContext> OnGKey;
//         public event UnityAction<InputAction.CallbackContext> OnHKey;
//         public event UnityAction<InputAction.CallbackContext> OnIKey;
//         public event UnityAction<InputAction.CallbackContext> OnJKey;
//         public event UnityAction<InputAction.CallbackContext> OnKKey;
//         public event UnityAction<InputAction.CallbackContext> OnLKey;
//         public event UnityAction<InputAction.CallbackContext> OnMKey;
//         public event UnityAction<InputAction.CallbackContext> OnNKey;
//         public event UnityAction<InputAction.CallbackContext> OnOKey;
//         public event UnityAction<InputAction.CallbackContext> OnPKey;
//         public event UnityAction<InputAction.CallbackContext> OnQKey;
//         public event UnityAction<InputAction.CallbackContext> OnRKey;
//         public event UnityAction<InputAction.CallbackContext> OnSKey;
//         public event UnityAction<InputAction.CallbackContext> OnTKey;
//         public event UnityAction<InputAction.CallbackContext> OnUKey;
//         public event UnityAction<InputAction.CallbackContext> OnVKey;
//         public event UnityAction<InputAction.CallbackContext> OnWKey;
//         public event UnityAction<InputAction.CallbackContext> OnXKey;
//         public event UnityAction<InputAction.CallbackContext> OnYKey;
//         public event UnityAction<InputAction.CallbackContext> OnZKey;
//         public event UnityAction<InputAction.CallbackContext> OnTab;
//         public event UnityAction<InputAction.CallbackContext> OnEscKey;
//         public event UnityAction<InputAction.CallbackContext> On0Key;
//         public event UnityAction<InputAction.CallbackContext> On1Key;
//         public event UnityAction<InputAction.CallbackContext> On2Key;
//         public event UnityAction<InputAction.CallbackContext> On3Key;
//         public event UnityAction<InputAction.CallbackContext> On4Key;
//         public event UnityAction<InputAction.CallbackContext> On5Key;
//         public event UnityAction<InputAction.CallbackContext> On6Key;
//         public event UnityAction<InputAction.CallbackContext> On7Key;
//         public event UnityAction<InputAction.CallbackContext> On8Key;
//         public event UnityAction<InputAction.CallbackContext> On9Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum0Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum1Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum2Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum3Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum4Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum5Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum6Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum7Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum8Key;
//         public event UnityAction<InputAction.CallbackContext> OnNum9Key;
//         public event UnityAction<InputAction.CallbackContext> OnCtrlKey;
//         public event UnityAction<InputAction.CallbackContext> OnShiftKey;
//         public event UnityAction<InputAction.CallbackContext> OnAltKey;
//         public event UnityAction<InputAction.CallbackContext> OnPointer;
//         public event UnityAction<InputAction.CallbackContext> OnDelta;
//         public event UnityAction<InputAction.CallbackContext> OnScroll;
//     }
//
//     public class InputReader : InputMapper.IInputCodeActions, IInputReader, IInitializable, IDisposable
//     {
//         public event UnityAction<InputAction.CallbackContext> OnSelectKey    = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnMiddleButton = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnRightButton  = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnSpaceKey     = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnAKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnBKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnCKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnDKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnEKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnFKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnGKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnHKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnIKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnJKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnKKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnLKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnMKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnOKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnPKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnQKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnRKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnSKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnTKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnUKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnVKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnWKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnXKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnYKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnZKey         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnTab          = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnEscKey       = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On0Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On1Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On2Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On3Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On4Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On5Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On6Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On7Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On8Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> On9Key         = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum0Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum1Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum2Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum3Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum4Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum5Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum6Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum7Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum8Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnNum9Key      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnCtrlKey      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnShiftKey     = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnAltKey       = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnPointer      = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnDelta        = delegate {};
//         public event UnityAction<InputAction.CallbackContext> OnScroll       = delegate {};
//
//         public void OnSelect(InputAction.CallbackContext             context) => OnSelectKey?.Invoke(context);
//         public void OnMouse_MiddleButton(InputAction.CallbackContext context) => OnMiddleButton?.Invoke(context);
//         public void OnMouse_RightButton(InputAction.CallbackContext  context) => OnRightButton?.Invoke(context);
//         public void OnKeyboard_Space(InputAction.CallbackContext     context) => OnSpaceKey?.Invoke(context);
//         public void OnKeyboard_A(InputAction.CallbackContext         context) => OnAKey?.Invoke(context);
//         public void OnKeyboard_B(InputAction.CallbackContext         context) => OnBKey?.Invoke(context);
//         public void OnKeyboard_C(InputAction.CallbackContext         context) => OnCKey?.Invoke(context);
//         public void OnKeyboard_D(InputAction.CallbackContext         context) => OnDKey?.Invoke(context);
//         public void OnKeyboard_E(InputAction.CallbackContext         context) => OnEKey?.Invoke(context);
//         public void OnKeyboard_F(InputAction.CallbackContext         context) => OnFKey?.Invoke(context);
//         public void OnKeyboard_G(InputAction.CallbackContext         context) => OnGKey?.Invoke(context);
//         public void OnKeyboard_H(InputAction.CallbackContext         context) => OnHKey?.Invoke(context);
//         public void OnKeyboard_I(InputAction.CallbackContext         context) => OnIKey?.Invoke(context);
//         public void OnKeyboard_J(InputAction.CallbackContext         context) => OnJKey?.Invoke(context);
//         public void OnKeyboard_K(InputAction.CallbackContext         context) => OnKKey?.Invoke(context);
//         public void OnKeyboard_L(InputAction.CallbackContext         context) => OnLKey?.Invoke(context);
//         public void OnKeyboard_M(InputAction.CallbackContext         context) => OnMKey?.Invoke(context);
//         public void OnKeyboard_N(InputAction.CallbackContext         context) => OnNKey?.Invoke(context);
//         public void OnKeyboard_O(InputAction.CallbackContext         context) => OnOKey?.Invoke(context);
//         public void OnKeyboard_P(InputAction.CallbackContext         context) => OnPKey?.Invoke(context);
//         public void OnKeyboard_Q(InputAction.CallbackContext         context) => OnQKey?.Invoke(context);
//         public void OnKeyboard_R(InputAction.CallbackContext         context) => OnRKey?.Invoke(context);
//         public void OnKeyboard_S(InputAction.CallbackContext         context) => OnSKey?.Invoke(context);
//         public void OnKeyboard_T(InputAction.CallbackContext         context) => OnTKey?.Invoke(context);
//         public void OnKeyboard_U(InputAction.CallbackContext         context) => OnUKey?.Invoke(context);
//         public void OnKeyboard_V(InputAction.CallbackContext         context) => OnVKey?.Invoke(context);
//         public void OnKeyboard_W(InputAction.CallbackContext         context) => OnWKey?.Invoke(context);
//         public void OnKeyboard_X(InputAction.CallbackContext         context) => OnXKey?.Invoke(context);
//         public void OnKeyboard_Y(InputAction.CallbackContext         context) => OnYKey?.Invoke(context);
//         public void OnKeyboard_Z(InputAction.CallbackContext         context) => OnZKey?.Invoke(context);
//         public void OnKeyboard_Tab(InputAction.CallbackContext       context) => OnTab?.Invoke(context);
//         public void OnKeyboard_Esc(InputAction.CallbackContext       context) => OnEscKey?.Invoke(context);
//         public void OnKeyboard_0(InputAction.CallbackContext         context) => On0Key?.Invoke(context);
//         public void OnKeyboard_1(InputAction.CallbackContext         context) => On1Key?.Invoke(context);
//         public void OnKeyboard_2(InputAction.CallbackContext         context) => On2Key?.Invoke(context);
//         public void OnKeyboard_3(InputAction.CallbackContext         context) => On3Key?.Invoke(context);
//         public void OnKeyboard_4(InputAction.CallbackContext         context) => On4Key?.Invoke(context);
//         public void OnKeyboard_5(InputAction.CallbackContext         context) => On5Key?.Invoke(context);
//         public void OnKeyboard_6(InputAction.CallbackContext         context) => On6Key?.Invoke(context);
//         public void OnKeyboard_7(InputAction.CallbackContext         context) => On7Key?.Invoke(context);
//         public void OnKeyboard_8(InputAction.CallbackContext         context) => On8Key?.Invoke(context);
//         public void OnKeyboard_9(InputAction.CallbackContext         context) => On9Key?.Invoke(context);
//         public void OnKeyboard_Num_0(InputAction.CallbackContext     context) => OnNum0Key?.Invoke(context);
//         public void OnKeyboard_Num_1(InputAction.CallbackContext     context) => OnNum1Key?.Invoke(context);
//         public void OnKeyboard_Num_2(InputAction.CallbackContext     context) => OnNum2Key?.Invoke(context);
//         public void OnKeyboard_Num_3(InputAction.CallbackContext     context) => OnNum3Key?.Invoke(context);
//         public void OnKeyboard_Num_4(InputAction.CallbackContext     context) => OnNum4Key?.Invoke(context);
//         public void OnKeyboard_Num_5(InputAction.CallbackContext     context) => OnNum5Key?.Invoke(context);
//         public void OnKeyboard_Num_6(InputAction.CallbackContext     context) => OnNum6Key?.Invoke(context);
//         public void OnKeyboard_Num_7(InputAction.CallbackContext     context) => OnNum7Key?.Invoke(context);
//         public void OnKeyboard_Num_8(InputAction.CallbackContext     context) => OnNum8Key?.Invoke(context);
//         public void OnKeyboard_Num_9(InputAction.CallbackContext     context) => OnNum9Key?.Invoke(context);
//         public void OnKeyboard_Ctrl(InputAction.CallbackContext      context) => OnCtrlKey?.Invoke(context);
//         public void OnKeyboard_Shift(InputAction.CallbackContext     context) => OnShiftKey?.Invoke(context);
//         public void OnKeyboard_Alt(InputAction.CallbackContext       context) => OnAltKey?.Invoke(context);
//         public void OnMouse_PositionAxis(InputAction.CallbackContext context) => OnPointer?.Invoke(context);
//         public void OnMouse_DeltaAxis(InputAction.CallbackContext    context) => OnDelta?.Invoke(context);
//         public void OnMouse_ScrollAxis(InputAction.CallbackContext   context) => OnScroll?.Invoke(context);
//
//         private readonly IInputState   inputState;
//
//         public InputReader(IInputState inputState)
//         {
//             this.inputState = inputState;
//         }
//
//         private InputMapper inputMapper;
//
//         public void Initialize()
//         {
//             if (inputMapper == null)
//             {
//                 inputMapper = new InputMapper();
//                 inputMapper.InputCode.Enable();
//                 inputMapper.InputCode.SetCallbacks(this);
//             }
//
//             OnSelectKey += SetSelect;
//             // OnMiddleButton += SetMiddleButton;
//             // OnRightButton  += SetRightButton;
//             // OnTab          += SetTab;
//         }
//
//         public void Dispose()
//         {
//             OnSelectKey -= SetSelect;
//             // OnMiddleButton -= SetMiddleButton;
//             // OnRightButton  -= SetRightButton;
//
//             if (inputMapper != null)
//             {
//                 inputMapper.InputCode.Disable();
//             }
//         }
//
//         // public void OnMouse_LeftButton(InputAction.CallbackContext   context) => inputState.SetLmbKey(isPressed);
//
//         private void SetSelect(InputAction.CallbackContext context)
//         {
//             switch (context.phase)
//             {
//                 case InputActionPhase.Performed:
//                     inputState.SelectTracker.SetPerformed();
//                     break;
//                 case InputActionPhase.Canceled:
//                     inputState.SelectTracker.SetCanceled();
//                     break;
//             }
//         }
//
//         // private void SetMiddleButton(InputAction.CallbackContext context) => inputState.SetMiddleButton(context);
//         // private void SetRightButton(InputAction.CallbackContext  context) => inputState.SetRightButton(context);
//
//         // private void SetTab(InputAction.CallbackContext context) => inputState.SetTab(context);
//     }
// }
