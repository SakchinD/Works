using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class CollisionUnityComponent : MonoBehaviour
    {
        public EcsWorld ecsWorld { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            var hit = ecsWorld.NewEntity();

            ref var hitCompanent = ref hit.Get<CollisionComponent>();

            hitCompanent.player = transform.gameObject;
            hitCompanent.other = other;

        }
    }
}