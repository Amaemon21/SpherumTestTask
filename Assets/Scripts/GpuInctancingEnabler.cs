using UnityEngine;

public class GpuInctancingEnabler : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}