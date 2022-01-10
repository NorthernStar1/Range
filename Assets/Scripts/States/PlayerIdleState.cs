using Game.StateMachine;
using UnityEngine;

public class PlayerIdleState : IBaseState
{
    private readonly PlayerController player;
    private float _crosshairSize = 70f;
    public PlayerIdleState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter(IBaseState fromState)
    {
        player.CurrentSpeed = 5f;
    }

    public void Exit(IBaseState toState)
    {

    }

    public void Update()
    {
        player.Crosshair.CrosshairSetup(_crosshairSize);
        player.Rotate();
        StateChange();
        StaminaChange();
    }

    private void StateChange()
    {
        if (Input.GetKey(KeyCode.LeftShift) && player.MoveDirection != Vector3.zero && player.CharacterController.isGrounded && Stamina._StaminaCurrentValue > 10f)
            player.SwitchState<PlayerRunState>();
        if (player.MoveDirection != Vector3.zero && player.CharacterController.isGrounded && Stamina._StaminaCurrentValue > 5f)
            player.SwitchState<PlayerWalkState>();
        if (player.CharacterController.isGrounded == false || (Input.GetKey(KeyCode.Space) && Stamina._StaminaCurrentValue > 20f))
            player.SwitchState<PlayerJumpingState>();
    }
     private void StaminaChange()
    {
        Stamina._StaminaCurrentValue += 17f * Time.deltaTime;
    }
}
