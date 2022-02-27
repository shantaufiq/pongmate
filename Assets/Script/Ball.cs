using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject bola; // ngambil object bola
    public float speed = 200f;
    private Rigidbody2D _rigidbody;
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        ResetPosition();
        AddStartingForce();
    }
    public void ResetPosition(){
        _rigidbody.position = Vector2.zero;
        _rigidbody.velocity = Vector2.zero;
    }

    public void AddStartingForce(){
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f):
                                        Random.Range(0.5f, 1f);
        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
    }
    
    public void AddForce(Vector2 force){
        _rigidbody.AddForce(force);
    }

    public void PergerakanBola(bool iyaTidak){
        bola.SetActive(iyaTidak);
    }

}
