using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputComponent> _ecsFilter;

        public void Run()
        {
            foreach(var i in _ecsFilter)
            {
                ref var playerInput = ref _ecsFilter.Get1(i);
                playerInput.moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0,
                    Input.GetAxisRaw("Vertical"));
            }
        }
    }
}