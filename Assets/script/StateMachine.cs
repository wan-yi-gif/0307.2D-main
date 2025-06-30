using System;
using UnityEngine;

namespace Wanyi
{
    public class StateMachine
    {
        private State currenState;

        /// <summary>
        /// 初始化狀態機
        /// </summary>
        /// <param name="defaultState">指定預設狀態</param>
        public void Initialize(State defaultState)
        {
            currenState = defaultState;
            currenState.Enter();
        }

        /// <summary>
        /// 更新狀態
        /// </summary>
        public void UpdateState()
        {
            currenState.Update();
        }

        /// <summary>
        /// 切換狀態
        /// </summary>
        /// /// <param name="newState">指定預設狀態</param>
        public void SwitchState(State newState)
        {
            currenState.Exit();
            currenState = newState;
            currenState.Enter();
        }

        internal void SwitchState(object playerAttack)
        {
            throw new NotImplementedException();
        }

        internal void Initialize(EnemyIdle enemyIdle)
        {
            throw new NotImplementedException();
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }
    }
}
