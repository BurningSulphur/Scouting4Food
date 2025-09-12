namespace Scouting4Food.scripts;


using UnityEngine;

public class MaterialObjectReplacer : MonoBehaviour
{
    [Tooltip("The GameObject that contains the material")]
    public GameObject targetObject;

    [Tooltip("Name of the shader to apply to materials")]
    public string shaderName = "W/Peak_Standard";
    
    
    [Tooltip("Name of the shader to apply to special materials")]
    public string specialShaderName = "Decal";
    
    [Tooltip("The Material that gets special treatment")]
    public Material SpecialMaterial;

    private void Start()
    {
        ReplaceObjectMaterial();
    }

    public void ReplaceObjectMaterial()
    {
        if (targetObject == null || string.IsNullOrEmpty(shaderName))
        {
            Debug.LogWarning("MaterialObjectReplacer: Target object or shader name not set.");
            return;
        }
        
        Shader newShader = Shader.Find(shaderName);
        if (newShader == null)
        {
            Debug.LogError($"MaterialObjectReplacer: Shader '{shaderName}' not found!");
            return;
        }
        
        Shader newSpecialShader = Shader.Find(specialShaderName);
        if (SpecialMaterial != null && newSpecialShader == null)
        {
            Debug.LogError($"MaterialObjectReplacer: Shader '{specialShaderName}' not found!");
            return;
        }

        Renderer[] renderers = targetObject.GetComponentsInChildren<Renderer>(true);

        foreach (var renderer in renderers)
        {
            Material[] updatedMats = new Material[renderer.sharedMaterials.Length];

            for (int i = 0; i < renderer.sharedMaterials.Length; i++)
            {
                Material originalMat = renderer.sharedMaterials[i];
                if (originalMat != null)
                {
                    Material updatedMat = new Material(originalMat);

                    if (SpecialMaterial != null && originalMat.name.Replace(" (Instance)", "") == SpecialMaterial.name)
                    {
                        updatedMat.shader = newSpecialShader;
                        Debug.Log($"Applied SPECIAL shader '{specialShaderName}' to material '{originalMat.name}'");
                    }
                    else
                    {
                        updatedMat.shader = newShader;
                    }

                    updatedMats[i] = updatedMat;
                }
            }
            renderer.materials = updatedMats; // replaces *all* materials
        }
    }
}