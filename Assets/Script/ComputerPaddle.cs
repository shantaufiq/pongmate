using UnityEngine;

public class ComputerPaddle : Paddle
{
    public Rigidbody2D ball;
    private void FixedUpdate() { // kontroler paddle
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
    }
}
