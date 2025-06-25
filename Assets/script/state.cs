using UnityEngine;
using UnityEngine.InputSystem.Utilities;

namespace Wanyi
{
    public class State
    {
        private string name;

        protected Player player;
        protected StateMachine stateMachine;
        protected float timer;
        
        public State(Player _player, StateMachine _stateMachine, string _name)
        {
            player = _player;
            stateMachine = _stateMachine;
            name = _name;
        }

        public virtual void Enter()
        {
            Debug.Log($"<color=#6f6>進入 <{name}> 狀態</color>");

            timer = 0;
        }
        public virtual void Update()
        {
            // Debug.Log($"<color=#777>進入 <{name}> 狀態</color>");
            timer += Time.deltaTime;
        }
        public virtual void Exit()
        {
            Debug.Log($"<color=#f66>進入 <{name}> 狀態</color>");
        }
    }
}
