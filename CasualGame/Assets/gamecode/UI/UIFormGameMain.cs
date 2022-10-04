using UnityEngine;
using UnityEngine.UI;

public class UIFormGameMain : MonoBehaviour
{
    public InputField FieldNama, FieldHewan;
    public Text text;

    public void KonfirmasiForm()
    {
        bool _confirm = FieldNama.text == "" || FieldHewan.text == "";
        string _strReject = "Lengkapilah form terlebih dahulu.";
        string _strAccept = $"Namaku {FieldNama.text}, dan hewan favoritku adalah {FieldHewan.text}";

        text.text = _confirm ? _strReject : _strAccept;
    }
}
