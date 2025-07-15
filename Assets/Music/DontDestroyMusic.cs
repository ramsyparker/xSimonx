using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{
    private void Awake()
    {
        // Cegah duplikasi music jika sudah ada
        GameObject[] musicObjs = GameObject.FindGameObjectsWithTag("Music");
        if (musicObjs.Length > 1)
        {
            Destroy(this.gameObject); // Hapus duplikat
            return;
        }

        DontDestroyOnLoad(this.gameObject); // Tetap hidup antar scene
    }
}
