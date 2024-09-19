using TMPro;
using UnityEngine;

public class UIResources : MonoBehaviour
{

    public TextMeshProUGUI goldText;    // Texto que exibe a quantidade de ouro
    public TextMeshProUGUI foodText;    // Texto que exibe a quantidade de comida
    public TextMeshProUGUI buildingMaterialText;    // Texto que exibe a quantidade de material de construção
    public TextMeshProUGUI oreText;     // Texto que exibe a quantidade de minério

    private void Awake() 
    {
        ResourceNode.OnResourceGained += UpdateTextInfo;
    }

    private void UpdateTextInfo(ResourcesTypes.Types type)
    {
        switch (type)
        {
            case ResourcesTypes.Types.gold:
            Debug.Log("+1 Gold");   // Exibe no console o que foi ganho //
            goldText.text = CurrencyManager.Instance.gold.ToString();
                break;
            case ResourcesTypes.Types.food:
                Debug.Log("+1 Food");   // Exibe no console o que foi ganho //
                // foodText.text = CurrencyManager.Instance.food.ToString();
                break;
            case ResourcesTypes.Types.buildingMaterial:
                Debug.Log("+1 Building Material");  // Exibe no console o que foi ganho //
                // buildingMaterialText.text = CurrencyManager.Instance.buildingMaterial.ToString();
                break;
            case ResourcesTypes.Types.ore:
                Debug.Log("+1 ore");    // Exibe no console o que foi ganho //
                oreText.text = CurrencyManager.Instance.ore.ToString();
                break;
            default:
                break;
        }
        
    }
}
