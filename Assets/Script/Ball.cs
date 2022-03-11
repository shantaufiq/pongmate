using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject bola; // ngambil object bola
    public float speed;
    private Rigidbody2D _rigidbody;
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void PlayBall(){
        ResetPosition();
        AddStartingForce();
    }
    public void ResetPosition(){ //! mengembalikan bola ke tengah
        _rigidbody.position = Vector2.zero;
        _rigidbody.velocity = Vector2.zero;
    }

    public void AddStartingForce(){ //! fungsi untuk menggerakan bola
        float x = Random.value < 0.5f ? -1.7f : 1.7f; // membuat bola bergerak secara horizontal
        float y = Random.value < 0.5f ? Random.Range(-1.5f, -0.6f): // membuat bola bergerak secara vertikal
                                        Random.Range(0.5f, 1.5f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed); // mengatur kecepatan bola
    }
    
    public void AddForce(Vector2 force){
        _rigidbody.AddForce(force);
    }

    public void StopBall(bool status){ //! fungsi mematikan GameObject Bola
        bola.SetActive(status);
    }
}
