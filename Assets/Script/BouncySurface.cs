using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BouncySurface : MonoBehaviour //! Nambah kekuatan pantulan 
{
    public float bounceStrength = 1f; // kekuatan pantulan
    private void OnCollisionEnter2D(Collision2D collision) { // menangkap element 2 D
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null){
            Vector2 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
        }
    }
}
