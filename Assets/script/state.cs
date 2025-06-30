using UnityEngine;
using UnityEngine.InputSystem.Utilities;

namespace Wanyi
{
    public class State
    {
        protected string name;
        protected StateMachine stateMachine;
        protected float timer;

        public State(Player _player, StateMachine _stateMachine, string _name)
        {
            stateMachine = _stateMachine;
            name = _name;
        }

        public State(StateMachine stateMachine, string name)
        {
            this.stateMachine = stateMachine;
            this.name = name;
        }

        public virtual void Enter()
        {
           
            timer = 0;
        }

        public virtual void Update()
        {
            timer += Time.deltaTime;
        }

        public virtual void Exit()
        {
            
        }
    }
}