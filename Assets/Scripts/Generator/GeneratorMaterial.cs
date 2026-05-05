using UnityEngine;

public class GeneratorMaterial : MonoBehaviour
{
    [SerializeField] private Renderer rend;

    private Material[] mats;
    private Generator generator;

    private void OnEnable()
    {
        generator = GetComponent<Generator>();

        generator.OnTurnedOn += Generator_OnTurnedOn;
        generator.OnTurnedOff += Generator_OnTurnedOff;
        generator.OnBroken += Generator_OnBroken;
    }

    private void Generator_OnBroken()
    {
        SetMaterialColor(Color.red * 20f);
    }

    private void Awake()
    {
        mats = rend.materials;
    }

    private void Generator_OnTurnedOff()
    {
        SetMaterialColor(Color.red * 20f);
    }

    private void Generator_OnTurnedOn()
    {
        SetMaterialColor(new Color(45, 159, 240) * 0.2f);
    }

    public void SetMaterialColor(Color color) 
    {
        mats[1].SetColor("_EmissionColor",color);
    }
}
