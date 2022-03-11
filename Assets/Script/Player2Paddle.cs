using UnityEngine;

public class Player2Paddle : Paddle
{
    // public static PlayerPaddle instance;
    public Rigidbody2D ball;
    public bool ComputerPaddle;
    private Vector2 _direction;
    public float SpeedUp;
    public float kekuatanPukulan;
    private void Update() { 
        ControlerPaddle();
    }

    private void ControlerPaddle(){ //! fungsi kontroler Paddle player
        if(ComputerPaddle == true){
             if (this.ball.velocity.x > 0.0f){ //! check apakah bola udah ada dikanan net
            if (this.ball.position.y > this.transform.position.y){ //? posisi bola lebih besar dari paddle
                rigidbody.AddForce(Vector2.up * this.speed);
            }else if(this.ball.position.y < this.transform.position.y){ //? posisi bola lebih besar dari paddle
                rigidbody.AddForce(Vector2.down * this.speed);
            }
        }else{  //! check apakah bola udah ada dikiri net
            if (this.transform.position.y > 0.0f){ //? apabila ada diatas maka akan kembali ketengah
                rigidbody.AddForce(Vector2.down * this.speed);
            }else if (this.transform.position.y > 0.0f){ //? apabila ada dibawah maka akan kembali ketengah
                rigidbody.AddForce(Vector2.up * this.speed);
            }
        }
        }else{
            if(Input.GetKey(KeyCode.UpArrow)){
                    _direction = Vector2.up;
                }else if(Input.GetKey(KeyCode.DownArrow)){
                    _direction = Vector2.down;
                }else{
                    _direction = Vector2.zero;
                }
            }
    }
    private void FixedUpdate() { //! mengatur kecepatan paddle 
        if(_direction.sqrMagnitude != 0){
            rigidbody.AddForce(_direction * this.speed);
        }
    }
    
    public void MenambahKecepatan(){ //! fungsi mengaktifkan ultimate movement speed
        speed = SpeedUp;
    }

    public void MenambahkanPukulan(){ //! fungsi mengaktifkan ultimate bounceStrength
        bounceStrength = kekuatanPukulan;
    }
    public void ResetSpeedP2(){
        speed = 13;
    }
    public void ResetBounceP2(){
        bounceStrength = 2;
    }
}
