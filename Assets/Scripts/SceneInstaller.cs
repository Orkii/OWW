using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using Zenject.SpaceFighter;

public class SceneInstaller : MonoInstaller {
    //[SerializeField] private PlayerInput input;
    [SerializeField] MovementCharacteristic playerMove;
    [SerializeField] SurvivalItemsList itemsToSpawnOnShelfs;
    PlayerInput playerInput;

    public override void InstallBindings() {
        ICameraInput cameraInput = new CameraInputTouch();
        IItemClick itemClick = new ItemClick();

        PlayerInput playerInput = new PlayerInput(cameraInput, itemClick);

        playerInput.cameraInput = cameraInput;
        IInput input = playerInput;


        






        Container.Bind<IInput>().FromInstance(input);
        Container.Bind<ICameraInput>().FromInstance(cameraInput);
        Container.Bind<IItemClick>().FromInstance(itemClick);

        Container.Bind<SurvivalItemsList>().FromInstance(itemsToSpawnOnShelfs);

        Container.Bind<MovementCharacteristic>().To<MovementCharacteristic>().FromInstance(playerMove);

        Container.Inject(cameraInput);
        Container.Inject(playerInput);
    }
}
