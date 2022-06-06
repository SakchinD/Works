using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class PlayerMoveSystem : IEcsRunSystem
    {
        EcsFilter<PlayerComponent,PlayerInputComponent> _ecsFilter;
        public void Run()
        {
            foreach(var i in _ecsFilter)
            {
                ref var playerComponent = ref _ecsFilter.Get1(i);
                ref var pInputCompanent = ref _ecsFilter.Get2(i);

                playerComponent.rigidbody.AddForce(pInputCompanent.moveInput 
                    * playerComponent.speed,ForceMode.Impulse);
            }
        }
    }
}