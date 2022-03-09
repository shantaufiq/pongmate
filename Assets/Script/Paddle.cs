using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    public static Paddle instance;
    public GameObject player; // ngambil object player
    public float speed; //! kecepatan tiap player
    public float bounceStrength; //! kekuatan pukulan

    public new Rigidbody2D rigidbody { get; private set; }

    // public bool WS_Control;
    // public bool UpDown_Control;
    public EventTrigger.TriggerEvent ultimateTrigger; // ngambil trigger


    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>(); // mengambil rigidbody dari paddle
        instance = this;
    }
    public void ResetPosition(){ //! fungsi untuk mengembalikan ke posisi awal
        rigidbody.position = new Vector2(rigidbody.position.x, 0.0f);
        rigidbody.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision) { //! fungsi untuk memberi status pada paddle -> dieksekusi di GameManager.cs
        Ball ball = collision.gameObject.GetComponent<Ball>(); 

        if (ball != null){ // check apabila bola menyentuh paddle  
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.ultimateTrigger.Invoke(eventData); // memanggil function
        }

        if (ball != null){
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
        }
    }

    public void PergerakanPlayer(bool iyaTidak){ //! fungsi untuk memberhentikan pergerakan player dieksekusi di GameManager.cs
        player.SetActive(iyaTidak);
    }


}
