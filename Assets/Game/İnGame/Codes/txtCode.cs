using UnityEngine;
using TMPro; // TextMeshPro kullanmak için bu şart!

public class TxtCode : MonoBehaviour
{
    // 1. EKSİK: Kodun hangi TextMeshPro objesine yazı yazacağını Unity'ye söylememiz gerekiyor.
    [SerializeField] private TextMeshProUGUI toplanancop;
    [SerializeField] private TextMeshProUGUI toplanantohum;  

    [SerializeField] private TextMeshProUGUI fidan; 

    void Update()
    {
        SkoruGuncelle();
    }

    void SkoruGuncelle()
    {
        // 2. DÜZELTME: Artık skorYazisi yukarıda tanımlandığı için hata vermeden çalışacaktır.
        toplanancop.text = "Trash: " + FollowTrash.toplanan_cop.ToString();
        toplanantohum.text = "\nSeed: " + FollowSeed.toplanan_tohum.ToString();
        fidan.text = "\n\nSapling: " + SeedMaker.Fidan.ToString();
    }
}