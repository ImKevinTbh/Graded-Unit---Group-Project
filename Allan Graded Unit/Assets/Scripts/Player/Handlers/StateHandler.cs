using System;
using System.Collections.Generic;
using UnityEngine;

public class StateAPI
{
    public enum MovementStateType
    {
        Still,
        Walking,
        Jumping,
        Falling,
        Dashing
    }


    public static MovementStateType CheckMovementState(GameObject gameObject)
    {
        MovementStateType returnState = MovementStateType.Still;
        try
        {
            if (gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.x != 0f)
            {
                returnState = MovementStateType.Walking;
            }
            if (gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.x == 0f)
            {
                returnState = MovementStateType.Still;
            }

            if (!gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
            {
                returnState = MovementStateType.Jumping;
            }
            if (!gameObject.GetComponent<MovementHandler>().OnGround && gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                returnState = MovementStateType.Falling;
            }
            else
            {
                returnState = MovementStateType.Still;
            }
        }

        catch (Exception e)
        {
            return MovementStateType.Still;
        }

        return returnState;
    }
}

public class StateHandler : MonoBehaviour
{
    public StateAPI.MovementStateType State { get; set; } = StateAPI.MovementStateType.Still;
    public string MovementStateName;


    public void Update()
    {
        State = StateAPI.CheckMovementState(gameObject);
        MovementStateName = State.ToString();
    }
}

