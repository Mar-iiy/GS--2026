using TMPro;
using UnityEngine;
public class showPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pontosText;
    public static int pontos;

    [SerializeField] private TextMeshProUGUI batidasText;
    public static int batidas;
    void Start()
    {
        pontos = 0;
        batidas = 0;
    }
    void Update()
    {
        pontosText.text = pontos.ToString();
        batidasText.text = batidas.ToString();
    }
}
