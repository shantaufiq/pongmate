using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //! input data
    public GameObject GetUltiP1; // animasi ulti
    public GameObject GetUltiP2; // animasi ulti
    public GameObject popUpStart;
    public GameObject tampilkan; // pop-up kemenangnan
    public Ball ball;
    public Ultimate ItemUltimate;
    public Paddle player1Paddle; // pengaturan poin
    public Paddle player2Paddle; // pengaturan poin
    public Text player1Score;
    public Text player2Score;
    public Text tampilScore; // pop-up end game
    private int _player1Score;
    private int _player2Score;
    private bool? BallStatus = new bool?(); // mengecek status bola, bagian siapa yang mukul
    private bool? ResetBallStatus = new bool?(); // reset status

    protected int IDUltimate; 
    private bool checkPop = true;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        StartGame();
    }
    void Update(){ 
        CheckKemenangan();

        if(Input.GetKey(KeyCode.Space)){ // menampilkan pop-up pause
            if(checkPop == false){  
                checkPop = !checkPop;
                StartGame();
                SuaraManager.instance.PanggilSuara(2);
            }
        }
    }
    public void Player1Scores(){ //! menangkap parameter dari scoring zone
        _player1Score++; // menambahkan score player 1
        this.player1Score.text = _player1Score.ToString();
        ResetRound();
    }
    public void Player2Scores(){ //! menangkap parameter dari scoring zone
        _player2Score++; // menambahkan score player 1
        this.player2Score.text = _player2Score.ToString();
        ResetRound();
    }
    public void ResetRound(){ //! fungsi untuk mengembalikan posisi player dan ball ke awal
        this.ItemUltimate.ResetPosition();
        this.player1Paddle.ResetPosition();
        this.player2Paddle.ResetPosition();
        this.ball.ResetPosition();
        BallStatus = ResetBallStatus;
        StartCoroutine(ReturnBall());
    }

    IEnumerator ReturnBall(){ //! corountine untuk ngehold bola ketika habis poin
        yield return new WaitForSecondsRealtime(3f);
        this.ball.AddStartingForce(); //? menggerakan bola
    }
    private void CheckKemenangan(){ //! check siapa pemenang dan menampilkan pop-up informasi
        if (_player1Score == 10 || _player2Score == 10)
        {
            tampilkan.SetActive(true);
            this.ball.StopBall(false);
            this.player1Paddle.PergerakanPlayer(false);
            this.player2Paddle.PergerakanPlayer(false);
            this.tampilScore.text = this.player1Score.text +" - "+ this.player2Score.text;
            this.ItemUltimate.StopUltimate(false);
            PlayerPrefs.SetInt("scorePlayer1", _player1Score);
            PlayerPrefs.SetInt("scorePlayer2", _player2Score);
            SuaraManager.instance.BacksoundOff();
        }
    }
    private void StartGame(){
        if(checkPop == true){
        popUpStart.SetActive(true); 
        this.player1Paddle.PergerakanPlayer(false);
        this.player2Paddle.PergerakanPlayer(false);
        this.ItemUltimate.StopUltimate(false);
        this.ball.StopBall(false);
        SuaraManager.instance.BacksoundOff();
        }
    }
    public void ReturnGame(){ //! fungsi button di pop-up startgame 
        popUpStart.SetActive(false); 
        this.player1Paddle.PergerakanPlayer(true);
        this.player2Paddle.PergerakanPlayer(true);
        this.ItemUltimate.StopUltimate(true);
        this.ball.StopBall(true);
        checkPop = false; //? check status pop-up
        SuaraManager.instance.BacksoundPlay();
    }
    public void CheckStatusBola(bool isi){ //! checker ketika bola nyentuh paddle - menangkap parameter boolean dari paddle
        BallStatus = isi;
    }
    public void KirimItemID(int index){ //! function untuk ngambil index item ultimate dari class Ultimate.cs
        this.IDUltimate = index;
        // Debug.Log("ID Ultimate dari game manager: " + IDUltimate);
    }
    public void KeluarinUltimate(){ //! Function Keluarin Ultimate Sesuai Index

        if (BallStatus == true){ //? kondisi ketika status bola true
            if (IDUltimate == 0){
                ItemUltimate.CheckUltimatePlayer(true, 1); //? mengirim informasi ultimate ke Ultimate.cs 
                SuaraManager.instance.PanggilSuara(4); //? play sound fx get ultimate
                GetUltiP1.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            } else if (IDUltimate == 1){
                ItemUltimate.CheckUltimatePlayer(true, 2); //? mengirim informasi ultimate ke Ultimate.cs
                SuaraManager.instance.PanggilSuara(4); //? play sound fx get ultimate
                GetUltiP1.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            } else if (IDUltimate == 2){
                ItemUltimate.CheckUltimatePlayer(true, 3); //? mengirim informasi ultimate ke Ultimate.cs
                SuaraManager.instance.PanggilSuara(5); //? play sound fx get ultimate
                GetUltiP1.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            }else if (IDUltimate == 3){
                ItemUltimate.CheckUltimatePlayer(true, 4); //? mengirim informasi ultimate ke Ultimate.cs
                SuaraManager.instance.PanggilSuara(5); //? play sound fx get ultimate
                GetUltiP1.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            }else{
                ItemUltimate.CheckUltimatePlayer(true, 10); //? mengirim informasi ultimate ke Ultimate.cs; 
            }
        } else if (BallStatus == false){ //? kondisi ketika status bola false
            if (IDUltimate == 0){
                ItemUltimate.CheckUltimatePlayer(false, 1); //? mengirim informasi ultimate ke Ultimate.cs
                SuaraManager.instance.PanggilSuara(4); //? play sound fx get ultimate
                GetUltiP2.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            } else if (IDUltimate == 1){
                ItemUltimate.CheckUltimatePlayer(false, 2); //? mengirim informasi ultimate ke Ultimate.cs
                SuaraManager.instance.PanggilSuara(4); //? play sound fx get ultimate
                GetUltiP2.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            } else if (IDUltimate == 2){
                ItemUltimate.CheckUltimatePlayer(false, 3); //? mengirim informasi ultimate ke Ultimate.cs
                SuaraManager.instance.PanggilSuara(5); //? play sound fx get ultimate
                GetUltiP2.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            }else if (IDUltimate == 3){
                ItemUltimate.CheckUltimatePlayer(false, 4); //? mengirim informasi ultimate ke Ultimate.cs
                SuaraManager.instance.PanggilSuara(5); //? play sound fx get ultimate
                GetUltiP2.GetComponent<Animation>().Play("UltiSpeed"); //? panggil animasi get ultimate
            }else{
                ItemUltimate.CheckUltimatePlayer(false, 10); //? mengirim informasi ultimate ke Ultimate.cs 
            }
        }
    }

}
