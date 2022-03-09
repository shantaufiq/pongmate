using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ultimate : MonoBehaviour
{
    // public static Ultimate instance;
    public float kecepatanTurun;
    public GameObject MotherUltimate;
    public int IDUltimate;
    public Player1Paddle player1;
    public Player2Paddle player2;
    public GameObject[] BankUltimate;
    private Rigidbody2D _rigidbody;
    
    public EventTrigger.TriggerEvent ultimateManager;
    
    protected bool? PlayerGetUlti = new bool?(); // check siapa yang dapet ulti
    protected bool? resetGetUlti = new bool?(); // check siapa yang dapet ulti

    protected int ItemIndex; // check ulti keberapa


    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        // instance = this;
    }

    private void Start() {
        ResetPosition();
    }

    private void Update() {
        TampilkanUltimate();
        // Debug.Log(kecepatanTurun);
        ItemJatuh();
        GameManager.instance.KirimItemID(IDUltimate);
        
    }

    private void FixedUpdate() {
        EksekusiUltimate();
    }

    private void TampilkanUltimate(){ //! fungsi menampilkan icon ultimate dengan mengisi parent elementnya
        GameObject popUpSebelumnya = GameObject.FindGameObjectWithTag("Ultimate");
        if (popUpSebelumnya != null) Destroy(popUpSebelumnya); // menghapus pop-up sebelumnya

        GameObject isi = Instantiate(BankUltimate[IDUltimate]); //? memanggil pop-up pada array
        isi.transform.SetParent(MotherUltimate.transform,false); //? memasukkan keadalam parent content

    }

    private void ItemJatuh(){ //! mengatur jatuh item
        _rigidbody.velocity = new Vector2(0.0f, kecepatanTurun); // mengatur kecepatan jatuh

        if(_rigidbody.position.y <= -10f){
            // mengembalikan ke posisi awal ketika menyentuh batas
            _rigidbody.position = new Vector2(Random.Range(-2f, 2f), 14f);
            IDUltimate++; // menambah index supaya itemnya ganti
        }

        if(IDUltimate > BankUltimate.Length - 1){ // mengembalikan ke index 0 apabila udah lebih dari panjang length 
            IDUltimate = 0;
        }
    }

    public void ResetPosition(){ //! mengembalikan ke posisi awal dengan urutan acak
        _rigidbody.position = new Vector2(Random.Range(-2f, 2f), 14f);
        _rigidbody.velocity = Vector2.zero;
        IDUltimate = Random.Range(0, BankUltimate.Length - 1);
    }

    public void StopUltimate(bool kondisi){ //! fungsi memberhentikan ultimate
        MotherUltimate.SetActive(kondisi);
    }

    private void OnTriggerEnter2D(Collider2D other) { //! check apabila bola mengenai item
        if (other.gameObject.tag == "Ball") {
            // Debug.Log("Ultimate Item ke: " + IDUltimate);
            GameManager.instance.KeluarinUltimate();
            ResetPosition();
        }
    }

    public void CheckUltimatePlayer(bool Pberapa, int ItemBerapa){
        PlayerGetUlti = Pberapa;
        ItemIndex = ItemBerapa;
        // Debug.Log("PlayerGetUlti: "+ PlayerGetUlti + " Item ulti ke: "+ ItemIndex);
    }

    public void EksekusiUltimate(){
        if(PlayerGetUlti == true){
            if (ItemIndex == 1 || ItemIndex == 2){
                player1.MenambahkanPukulan();
                StartCoroutine(ResetBounce1());
            } else if (ItemIndex == 3 || ItemIndex == 4){
                player1.MenambahKecepatan(); // tambah movement speed player 1
                StartCoroutine(ResetSpeed1());
            }else {
                Debug.Log("ulti tidak masuk ke player");
            }
        }else if(PlayerGetUlti == false){
            if (ItemIndex == 1 || ItemIndex == 2){
                player2.MenambahkanPukulan();
                StartCoroutine(ResetBounce2());
            } else if (ItemIndex == 3 || ItemIndex == 4){
                player2.MenambahKecepatan(); // tambah movement speed player 2
                StartCoroutine(ResetSpeed2());
            } else {
                Debug.Log("ulti tidak masuk ke player");
            }
        }
    }

    IEnumerator ResetSpeed1(){
        yield return new WaitForSecondsRealtime(5f);
        player1.ResetSpeedP1();
        PlayerGetUlti = resetGetUlti;
    }
    IEnumerator ResetSpeed2(){
        yield return new WaitForSecondsRealtime(5f);
        player2.ResetSpeedP2();
        PlayerGetUlti = resetGetUlti;
    }
    IEnumerator ResetBounce1(){
        yield return new WaitForSecondsRealtime(6f); 
        player1.ResetBounceP1();
        PlayerGetUlti = resetGetUlti;
    }
    IEnumerator ResetBounce2(){
        yield return new WaitForSecondsRealtime(6f);
        player2.ResetBounceP2();
        PlayerGetUlti = resetGetUlti;
    }
}
