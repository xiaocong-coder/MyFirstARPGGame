using System.Collections;
using System.Collections.Generic;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Tool;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Fog : VolumeComponent
{
    public BoolParameter effectEnable = new BoolParameter(false);
    
    // Depth Fog
    public ColorParameter depthFogColor = new ColorParameter(Color.black);
    public ClampedFloatParameter depthFogDensity = new ClampedFloatParameter(0.0f, 0.0f, 100.0f);

    // Hight Fog
    public ColorParameter hightFogColor = new ColorParameter(Color.black);
    public ClampedFloatParameter hightFogDensity = new ClampedFloatParameter(0.0f, 0.0f, 100.0f);
    public ClampedFloatParameter hightFogMaxHight = new ClampedFloatParameter(0.0f, 0.0f, 100.0f);
    public ClampedFloatParameter hightFogMinHight = new ClampedFloatParameter(0.0f, 0.0f, 100.0f);
    public TextureParameter hightFogTexture = new TextureParameter(null); 
    
    public bool IsActive => effectEnable.value;
}

public class FogFeature : ScriptableRendererFeature
{
    public FogPass postPass;
    
    public Shader shader;
    public Material material = null;
    
    public override void Create()
    {
        this.postPass = new FogPass();
        this.postPass.renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if(shader == null)
            return;

        if (material == null)
            this.material = CoreUtils.CreateEngineMaterial(shader);

        var cameraColorTarget = renderer.cameraColorTarget;
        
        postPass.Setup(cameraColorTarget, material);
        
        renderer.EnqueuePass(postPass);
    }
}

public class FogPass : ScriptableRenderPass
{
    private const string CommandBufferTag = "Fog Pass";

    public Material material;
    private Fog fogVolume;

    private RenderTargetIdentifier _ColorAttachment;
    private RenderTargetHandle _TemporaryColorTexture;
    
    private static readonly int DepthFogDensity = Shader.PropertyToID("_DepthFogDensity");
    private static readonly int DepthFogColor   = Shader.PropertyToID("_DepthFogColor");
    private static readonly int HightFogDensity = Shader.PropertyToID("_HightFogDensity");
    private static readonly int HightFogColor   = Shader.PropertyToID("_HightFogColor");
    private static readonly int MaxHight = Shader.PropertyToID("_MaxHight");
    private static readonly int MinHight = Shader.PropertyToID("_MinHight");
    private static readonly int HightFogTexture = Shader.PropertyToID("_HightFogTexture");

    public void Setup(RenderTargetIdentifier colorAttachment, Material material)
    {
        this._ColorAttachment = colorAttachment;
        this.material = material;

        var profile = FindGameObject.GetTransformInChildByName("PoseProcess", WorldGod.Singleton.CurrentWorld.transform).GetComponent<Volume>().profile;
        foreach (var comp in profile.components)
        {
            if (comp.GetType() == typeof(Fog))
            {
                this.fogVolume = comp as Fog;
                Debug.Log("Get Fog");
            }
        }
    }
    
    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        var stack = VolumeManager.instance.stack;

        var cmd = CommandBufferPool.Get(CommandBufferTag);

        var data = renderingData;
        Render(cmd, ref data);
        
        context.ExecuteCommandBuffer(cmd);

        CommandBufferPool.Release(cmd);
        cmd.ReleaseTemporaryRT(_TemporaryColorTexture.id);
    }
    
    private void Render(CommandBuffer cmd, ref RenderingData renderingData)
    {
        if(this.fogVolume == null)
            return;
        
        if (this.fogVolume.active)// && !renderingData.cameraData.isSceneViewCamera)
        {
            Matrix4x4 projMatrix = renderingData.cameraData.camera.projectionMatrix;
            Matrix4x4 viewMatrix = renderingData.cameraData.camera.worldToCameraMatrix;
            Matrix4x4 inverseVpMatrix = (projMatrix * viewMatrix).inverse;
            Shader.SetGlobalMatrix(Shader.PropertyToID("_InverseVPMatrix"), inverseVpMatrix);
            Shader.SetGlobalFloat(Shader.PropertyToID("_CameraFarPlane"), renderingData.cameraData.camera.farClipPlane);
            
            // Write Material
            material.SetFloat(DepthFogDensity,    this.fogVolume.depthFogDensity.value);
            material.SetColor(DepthFogColor,      this.fogVolume.depthFogColor.value);
            material.SetFloat(HightFogDensity,    this.fogVolume.hightFogDensity.value);
            material.SetColor(HightFogColor,      this.fogVolume.hightFogColor.value);
            material.SetFloat(MaxHight,           this.fogVolume.hightFogMaxHight.value);
            material.SetFloat(MinHight,           this.fogVolume.hightFogMinHight.value);
            material.SetTexture(HightFogTexture,  this.fogVolume.hightFogTexture.value);

            RenderTextureDescriptor opaqueDesc = renderingData.cameraData.cameraTargetDescriptor;
            opaqueDesc.depthBufferBits = 0;
            cmd.GetTemporaryRT(_TemporaryColorTexture.id, opaqueDesc);
            
            cmd.Blit(_ColorAttachment, _TemporaryColorTexture.Identifier(), this.material);
            cmd.Blit(_TemporaryColorTexture.Identifier(), _ColorAttachment);
        }
    }
}
