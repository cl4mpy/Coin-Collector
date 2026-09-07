using UnityEngine;

public class PenerimaEvent : MonoBehaviour
{
    private void OnEnable()
    {
        PemancarEvent.SaatTombolDiTekan += Respon;
    }

    private void OnDisable()
    {
        PemancarEvent.SaatTombolDiTekan -= Respon;
    }

    void Respon()
    {
        Debug.Log("Tombol di tekan");
    }


}