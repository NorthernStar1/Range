using Game.StateMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour, IStateSwitcher
{
    [Header("Movement")]
    [SerializeField] private float _gravity = 9f;
    public Vector3 MoveDirection { get; set; }
    public float CurrentSpeed = 1f;

    public CharacterController CharacterController;
   

    [Header("Rotate")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _sensivity = 30f;
    private Vector2 _rotationVelocity;
    private float _cameraUpLimit = 90f;
    private float _cameraDownLimit = -90f;

    public Vector3 JumpVelocity { get; set; }
    public CrosshairDynamic Crosshair;
    public IBaseState CurrentState { get; set; }
    public List<IBaseState> States { get; set; }

    public Camera Camera => _playerCamera;

    public static PlayerController Singleton;




    private void Awake()
    {
        Singleton = this;
        StartCoroutine(InitPlayer());
    }
    private void Update()
    {
        CurrentState?.Update();
        Move();
    }
    private void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        MoveDirection = new Vector3(x, 0, z);

        Vector3 gravityelocity = Vector3.up * _gravity * Time.deltaTime;

            JumpVelocity -= gravityelocity;

        var movementVelosity = transform.TransformDirection(MoveDirection + JumpVelocity)* CurrentSpeed * Time.deltaTime;
        CharacterController.Move(movementVelosity);
    }
    public void Rotate()
    {
        _rotationVelocity.x += Input.GetAxis("Mouse X") * _sensivity * Time.deltaTime;
        _rotationVelocity.y += Input.GetAxis("Mouse Y") * _sensivity * Time.deltaTime;

        if (_rotationVelocity.y > _cameraUpLimit)
            _rotationVelocity.y = _cameraUpLimit;
        if (_rotationVelocity.y < _cameraDownLimit)
            _rotationVelocity.y = _cameraDownLimit;

        _playerCamera.transform.localRotation = Quaternion.Euler(-_rotationVelocity.y, 0f, 0f);
        _player.transform.localRotation = Quaternion.Euler(0f, _rotationVelocity.x, 0f);
    }
    public void SwitchState<State>() where State : IBaseState
    {
        var nextState = States.FirstOrDefault(x => x is State);
        if (nextState == default)
        {
            throw new Exception("Try to switch a nonexistent state");
        }

        var fromStateName = CurrentState == null ? "null" : CurrentState.GetType().Name;
        Debug.Log($"Switch state <color=yellow>{fromStateName}</color> -> <color=yellow>{nextState.GetType().Name}</color>.");

        CurrentState?.Exit(nextState);
        nextState.Enter(CurrentState);
        CurrentState = nextState;
    }
    public void SwitchState(Type stateType)
    {
        var nextState = States.FirstOrDefault(x => x.GetType() == stateType);
        if (nextState == default)
        {
            throw new Exception("Try to switch a nonexistent state");
        }

        CurrentState?.Exit(nextState);

        nextState.Enter(CurrentState);

        CurrentState = nextState;
    }
    private IEnumerator InitPlayer()
    {
        CurrentSpeed = 1f;

        while (CharacterController.isGrounded == false)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        CharacterController = GetComponent<CharacterController>();
        

        _playerCamera.transform.localRotation = Quaternion.identity;
        _player.transform.localRotation = Quaternion.identity;


        JumpVelocity = Vector3.zero;


        States = new List<IBaseState>()
        {
            new PlayerIdleState(this),
            new PlayerWalkState(this),
            new PlayerJumpingState(this),
            new PlayerRunState(this),
        };

        SwitchState<PlayerIdleState>();


    }

}
