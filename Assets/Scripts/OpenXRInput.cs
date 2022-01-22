#nullable enable

using ModestTree;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Nanikit.Hello
{
    public class OpenXRInput : IInitializable, IDisposable
    {
        [Tooltip("Action to guide as pulling trigger")]
        [SerializeField]
        private InputActionReference? _actionReference = null;

        [Inject]
        public OpenXRInput(InputActionReference reference)
        {
            _actionReference = reference;
        }

        public void Initialize()
        {
            var triggerAction = _actionReference != null ? _actionReference.action : null;

            if (triggerAction != null)
            {
                triggerAction.performed += ForwardPerformed;
                triggerAction.Enable();
            }
        }

        private void ForwardPerformed(InputAction.CallbackContext inputContext)
        {
            Log.Debug(inputContext.action.ToString());
            Log.Debug(inputContext.action.activeControl.ToString());
            Log.Debug(inputContext.action.activeControl.name);
            Log.Debug(inputContext.action.activeControl.path);
            Log.Debug(inputContext.action.activeControl.displayName);
            Log.Debug($"value: {inputContext.action.activeControl.ReadValueAsObject()}");
        }

        public void Dispose()
        {
            var triggerAction = _actionReference != null ? _actionReference.action : null;

            if (triggerAction != null)
            {
                triggerAction.Disable();
                triggerAction.performed -= ForwardPerformed;
            }
        }
    }
}