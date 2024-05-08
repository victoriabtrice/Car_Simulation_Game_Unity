using UnityEngine;

public class AddNumberOnN : MonoBehaviour
{
    // Variabel untuk menyimpan nilai yang ingin ditambahkan
    private int nilai = 100;

    // Update dipanggil setiap frame
    void Update()
    {
        // Cek apakah tombol N ditekan
        if (Input.GetKeyDown(KeyCode.N))
        {
            // Tambahkan 1 ke nilai
            nilai++;
            // Tampilkan nilai yang baru
            Debug.Log("Nilai sekarang: " + nilai);
        }
    }
}