using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
        public GameObject player;
    public float speed = 10.0f;
    // protected Rigidbody2D _rigidbody;
    public new Rigidbody2D rigidbody { get; private set; }

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>(); 
    }
    public void ResetPosition(){
        rigidbody.position = new Vector2(rigidbody.position.x, 0.0f);
        rigidbody.velocity = Vector2.zero;
    }

        public void PergerakanPlayer(bool iyaTidak){
        player.SetActive(iyaTidak);
    }
}
