using UnityEngine;

public class PlayerPaddle : Paddle
{
    public bool WS_Control;
    public bool UpDown_Control;
    private Vector2 _direction;
    private void Update() {
        if(this.WS_Control == true && this.UpDown_Control == true){
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
                _direction = Vector2.up;
            }else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
                _direction = Vector2.down;
            }else{
                _direction = Vector2.zero;
            }
        }else if (this.WS_Control == true){
            if(Input.GetKey(KeyCode.W)){
                _direction = Vector2.up;
            }else if(Input.GetKey(KeyCode.S)){
                _direction = Vector2.down;
            }else{
                _direction = Vector2.zero;
            }
        }else if(this.UpDown_Control == true){
            if(Input.GetKey(KeyCode.UpArrow)){
                _direction = Vector2.up;
            }else if(Input.GetKey(KeyCode.DownArrow)){
                _direction = Vector2.down;
            }else{
                _direction = Vector2.zero;
            }
        }else{
                _direction = Vector2.zero;
        }
    }

    private void FixedUpdate() {
        if(_direction.sqrMagnitude != 0){
            rigidbody.AddForce(_direction * this.speed);
        }
    }
}
