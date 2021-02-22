using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class Referee : Player //was AIPlayer
{
    

    private FiniteStateMachine<Referee> _fsm;

    #region Lifecycle Management
    public Referee(GameObject gameObject) : base(gameObject)
    {
        _fsm = new FiniteStateMachine<Referee>(this);
        _fsm.TransitionTo<ChaseBall>();
    }

    public override void Update()
    {
        _fsm.Update();

    }

    public void FollowBall()
    {
        MoveInDirection(_GetDirectionFromBallPosition());
    }

    public void AvoidBall()
    {
        MoveInDirection(GetOppositeDirections(Services.GameController.ball));
    }

    #endregion

    #region Core Functionality

    private Direction[] _GetDirectionFromBallPosition()
    {
        return GetDirections(Services.GameController.ball);
    }


    /*AS LONG AS BALL IS CENTERED AT MIDDLE OF FIELD
    protected Direction[] GetOppositeDirections(GameObject toMoveTowards)
    {
        return GetDirections(-toMoveTowards.transform.position.x, -toMoveTowards.transform.position.y);
    }*/


    #endregion

    #region States
}




public abstract class RefereeState : FiniteStateMachine<Referee>.State { }

public class ChaseBall : RefereeState
{

    




    public override void OnEnter()
    {
        
    }



    public override void Update()
    {
        

        base.Update();

        //Context.position

        Context.FollowBall();


        var distance = (Services.GameController.ball.transform.position - Context.position).magnitude;

        //play with numbers

        if (distance < 6)
        {
            Debug.Log("Waiting");
            //TransitionTo<RunFromBall>();
            TransitionTo<Stationary>();
            
        }
    }

    public override void OnExit()
    {
        // get rid of angry face
    }
}

public class RunFromBall : RefereeState
{
    public override void Update()
    {
        
        base.Update();

        //Context.position

        Context.AvoidBall();

        var distance = (Services.GameController.ball.transform.position - Context.position).magnitude;

        //play with numbers

        if (distance > 6)
        {
            Debug.Log("Waiting");
            //TransitionTo<ChaseBall>();
            TransitionTo<Stationary>();
        }
    }
}

public class CallFoul : RefereeState
{

}



public class Stationary : RefereeState
{
    

    



    //this is a transitionary state to pause when returning from a foul or to reevaluate movement without being super jittery
    //DOES NOT ACCOUNT FOR PLAYERS FOULING WHILE IN THIS STATE

    float timeout = 3f;
    public override void Update()
    {
        
        timeout -= Time.deltaTime;
        if (timeout > 0) return;

        var distance = (Services.GameController.ball.transform.position - Context.position).magnitude;

        //play with numbers

        if (distance < 6)
        {
            Debug.Log("Avoiding");
            TransitionTo<RunFromBall>();
        }

        else
        {
            Debug.Log("Chasing");
            TransitionTo<ChaseBall>();
        }


    }


    #endregion
}

