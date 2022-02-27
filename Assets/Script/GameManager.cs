using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // //! input data
    public GameObject tampilkan; //pop-up kemenangnan
    public Ball ball;
    public Paddle player1Paddle;
    public Paddle player2Paddle;
    public Text player1Score;
    public Text player2Score;
    public Text tampilScore;
    private int _player1Score;
    private int _player2Score;
    
    
    public void Player1Scores(){ // menangkap parameter dari scoring zone
        _player1Score++; // menambahkan score player 1
        this.player1Score.text = _player1Score.ToString();
        ResetRound();
    }
    public void Player2Scores(){ // menangkap parameter dari scoring zone
        _player2Score++; // menambahkan score player 1
        this.player2Score.text = _player2Score.ToString();
        ResetRound();
    }

    private void  ResetRound(){ // fungsi untuk mengembalikan posisi player dan ball ke awal
        this.player1Paddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

    void Update(){ // check siapa pemenang dan menampilkan pop-up informasi
        if (_player1Score == 2 || _player2Score == 2)
        {
            tampilkan.SetActive(true);
            this.ball.PergerakanBola(false);
            this.player1Paddle.PergerakanPlayer(false);
            this.player2Paddle.PergerakanPlayer(false);
        this.tampilScore.text = this.player1Score.text +" - "+ this.player2Score.text;
        }else{
            tampilkan.SetActive(false);
            this.ball.PergerakanBola(true);
            this.player1Paddle.PergerakanPlayer(true);
            this.player2Paddle.PergerakanPlayer(true);
        }
    }

}
