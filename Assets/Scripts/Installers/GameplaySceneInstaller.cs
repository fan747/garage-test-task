using Assets.Scripts.Garage;
using Assets.Scripts.Other;
using Assets.Scripts.Player;
using Assets.Scripts.Services.InputService;
using Assets.Scripts.Spawners;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private PlayerController _playerPrefab;
        [SerializeField] private GarageDoorsOpener _garageDoorsOpener;

        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private Transform _doorLeftTransform;
        [SerializeField] private Transform _doorRightTransform;

        [SerializeField] private List<GameObject> _spawnedGameObjects;
        [SerializeField] private List<Transform> _spawnedGameObjectPositions;

        public override void InstallBindings()
        {
            BindInput();
            BindPlayer();
            BindGarage();
            BindItems();
        }

        private void BindItems()
        {
            Container.Bind<List<GameObject>>().FromInstance(_spawnedGameObjects).AsSingle();
            Container.Bind<List<Transform>>().FromInstance(_spawnedGameObjectPositions).AsSingle();
            Container.Bind<ItemSpawner>().FromNew().AsSingle();

            ItemSpawner itemSpawner = Container.Instantiate<ItemSpawner>();
            itemSpawner.RandomlySpawnItems();
        }

        private void BindGarage()
        {
            Container.Bind<Transform>().WithId(GameConstants.DoorLeftId).FromInstance(_doorLeftTransform).AsCached();
            Container.Bind<Transform>().WithId(GameConstants.DoorRightId).FromInstance(_doorRightTransform).AsCached();
            Container.Bind<GarageDoorsOpener>().FromInstance(_garageDoorsOpener).AsSingle();
        }

        private void BindPlayer()
        {
            PlayerController playerController = Container.InstantiatePrefabForComponent<PlayerController>(_playerPrefab, _playerSpawnPosition.position, Quaternion.identity, null);
            Container.BindInterfacesAndSelfTo<PlayerController>().FromInstance(playerController).AsSingle();
        }

        private void BindInput()
        {
            Container.Bind<FixedJoystick>().FromInstance(_joystick).AsSingle();
            Container.Bind<IInput>().To<MobileInput>().FromNew().AsSingle();
        }
    }
}