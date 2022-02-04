using Game.StateMachine;
using UnityEngine;

public class PlayerRunState : IBaseState
{
    private readonly PlayerController player;
    private float _runSpeed = 10f;
    private float _crosshairSize = 120f;

    public PlayerRunState(PlayerController player)
    {
        this.player = player;

    }
    public void Enter(IBaseState fromState)
    {
        CrosshairDynamic.Singleton.CrosshairSetup(_crosshairSize);
        player.CurrentSpeed = _runSpeed;
    }

    public void Exit(IBaseState toState)
    {
        
    }

    public void Update()
    {
        player.Rotate();
        StateChange();
        StaminaChange();
    }
    private void StateChange()
    {
        if (Stamina._StaminaCurrentValue < 1f || (!Input.GetKey(KeyCode.LeftShift) && player.CharacterController.isGrounded))
            player.SwitchState<PlayerWalkState>();
        if (player.CharacterController.isGrounded == false || (Input.GetAxis("Jump") > 0 && Stamina._StaminaCurrentValue > 20f))
            player.SwitchState<PlayerJumpingState>();
    }
    private void StaminaChange()
    {
        Stamina._StaminaCurrentValue -= 15f * Time.deltaTime;
    }
}
