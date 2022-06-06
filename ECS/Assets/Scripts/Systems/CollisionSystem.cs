using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class CollisionSystem : IEcsRunSystem
    {
        UiUnityComponent _uiUnity;

        private EcsFilter<CollisionComponent> _ecsCollision;
        void IEcsRunSystem.Run () 
        {
            foreach (var i in _ecsCollision)
            {
                ref var collision = ref _ecsCollision.Get1(i);
                if (collision.other.CompareTag("Enemy"))
                {
                    _uiUnity.uiPanel.SetActive(true);
                    collision.player.SetActive(false);
                }

            }
        }
    }
}