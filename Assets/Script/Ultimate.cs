using UnityEngine;

public class Ultimate : MonoBehaviour
{
    public float kecepatanTurun;
    public GameObject MotherUltimate;
    public int IDUltimate;
    public GameObject[] BankUltimate;
    private Rigidbody2D _rigidbody;
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        TampilkanUltimate();
        // Debug.Log(kecepatanTurun);
        ItemJatuh();
    }

    private void TampilkanUltimate(){ // fungsi menampilkan icon ultimate
        GameObject popUpSebelumnya = GameObject.FindGameObjectWithTag("Ultimate");
        if (popUpSebelumnya != null) Destroy(popUpSebelumnya); // menghapus pop-up sebelumnya

        GameObject isi = Instantiate(BankUltimate[IDUltimate]); // memanggil pop-up pada array
        isi.transform.SetParent(MotherUltimate.transform,false); // memasukkan keadalam parent content
    }

    private void ItemJatuh(){ // mengatur jatuh item
    _rigidbody.velocity = new Vector2(0.0f, kecepatanTurun); // mengatur kecepatan jatuh

        if(_rigidbody.position.y <= -10f){
            // mengembalikan ke posisi awal ketika menyentuh batas
            _rigidbody.position = new Vector2(Random.Range(-2f, 2f), 10f);
            IDUltimate++;
        }
        
        if(IDUltimate > BankUltimate.Length - 1){
            IDUltimate = 0;
        }
    }

    public void StopUltimate(bool kondisi){
        MotherUltimate.SetActive(kondisi);
    }

}
