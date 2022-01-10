using System;
using System.Collections.Generic;
namespace Game.StateMachine
{
    public interface IBaseState
    {
        public abstract void Enter(IBaseState fromState);
        public abstract void Exit(IBaseState toState);
        public abstract void Update();
    }

    public interface IStateSwitcher
    {
        IBaseState CurrentState { get; set; }
        List<IBaseState> States { get; set; }
        void SwitchState<State>() where State : IBaseState;
        void SwitchState(Type stateType);
    }
}