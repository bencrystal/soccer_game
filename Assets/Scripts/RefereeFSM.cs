using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Referee : Player //was AIPlayer
{
    private FiniteStateMachine<Referee> _fsm;

    #region Lifecycle Management
    public Referee(GameObject gameObject) : base(gameObject)
    {
        _fsm = new FiniteStateMachine<AIPlayer>(this);
        _fsm.TransitionTo<ChaseBall>();
    }

    public override void Update()
    {
        _fsm.Update();
        MoveInDirection(_GetDirectionFromBallPosition());
    }

    #endregion

    #region Core Functionality

    private Direction[] _GetDirectionFromBallPosition()
    {
        return GetDirections(Services.GameController.ball);
    }

    #endregion

    #region States

    private abstract class RefereeState : FiniteStateMachine<Referee.State { }

    private class ChaseBall : AIPlayerState
    {
        public override void OnEnter()
        {
            // change my expression to be angry
            // pick a defender
        }

        public override void Update()
        {
            base.Update();
            // try to foul that defender

            if (Services.GameController.ball.transform.position.x < 0 && Context.playerTeam ||
                Services.GameController.ball.transform.position.x > 0 && !Context.playerTeam)
            {
                TransitionTo<Defense>();
            }
        }

        public override void OnExit()
        {
            // get rid of angry face
        }
    }

    private class RunFromBall : AIPlayerState
    {

    }

    private class CallFoul : AIPlayerState
    {

    }

    #endregion
}
