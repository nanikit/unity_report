using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Nanikit.Hello
{
    public class FirstInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var input = GameObject.Find("InputSystem").GetComponent<PlayerInput>();
            var action = input.actions["Controller"];
            action.Enable();

            var actionReference = InputActionReference.Create(action);
            Container.BindInstance(actionReference);
            Container.Bind<OpenXRInput>().AsSingle().NonLazy();
        }
    }
}