namespace Scouting4Food.scripts;


using UnityEngine;

public class MaterialParticleReplacer : MonoBehaviour
{
    [Tooltip("The GameObject that contains the particle system or sum lol")]
    public GameObject targetObject;

    [Tooltip("Name of the shader to apply to particle materials")]
    public string shaderName = "SmokeParticleSimple";

    private void Start()
    {
        ReplaceParticleMaterial();
    }

    public void ReplaceParticleMaterial()
    {
        if (targetObject == null || string.IsNullOrEmpty(shaderName))
        {
            Debug.LogWarning("ERROR.");
            return;
        }

        Shader newShader = Shader.Find(shaderName);

        ParticleSystemRenderer[] renderers = targetObject.GetComponentsInChildren<ParticleSystemRenderer>();

        foreach (var psRenderer in renderers)
        {
            if (psRenderer.sharedMaterial != null)
            {
                Material updatedMat = new Material(psRenderer.sharedMaterial);

                updatedMat.shader = newShader;

                psRenderer.material = updatedMat;
            }
        }
    }
}