using UnityEngine;
using Game.StateMachine;

public class PlayerJumpingState : IBaseState
{
    private readonly PlayerController player;
    private float _crosshairSize = 130f;
    private Vector3 _jumpPower = Vector3.up * 2f;
    public PlayerJumpingState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter(IBaseState fromState)
    {
        CrosshairDynamic.Singleton.CrosshairSetup(_crosshairSize);
    }

    public void Exit(IBaseState toState)
    {
        
    }

    public void Update()
    {
        
        Jump();
        player.Rotate();
        StateChange();
    }
    private void StateChange()
    {
        if (player.CharacterController.isGrounded && player.MoveDirection == Vector3.zero)
            player.SwitchState<PlayerIdleState>();
        if(player.MoveDirection != Vector3.zero && player.CharacterController.isGrounded)
            player.SwitchState<PlayerWalkState>();
    }
    public void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && player.CharacterController.isGrounded && Stamina._StaminaCurrentValue > 20f)
        {
            player.JumpVelocity = _jumpPower;
            StaminaChange();
        }
    }
    private void StaminaChange()
    {
        Stamina._StaminaCurrentValue -= 20f;
    }
}
