using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //! input data
    public Ball ball;
    public Paddle player1Paddle;
    public Paddle player2Paddle;
    public Text playerScore;
    public Text computerScore;
    private int _player1Score;
    private int _player2Score;
    
    
    public void Player1Scores(){ // menangkap parameter dari scoring zone
        _player1Score++; // menambahkan score player 1
        this.playerScore.text = _player1Score.ToString();
        ResetRound();
    }
    public void Player2Scores(){ // menangkap parameter dari scoring zone
        _player2Score++; // menambahkan score player 1
        this.computerScore.text = _player2Score.ToString();
        ResetRound();
    }

    private void  ResetRound(){ // fungsi untuk mengembalikan posisi player dan ball ke awal
        this.player1Paddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }
}
