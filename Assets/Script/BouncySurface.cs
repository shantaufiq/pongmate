using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BouncySurface : MonoBehaviour //! Nambah kekuatan pukulan 
{
    public float bounceStrength = 1f; // kekuatan pukulan
    private void OnCollisionEnter2D(Collision2D collision) { // menangkap element 2 D
        Ball ball = collision.gameObject.GetComponent<Ball>();
        Debug.Log("pantulan aktif");

        if (ball != null){
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
        }
    }
}
