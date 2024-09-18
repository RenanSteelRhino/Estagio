using UnityEngine;

public class ResourceNodeLevels : MonoBehaviour
{
    public static ResourceNodeLevels instance;
    public int currentForestryLevel;
    public int currentQuaryLevel;
    public int currentOreMineLevel;
    public int currentHuntCabinLevel;
    
    private void Awake() 
    {
        instance = this;
    }
}
