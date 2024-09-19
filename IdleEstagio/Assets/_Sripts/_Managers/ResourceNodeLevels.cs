using UnityEngine;

public class ResourceNodeLevels : MonoBehaviour
{
    public static ResourceNodeLevels instance;  // acesso global à classe //
    public int currentForestryLevel;    // Nível atual do recurso
    public int currentQuaryLevel;   // Nível atual do recurso
    public int currentOreMineLevel; // Nível atual do recurso
    public int currentHuntCabinLevel;   // Nível atual do recurso
    
    private void Awake() 
    {
        instance = this;
    }
}
