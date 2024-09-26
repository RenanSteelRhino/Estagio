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

    public void UpdateTextInfo(NodeSpecificType type)
    {
        switch (type)
        {
            case NodeSpecificType.gold:
                goldText.text = CurrencyManager.Instance.gold.ToString("F2");
                break;
            case NodeSpecificType.meat:
                foodText.text = CurrencyManager.Instance.food.ToString("F2");
                break;
            case NodeSpecificType.wood:
                buildingMaterialText.text = CurrencyManager.Instance.buildingMaterial.ToString("F2");
                break;
            case NodeSpecificType.iron:
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
