using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class TTTAgent : Agent
{
    [SerializeField] GameBoard board;

    int playingToken = -1;

    //초기화 작업을 위해 한번 호출되는 메소드
    public override void Initialize()
    {

    }

    //에피소드(학습단위)가 시작할때마다 호출
    public override void OnEpisodeBegin()
    {
        board.NewGame();
    }

    //환경 정보를 관측 및 수집해 정책 결정을 위해 브레인에 전달하는 메소드
    public override void CollectObservations(Unity.MLAgents.Sensors.VectorSensor sensor)
    {
        sensor.AddObservation(board._cells[0]);
        sensor.AddObservation(board._cells[1]);
        sensor.AddObservation(board._cells[2]);
        sensor.AddObservation(board._cells[3]);
        sensor.AddObservation(board._cells[4]);

        sensor.AddObservation(board._cells[5]);
        sensor.AddObservation(board._cells[6]);
        sensor.AddObservation(board._cells[7]);
        sensor.AddObservation(board._cells[8]);

        sensor.AddObservation(board.currentToken);
    }

    //브레인(정책)으로 부터 전달 받은 행동을 실행하는 메소드
    public override void OnActionReceived(float[] vectorAction)
    {
        int index = board.GetClicked();
        if(index != -1)
            SetReward(-0.001f);
    }

    //개발자(사용자)가 직접 명령을 내릴때 호출하는 메소드(주로 테스트용도 또는 모방학습에 사용)
    public override void Heuristic(float[] actionsOut)
    {

    }
}
