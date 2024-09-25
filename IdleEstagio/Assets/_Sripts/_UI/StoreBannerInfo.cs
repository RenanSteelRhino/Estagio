using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreBannerInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Image icon;

    public TextMeshProUGUI ReturnDescription()
    {
        return description;
    }

    public TextMeshProUGUI ReturnButtonText()
    {
        return valueText;
    }
}
