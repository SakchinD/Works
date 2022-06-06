using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class PlayerInitSystem : IEcsInitSystem
    {
        PlayerUnityComponent _playerUnity;
        readonly EcsWorld _world = null;
        
        public void Init ()
        {
            var playerEntity = _world.NewEntity();
            ref var playerCompanent = ref playerEntity.Get<PlayerComponent>();
            ref var playerInputCompanent = ref playerEntity.Get<PlayerInputComponent>();

            var playerGO = GameObject.FindGameObjectWithTag("Player");
            playerGO.GetComponent<CollisionUnityComponent>().ecsWorld = _world;

            playerCompanent.speed = _playerUnity.speed;
            playerCompanent.rigidbody = playerGO.GetComponent<Rigidbody>();
            playerCompanent.collider = playerGO.GetComponent<SphereCollider>();
        }
    }
}