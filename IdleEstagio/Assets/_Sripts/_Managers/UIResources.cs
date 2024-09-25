using TMPro;
using UnityEngine;

public class UIResources : MonoBehaviour
{
    public static UIResources instance;

    public TextMeshProUGUI goldText;    // Texto que exibe a quantidade de ouro
    public TextMeshProUGUI foodText;    // Texto que exibe a quantidade de comida
    public TextMeshProUGUI buildingMaterialText;    // Texto que exibe a quantidade de material de construção
    public TextMeshProUGUI oreText;     // Texto que exibe a quantidade de minério

    private void Awake() 
    {
        instance = this;
    }

    public void UpdateTextInfo(ResourcesTypes.Types type)
    {
        switch (type)
        {
            case ResourcesTypes.Types.gold:
                goldText.text = CurrencyManager.Instance.gold.ToString("F2");
                break;
            case ResourcesTypes.Types.food:
                foodText.text = CurrencyManager.Instance.food.ToString("F2");
                break;
            case ResourcesTypes.Types.buildingMaterial:
                buildingMaterialText.text = CurrencyManager.Instance.buildingMaterial.ToString("F2");
                break;
            case ResourcesTypes.Types.ore:
                oreText.text = CurrencyManager.Instance.ore.ToString("F2");
                break;
            default:
                break;
        }
        
    }

    public void UpdateTextInfo()
    {
        goldText.text = CurrencyManager.Instance.gold.ToString("F2");
        foodText.text = CurrencyManager.Instance.food.ToString("F2");
        buildingMaterialText.text = CurrencyManager.Instance.buildingMaterial.ToString("F2");
        oreText.text = CurrencyManager.Instance.ore.ToString("F2");
    }
}
