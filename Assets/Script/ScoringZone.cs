using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour //! jika mengenai tembok maka player mendapatkan point 
{
    public EventTrigger.TriggerEvent scoreTrigger;
    private void OnCollisionEnter2D(Collision2D collision) { 
        Ball ball = collision.gameObject.GetComponent<Ball>(); //? ngambil komponen bola

        if (ball != null){ //? check apabila bola menyentuh tembok  
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData); // memanggil function
            SuaraManager.instance.PanggilSuara(3);
        }
    }
}
