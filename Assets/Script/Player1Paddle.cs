using UnityEngine;

public class Player1Paddle : Paddle
{
    // public static PlayerPaddle instance;
    private Vector2 _direction;
    
    private void Update() { 
        ControlerPaddle();
    }

    private void ControlerPaddle(){ //! fungsi kontroler Paddle player
        if(Input.GetKey(KeyCode.W)){
                _direction = Vector2.up;
            }else if(Input.GetKey(KeyCode.S)){
                _direction = Vector2.down;
            }else{
                _direction = Vector2.zero;
            }
    }
    private void FixedUpdate() { //! mengatur kecepatan paddle 
        if(_direction.sqrMagnitude != 0){
            rigidbody.AddForce(_direction * this.speed);
        }
    }
    public void MenambahKecepatan(){ //! fungsi mengaktifkan ultimate movement speed
        speed = 27;
    }
        public void MenambahkanPukulan(){ //! fungsi mengaktifkan ultimate bounceStrength
        bounceStrength = 200;
    }
    public void ResetSpeedP1(){
        speed = 13;
    }
    public void ResetBounceP1(){
        bounceStrength = 2;
    }
}
