using UnityEngine;

namespace Client {
    struct PlayerComponent 
    {
        internal Rigidbody rigidbody;
        internal SphereCollider collider;
        internal float speed;
    }
}