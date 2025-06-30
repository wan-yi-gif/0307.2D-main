using UnityEngine;

namespace Wanyi
{
    public class AttackArea : MonoBehaviour
    {
        [field: SerializeField, Header("攻擊力"), Range(0, 1000)]
        public float attack { get; private set; } = 30;
    }
}

