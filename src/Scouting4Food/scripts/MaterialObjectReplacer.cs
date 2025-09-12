namespace Scouting4Food.scripts;


using UnityEngine;

public class MaterialObjectReplacer : MonoBehaviour
{
    [Tooltip("The GameObject that contains the material")]
    public GameObject targetObject;

    [Tooltip("Name of the shader to apply to materials")]
    public string shaderName = "W/Peak_Standard";

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

        Renderer[] renderers = targetObject.GetComponentsInChildren<Renderer>(true);

        foreach (var renderer in renderers)
        {
            Material[] updatedMats = new Material[renderer.sharedMaterials.Length];

            for (int i = 0; i < renderer.sharedMaterials.Length; i++)
            {
                if (renderer.sharedMaterials[i] != null)
                {
                    Material updatedMat = new Material(renderer.sharedMaterials[i]);
                    updatedMat.shader = newShader;
                    updatedMats[i] = updatedMat;
                }
            }

            renderer.materials = updatedMats; // replaces *all* materials
            
            /*
            if (renderer.sharedMaterial != null)
            {
                Material updatedMat = new Material(renderer.sharedMaterial);

                updatedMat.shader = newShader;

                renderer.material = updatedMat;
            }
            */
        }
    }
}