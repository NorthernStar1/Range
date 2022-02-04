using Game.StateMachine;
using UnityEngine;

public class PlayerWalkState : IBaseState
{
    private readonly PlayerController player;
    private float _walkSpeed = 5f;
    private float _crosshairSize = 100f;
    public PlayerWalkState(PlayerController player)
    {
        this.player = player;
        
    }
    public void Enter(IBaseState fromState)
    {
        CrosshairDynamic.Singleton.CrosshairSetup(_crosshairSize);
        player.CurrentSpeed = _walkSpeed;
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
        if (player.MoveDirection == Vector3.zero && player.CharacterController.isGrounded)
            player.SwitchState<PlayerIdleState>();
        if (player.CharacterController.isGrounded == false || (Input.GetKey(KeyCode.Space) && Stamina._StaminaCurrentValue > 20f))
            player.SwitchState<PlayerJumpingState>();
        if (Input.GetKey(KeyCode.LeftShift) && player.CharacterController.isGrounded && Stamina._StaminaCurrentValue > 10f)
            player.SwitchState<PlayerRunState>();
    }
    private void StaminaChange()
    {
        Stamina._StaminaCurrentValue += 10f * Time.deltaTime;
    }
}
