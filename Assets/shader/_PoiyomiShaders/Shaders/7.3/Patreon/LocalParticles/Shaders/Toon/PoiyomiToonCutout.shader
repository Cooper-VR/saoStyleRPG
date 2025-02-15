Shader ".poiyomi/Patreon/Particle2/Cutout"
{
    Properties
    {
        [HideInInspector] shader_is_using_thry_editor ("", Float) = 0
        [HideInInspector] shader_master_label ("<color=#ff0000ff>❤</color> <color=#000000ff>Poiyomi Toon Shader V4.2</color> <color=#ff0000ff>❤</color>", Float) = 0
        [HideInInspector] shader_presets ("poiToonPresets", Float) = 0
        
        
        [HideInInspector] footer_youtube ("youtube footer button", Float) = 0
        [HideInInspector] footer_twitter ("twitter footer button", Float) = 0
        [HideInInspector] footer_patreon ("patreon footer button", Float) = 0
        [HideInInspector] footer_discord ("discord footer button", Float) = 0
        [HideInInspector] footer_github ("github footer button", Float) = 0
        
        // Warning that only shows up when ThryEditor hasn't loaded
        [Header(POIYOMI SHADER UI FAILED TO LOAD)]
        [Header(.    This is caused by scripts failing to compile. It can be fixed.)]
        [Header(.          The inspector will look broken and will not work properly until fixed.)]
        [Header(.    Please check your console for script errors.)]
        [Header(.          You can filter by errors in the console window.)]
        [Header(.          Often the topmost error points to the erroring script.)]
        [Space(30)][Header(Common Error Causes)]
        [Header(.    Installing multiple Poiyomi Shader packages)]
        [Header(.          Make sure to delete the Poiyomi shader folder before you update Poiyomi.)]
        [Header(.          If a package came with Poiyomi this is bad practice and can cause issues.)]
        [Header(.          Delete the package and import it without any Poiyomi components.)]
        [Header(.    Bad VRCSDK installation (e.g. Both VCC and Standalone))]
        [Header(.          Delete the VRCSDK Folder in Assets if you are using the VCC.)]
        [Header(.          Avoid using third party SDKs. They can cause incompatibility.)]
        [Header(.    Script Errors in other scripts)]
        [Header(.          Outdated tools or prefabs can cause this.)]
        [Header(.          Update things that are throwing errors or move them outside the project.)]
        [Space(30)][Header(Visit Our Discord to Ask For Help)]
        [Space(5)]_ShaderUIWarning0 (" → discord.gg/poiyomi ←    We can help you get it fixed!                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         --{condition_showS:(0==1)}", Int) = -0
        [Space(1400)][Header(POIYOMI SHADER UI FAILED TO LOAD)]
        _ShaderUIWarning1 ("Please scroll up for more information!                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     --{condition_showS:(0==1)}", Int) = -0
        
        [HideInInspector] m_mainOptions ("Main", Float) = 0
        _Color ("Color & Alpha", Color) = (1, 1, 1, 1)
        
        _Saturation ("Saturation", Range(-1, 1)) = 0
        _MainEmissionStrength ("Basic Emission", Range(0, 20)) = 0
        _MainTex ("Texture", 2D) = "white" { }
        [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, DistortedUV1, 4)] _MainTextureUV ("Tex UV#", Int) = 0
        [Normal]_BumpMap ("Normal Map", 2D) = "bump" { }
        [Vector2]_MainNormalPan ("Normal Pan", Vector) = (0, 0, 0, 0)
        _BumpScale ("Normal Intensity", Range(0, 10)) = 1
        _AlphaMask ("Alpha Mask", 2D) = "white" { }
        _Clip ("Alpha Cuttoff", Range(0, 1.001)) = 0.5
        [ToggleUI]_ForceOpaque ("Force Opaque", Float) = 1
        [Vector2]_GlobalPanSpeed ("Global Pan Speed", Vector) = (0, 0, 0, 0)
        [HideInInspector] m_start_DetailOptions ("Details", Float) = 0
        _DetailMask ("Detail Mask (R:Texture, G:Normal)", 2D) = "white" { }
        _DetailTex ("Detail Texture", 2D) = "gray" { }
        [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, DistortedUV1, 4)] _DetailTexUV ("Detail Tex UV#", Int) = 0
        _DetailTexIntensity ("Detail Tex Intensity", Range(0, 10)) = 1
        _DetailBrightness ("Detail Brightness:", Range(0, 2)) = 1
        [Vector2]_DetailTexturePan ("Detail Tex Pan", Vector) = (0, 0, 0, 0)
        _DetailTint ("Detail Tint", Color) = (1, 1, 1)
        [Normal]_DetailNormalMap ("Detail Normal", 2D) = "bump" { }
        [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, DistortedUV1, 4)] _DetailNormalUV ("Detail Normal UV#", Int) = 0
        _DetailNormalMapScale ("Detail Normal Intensity", Range(0, 10)) = 1
        [Vector2]_MainDetailNormalPan ("Detail Normal Pan", Vector) = (0, 0, 0, 0)
        [HideInInspector] m_end_DetailOptions ("Details", Float) = 0
        [HideInInspector] m_start_Fade ("Fade", Float) = 0
        _MainMinAlpha ("Minimum Alpha", Range(0, 1)) = 0
        _MainFadeTexture ("Fade Map", 2D) = "white" { }
        [Vector2]_MainDistanceFade ("Distance Fade X to Y", Vector) = (0, 0, 0, 0)
        [HideInInspector] m_end_Fade ("Fade", Float) = 0

        // Particles Start
        [HideInInspector] m_particleOptions ("Particles", Float) = 0
        [ToggleUI]_ParticleLit("Basic Lighting", Float) = 0
        [HDR]_ParticleColor ("Color & Alpha", Color) = (1, 1, 1, 1)
        _ParticleTexture ("Texture", 2D) = "white" { }
        [ToggleUI]_ParticleRandomRotation("Random Rotation", Float) = 0
        _ParticleRotation("Rotation", Range(0, 360)) = 0
        _ParticlePerCMSquared ("Particle/cm^2", Float) = 1
        _ParticleAlphaCutoff ("Alpha Cutoff", Range(0,1.001)) = 0
        _ParticleMinRenderDistance ("Min Render Distance",Float) = .2
        [Gradient]_ParticleStartColorGradient ("Color Range", 2D) = "white" { }
        [ToggleUI]_ColorOverLifetime("Color Over Lifetime?", Float) = 0
        _ParticleMask ("Particle Mask", 2D) = "white" { }
        [Enum(Spherical, 0, Linear, 1)] _ParticleMovementMode("Movement Mode", Int) = 0
        
        [HideInInspector] m_start_sphericalMotion ("Spherical Motion", Float) = 0
        _ColorOverLifeSpeed ("Color/Life Speed", Float) = 1
        _ParticleScaleMin ("Scale min", float) = 0.01
        _ParticleScaleMax ("Scale max", float) = 0.02
        _ParticleSphericalMinSpeed("Min Speed", Float) = -5
        _ParticleSphericalMaxSpeed("Max Speed", Float) = 5
        _ParticleSphericalMinRadius("Min Radius", Float) = 0
        _ParticleSphericalMaxRadius("Max Radius", Float) = 0.2
        [HideInInspector] m_end_sphericalMotion ("Spherical Movement", Float) = 0

        [HideInInspector] m_start_LinearMotion ("Linear Movement", Float) = 0
        _ParticleLinearEndOffsetMin("End Offset Min", Vector) = (0.05,0.05,0.05,0)
        _ParticleLinearEndOffsetMax("End Offset Max", Vector) = (-0.05,-0.05,-0.05,0)
        [ToggleUI]_ParticleFlipParticlesGoingInward("Flip Particles Going Inward", Float) = 0
        _ParticleLinearSpeedMin ("Min Speed", Float) = 0.1
        _ParticleLinearSpeedMax ("Max Speed", Float) = 10
        _ParticleLinearStartAlpha ("Start Alpha", Float) = 1
        _ParticleLinearEndAlpha ("End Alpha", Float) = 1
        _ParticleLinearStartSizeMin ("Start min Size", Float) = .02
        _ParticleLinearStartSizeMax ("Start max Size", Float) = .02
        _ParticleLinearEndSizeMin ("End min Size", Float) = 0
        _ParticleLinearEndsizeMax ("End max Size", Float) = 0
        _ParticleLinearNormalRange ("Normal Spawn Range", Range(-1,1)) = -1
        [HideInInspector] m_end_LinearMotion ("Linear Motion", Float) = 0

        [HideInInspector] m_start_ParticleFlipbook("Flipbook", Float) = 0
        [ToggleUI]_EnableParticleFlipbook("Enable Flipbook", Float) = 0
        _ParticleFlipbookTexArray ("Texture Array", 2DArray) = "" {}
        _ParticleFlipbookTotalFrames ("Total Frames", Int) = 1
        _ParticleFlipbookFPS ("FPS", Float) = 30.0
        [ToggleUI]_ParticleRandomTimeOffset("Random Starting Frame?", Float) = 0
        [HideInInspector] m_start_manualParticleFlipbookControl ("Manual Control", Float) = 0
        _ParticleFlipbookCurrentFrame ("Current Frame", Float) = -1
        [HideInInspector] m_end_manualParticleFlipbookControl ("Manual Control", Float) = 0
        [HideInInspector] m_end_ParticleFlipbook ("Flipbook", Float) = 0
        // Particles End

        [HideInInspector] m_metallicOptions ("Metallic", Float) = 0
        [Toggle(_METALLICGLOSSMAP)]_EnableMetallic ("Enable Metallics", Float) = 0
        _CubeMap ("Baked CubeMap", Cube) = "" { }
        [ToggleUI]_SampleWorld ("Force Baked Cubemap", Range(0, 1)) = 0
        _MetalReflectionTint ("Reflection Tint", Color) = (1, 1, 1)
        _MetallicMask ("Metallic Mask", 2D) = "white" { }
        _Metallic ("Metallic", Range(0, 1)) = 0
        _SmoothnessMask ("Smoothness Map", 2D) = "white" { }
        [ToggleUI]_InvertSmoothness ("Invert Smoothness Map", Range(0, 1)) = 0
        _Smoothness ("Smoothness", Range(0, 1)) = 0
        
        [HideInInspector] m_start_clearCoat ("Clear Coat", Float) = 0
        [Toggle(_COLORCOLOR_ON)]_EnableClearCoat ("Enable Clear Coat", Float) = 0
        [Enum(Vertex, 0, Pixel, 1)] _ClearCoatNormalToUse ("What Normal?", Int) = 0
        _ClearCoatCubeMap ("Baked CubeMap", Cube) = "" { }
        [ToggleUI]_ClearCoatSampleWorld ("Force Baked Cubemap", Range(0, 1)) = 0
        _ClearCoatTint ("Reflection Tint", Color) = (1, 1, 1)
        _ClearCoatMask ("Mask", 2D) = "white" { }
        _ClearCoat ("Clear Coat", Range(0, 1)) = 1
        _ClearCoatSmoothnessMask ("Smoothness Map", 2D) = "white" { }
        [ToggleUI]_ClearCoatInvertSmoothness ("Invert Smoothness Map", Range(0, 1)) = 0
        _ClearCoatSmoothness ("Smoothness", Range(0, 1)) = 0
        [HideInInspector] m_end_clearCoat ("Clear Coat", Float) = 0
        
        [HideInInspector] m_matcapOptions ("Matcap / Sphere Textures", Float) = 0
        [Toggle(_COLORADDSUBDIFF_ON)]_MatcapEnable ("Enable Matcap", Float) = 0
        _MatcapColor ("Color", Color) = (1, 1, 1, 1)
        [TextureNoSO]_Matcap ("Matcap", 2D) = "white" { }
        _MatcapBorder ("Border", Range(0, .5)) = 0.43
        _MatcapMask ("Mask", 2D) = "white" { }
        _MatcapEmissionStrength ("Emission Strength", Range(0,20)) = 0
        _MatcapIntensity ("Intensity", Range(0, 5)) = 1
        _MatcapLightMask ("Hide in Shadow", Range(0, 1)) = 0
        _MatcapReplace ("Replace With Matcap", Range(0, 1)) = 1
        _MatcapMultiply ("Multiply Matcap", Range(0, 1)) = 0
        _MatcapAdd ("Add Matcap", Range(0, 1)) = 0
        [HideInInspector] m_start_Matcap2 ("Matcap 2", Float) = 0
        [ToggleUI]_Matcap2Enable ("Enable Matcap 2", Float) = 0
        _Matcap2Color ("Color", Color) = (1, 1, 1, 1)
        [TextureNoSO]_Matcap2 ("Matcap", 2D) = "white" { }
        _Matcap2Border ("Border", Range(0, .5)) = 0.43
        _Matcap2Mask ("Mask", 2D) = "white" { }
        _Matcap2EmissionStrength ("Emission Strength", Range(0,20)) = 0
        _Matcap2Intensity ("Intensity", Range(0, 5)) = 1
        _Matcap2LightMask ("Hide in Shadow", Range(0, 1)) = 0
        _Matcap2Replace ("Replace With Matcap", Range(0, 1)) = 0
        _Matcap2Multiply ("Multiply Matcap", Range(0, 1)) = 0
        _Matcap2Add ("Add Matcap", Range(0, 1)) = 0
        [HideInInspector] m_end_Matcap2 ("Matcap 2", Float) = 0
        
        [HideInInspector] m_emissionOptions ("Emission / Glow", Float) = 0
        [Toggle(_EMISSION)]_EnableEmission ("Enable Emission", Float) = 0
        [ToggleUI]_EmissionReplace ("Replace Base Color", Float) = 0
        [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, DistortedUV1, 4)] _EmissionMapUV ("Emission UV#", Int) = 0
        [HDR]_EmissionColor ("Emission Color", Color) = (1, 1, 1, 1)
        _EmissionMap ("Emission Map", 2D) = "white" { }
        _EmissionMask ("Emission Mask", 2D) = "white" { }
        _EmissionPan ("Map(XY) | Mask(ZW) Pan", Vector) = (0, 0, 0, 0)
        _EmissionStrength ("Emission Strength", Range(0, 20)) = 0
        
        [HideInInspector] m_start_glowInDarkEmissionOptions ("Glow In The Dark Emission (Requires Lighting Enabled)", Float) = 0
        [ToggleUI]_EnableGITDEmission ("Enable Glow In The Dark", Float) = 0
        [Enum(World, 0, Mesh, 1)] _GITDEWorldOrMesh ("Lighting Type", Int) = 0
        _GITDEMinEmissionMultiplier ("Min Emission Multiplier", Range(0, 1)) = 1
        _GITDEMaxEmissionMultiplier ("Max Emission Multiplier", Range(0, 1)) = 0
        _GITDEMinLight ("Min Lighting", Range(0, 1)) = 0
        _GITDEMaxLight ("Max Lighting", Range(0, 1)) = 1
        [HideInInspector] m_end_glowInDarkEmissionOptions ("Glow In The Dark Emission (Requires Lighting Enabled)", Float) = 0
        
        [HideInInspector] m_start_blinkingEmissionOptions ("Blinking Emission", Float) = 0
        _EmissiveBlink_Min ("Emissive Blink Min", Float) = 1
        _EmissiveBlink_Max ("Emissive Blink Max", Float) = 1
        _EmissiveBlink_Velocity ("Emissive Blink Velocity", Float) = 4
        [HideInInspector] m_end_blinkingEmissionOptions ("Blinking Emission", Float) = 0
        
        [HideInInspector] m_start_scrollingEmissionOptions ("Scrolling Emission", Float) = 0
        [ToggleUI] _ScrollingEmission ("Enable Scrolling Emission", Float) = 0
        _EmissiveScroll_Direction ("Emissive Scroll Direction", Vector) = (0, -10, 0, 0)
        _EmissiveScroll_Width ("Emissive Scroll Width", Float) = 10
        _EmissiveScroll_Velocity ("Emissive Scroll Velocity", Float) = 10
        _EmissiveScroll_Interval ("Emissive Scroll Interval", Float) = 20
        [HideInInspector] m_end_scrollingEmissionOptions ("Scrolling Emission", Float) = 0
        
        [HideInInspector] m_fakeLightingOptions ("Light & Shadow", Float) = 0
        [Toggle(_NORMALMAP)]_EnableLighting ("Enable Lighting", Float) = 1
        [Enum(Natural, 0, Controlled, 1, Standardish, 2, Math, 3)] _LightingType ("Lighting Type", Int) = 1
        [Gradient]_ToonRamp ("Lighting Ramp", 2D) = "white" { }
        _LightingShadowMask ("Shadow Mask (R)", 2D) = "white" { }
        _ShadowStrength ("Shadow Strength", Range(0, 1)) = .2
        _ShadowOffset ("Shadow Offset", Range(-1, 1)) = 0
        _AOMap ("AO Map", 2D) = "white" { }
        [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, DistortedUV1, 4)] _LightingAOUV ("AO Map UV#", Int) = 0
        _AOStrength ("AO Strength", Range(0, 1)) = 1
        [HideInInspector] m_start_lightingAdvanced ("Advanced", Float) = 0
        _IndirectContribution ("Indirect Contribution", Range(0, 1)) = 0
        _AdditiveSoftness ("Additive Softness", Range(0, 0.5)) = 0.005
        _AdditiveOffset ("Additive Offset", Range(-0.5, 0.5)) = 0
        _AttenuationMultiplier ("Attenuation", Range(0, 1)) = 0
        [HideInInspector] m_end_lightingAdvanced ("Advanced", Float) = 0
        
        [HideInInspector] m_specularHighlightsOptions ("Specular Highlights", Float) = 0
        [Toggle(_SPECGLOSSMAP)]_EnableSpecular ("Enable Specular", Float) = 0
        [Enum(Realistic, 1, Toon, 2, Anisotropic, 3)] _SpecularType ("Specular Type", Int) = 1
        _SpecularTint ("Specular Tint", Color) = (1, 1, 1, 1)
        _SpecularMixAlbedoIntoTint ("Mix Material Color Into Tint", Range(0, 1)) = 0
        _SpecularSmoothness ("Smoothness", Range(0, 1)) = 1
        _SpecularMap ("Specular Map", 2D) = "white" { }
        [ToggleUI]_SpecularInvertSmoothness ("Invert Smoothness", Float) = 0
        _SpecularMask ("Specular Mask", 2D) = "white" { }
        [Enum(Alpha, 0, Grayscale, 1)] _SmoothnessFrom ("Smoothness From", Int) = 1
        [HideInInspector] m_start_SpecularToon ("Toon", Float) = 0
        [MultiSlider]_SpecularToonInnerOuter ("Inner/Outer Edge", Vector) = (0.25, 0.3, 0, 1)
        [HideInInspector] m_end_SpecularToon ("Toon", Float) = 0
        [HideInInspector] m_start_Anisotropic ("Anisotropic", Float) = 0
        [Enum(Tangent, 0, Bitangent, 1)] _SpecWhatTangent ("(Bi)Tangent?", Int) = 0
        _AnisoSpec1Alpha ("Spec1 Alpha", Range(0, 1)) = 1
        _AnisoSpec2Alpha ("Spec2 Alpha", Range(0, 1)) = 1
        //_Spec1Offset ("Spec1 Offset", Float) = 0
        //_Spec1JitterStrength ("Spec1 Jitter Strength", Float) = 1.0
        _Spec2Smoothness ("Spec2 Smoothness", Range(0, 1)) = 0
        //_Spec2Offset ("Spec2 Offset", Float) = 0
        //_Spec2JitterStrength ("Spec2 Jitter Strength", Float) = 1.0
        [ToggleUI]_AnisoUseTangentMap ("Use Directional Map?", Float) = 0
        _AnisoTangentMap ("Anisotropic Directional Map", 2D) = "bump" { }
        //_ShiftTexture ("Shift Texture", 2D) = "black" { }
        [HideInInspector] m_end_Anisotropic ("Anisotropic", Float) = 0
        
        [HideInInspector] m_ParallaxMap ("Parallax", Float) = 0
        [Toggle(_PARALLAXMAP)]_ParallaxMap ("Enable Parallax FX", Float) = 0
        [ToggleUI]_ParallaxHeightMapEnabled ("Enable Parallax Height", Float) = 0
        [ToggleUI]_ParallaxInternalMapEnabled ("Enable Parallax Internal", Float) = 0
        [HideInInspector] m_start_parallaxHeightmap ("Heightmap", Float) = 0
        _ParallaxHeightMap ("Height Map", 2D) = "black" { }
        _ParallaxHeightIterations ("Parallax Height Iterations", Range(1, 10)) = 1
        _ParallaxStrength ("Parallax Strength", Range(0, 1)) = 0
        _ParallaxBias ("Parallax Bias (0.42)", Float) = 0.42
        [HideInInspector] m_end_parallaxHeightmap ("Heightmap", Float) = 0
        [HideInInspector] m_start_parallaxInternal ("Internal", Float) = 0
        [Enum(Basic, 0, HeightMap, 1)] _ParallaxInternalHeightmapMode ("Parallax Mode", Int) = 0
        [ToggleUI]_ParallaxInternalHeightFromAlpha ("HeightFromAlpha", Float) = 0
        _ParallaxInternalMap ("Internal Map", 2D) = "black" { }
        _ParallaxInternalIterations ("Parallax Internal Iterations", Range(1, 50)) = 1
        _ParallaxInternalMinDepth ("Min Depth", Float) = 0
        _ParallaxInternalMaxDepth ("Max Depth", Float) = 1
        _ParallaxInternalMinFade ("Min Depth Brightness", Range(0, 5)) = 1
        _ParallaxInternalMaxFade ("Max Depth Brightness", Range(0, 5)) = 0
        _ParallaxInternalMinColor ("Min Depth Color", Color) = (1, 1, 1, 1)
        _ParallaxInternalMaxColor ("Max Depth Color", Color) = (1, 1, 1, 1)
        [Vector2]_ParallaxInternalPanSpeed ("Pan Speed", Vector) = (0, 0, 0, 0)
        [Vector2]_ParallaxInternalPanDepthSpeed ("Per Level Speed Multiplier", Vector) = (0, 0, 0, 0)
        [HideInInspector] m_end_parallaxInternal ("Internal", Float) = 0
        
        [HideInInspector] m_subsurfaceOptions ("Subsurface Scattering", Float) = 0
        [Toggle(_TERRAIN_NORMAL_MAP)]_EnableSSS ("Enable Subsurface Scattering", Float) = 0
        _SSSColor ("Subsurface Color", Color) = (1, 1, 1, 1)
        _SSSThicknessMap ("Thickness Map", 2D) = "black" { }
        _SSSThicknessMod ("Thickness mod", Range(-1, 1)) = 0
        _SSSStrength ("Attenuation", Range(0, 1)) = 0
        _SSSPower ("Light Spread", Range(1, 100)) = 1
        _SSSDistortion ("Light Distortion", Range(0, 1)) = 0
        
        [HideInInspector] m_rimLightOptions ("Rim Lighting", Float) = 0
        [Toggle(_GLOSSYREFLECTIONS_OFF)]_EnableRimLighting ("Enable Rim Lighting", Float) = 0
        [ToggleUI]_RimLightingInvert ("Invert Rim Lighting", Float) = 0
        _RimLightColor ("Rim Color", Color) = (1, 1, 1, 1)
        _RimWidth ("Rim Width", Range(0, 1)) = 0.8
        _RimSharpness ("Rim Sharpness", Range(0, 1)) = .25
        _RimStrength ("Rim Emission", Range(0, 20)) = 0
        _RimBrighten ("Rim Color Brighten", Range(0, 3)) = 0
        _RimLightColorBias ("Rim Color Bias", Range(0, 1)) = 0
        _RimTex ("Rim Texture", 2D) = "white" { }
        _RimMask ("Rim Mask", 2D) = "white" { }
        [Vector2]_RimTexPanSpeed ("Pan Speed", Vector) = (0, 0, 0, 0)
        
        [HideInInspector] m_start_reflectionRim ("Environmental Rim", Float) = 0
        [ToggleUI]_EnableEnvironmentalRim ("Enable Environmental Rim", Float) = 0
        _RimEnviroMask ("Mask", 2D) = "white" { }
        _RimEnviroBlur ("Blur", Range(0, 1)) = 0.7
        _RimEnviroWidth ("Rim Width", Range(0, 1)) = 0.45
        _RimEnviroSharpness ("Rim Sharpness", Range(0, 1)) = 0
        _RimEnviroMinBrightness ("Min Brightness Threshold", Range(0, 2)) = 0
        [HideInInspector] m_end_reflectionRim ("Environmental Rim", Float) = 0
        [HideInInspector] m_start_rimWidthNoise ("Width Noise", Float) = 0
        _RimWidthNoiseTexture ("Rim Width Noise", 2D) = "black" { }
        _RimWidthNoiseStrength ("Intensity", Range(0, 1)) = 0.1
        [Vector2]_RimWidthNoisePan ("Pan Speed", Vector) = (0, 0, 0, 0)
        [HideInInspector] m_end_rimWidthNoise ("Width Noise", Float) = 0
        [HideInInspector] m_start_ShadowMix ("Shadow Mix", Float) = 0
        _ShadowMix ("Shadow Mix In", Range(0, 1)) = 0
        _ShadowMixThreshold ("Shadow Mix Threshold", Range(0, 1)) = .5
        _ShadowMixWidthMod ("Shadow Mix Width Mod", Range(0, 10)) = .5
        [HideInInspector] m_end_ShadowMix ("Shadow Mix", Float) = 0
        
        [HideInInspector] m_flipBook ("Flipbook", Float) = 0
        [Toggle(_FADING_ON)]_EnableFlipbook ("Enable Flipbook", Float) = 0
        [Enum(UV0, 0, UV1, 1, UV2, 2, UV3, 3, DistortedUV1, 4)] _FlipbookUV ("Flipbook UV#", Int) = 0
        [TextureArray]_FlipbookTexArray ("Texture Array", 2DArray) = "" { }
        [Vector2]_FlipbookTexturePan ("Texture Panning", Vector) = (0, 0, 0, 0)
        [Vector2]_FlipbookMaskPan ("Mask Panning", Vector) = (0, 0, 0, 0)
        _FlipbookColor ("Color & alpha", Color) = (1, 1, 1, 1)
        _FlipbookTotalFrames ("Total Frames", Int) = 1
        _FlipbookFPS ("FPS", Float) = 30.0
        _FlipbookScaleOffset ("Scale | Offset", Vector) = (1, 1, 0, 0)
        [ToggleUI]_FlipbookTiled ("Tiled?", Float) = 0
        _FlipbookEmissionStrength ("Emission Strength", Range(0, 20)) = 0
        _FlipbookRotation ("Rotation", Range(0, 360)) = 0
        _FlipbookRotationSpeed ("Rotation Speed", Float) = 0
        _FlipbookReplace ("Replace", Range(0, 1)) = 1
        _FlipbookMultiply ("Multiply", Range(0, 1)) = 0
        _FlipbookAdd ("Add", Range(0, 1)) = 0
        //[ToggleUI]_FlipbookControlsAlpha ("Flipbook Controls Alpha", Float) = 0
        
        [HideInInspector] m_start_manualFlipbookControl ("Manual Control", Float) = 0
        _FlipbookCurrentFrame ("Current Frame", Float) = -1
        [HideInInspector] m_end_manualFlipbookControl ("Manual Control", Float) = 0
        
        [HideInInspector] m_dissolve ("Dissolve", Float) = 0
        [Toggle(_ALPHABLEND_ON)]_EnableDissolve ("Enable Dissolve", Float) = 0
        [Enum(Basic, 1, Point2Point, 2)] _DissolveType ("Dissolve Type", Int) = 1
        _DissolveEdgeWidth ("Edge Width", Range(0, .5)) = 0.025
        _DissolveEdgeHardness ("Edge Hardness", Range(0, 1)) = 0.5
        _DissolveEdgeColor ("Edge Color", Color) = (1, 1, 1, 1)
        [Gradient]_DissolveEdgeGradient ("Edge Gradient", 2D) = "white" { }
        _DissolveEdgeEmission ("Edge Emission", Range(0, 20)) = 0
        _DissolveTextureColor ("Dissolve to Color", Color) = (1, 1, 1, 1)
        _DissolveToTexture ("Dissolve to Texture", 2D) = "white" { }
        _DissolveToEmissionStrength ("Dissolve to Emission Strength", Range(0, 20)) = 0
        [Vector2]_DissolveToPanning ("Dissolve to Panning", Vector) = (0, 0, 0, 0)
        _DissolveNoiseTexture ("Dissolve Noise", 2D) = "white" { }
        [ToggleUI]_DissolveInvertNoise ("Invert Noise", Float) = 0
        _DissolveDetailNoise ("Dissolve Detail Noise", 2D) = "black" { }
        [ToggleUI]_DissolveInvertDetailNoise ("Invert Detail Noise", Float) = 0
        _DissolveDetailStrength ("Dissolve Detail Strength", Range(0, 1)) = 0.1
        _DissolvePan ("Noise (XY) | Detail (ZW) Pan", Vector) = (0, 0, 0, 0)
        _DissolveAlpha ("Dissolve Alpha", Range(0, 1)) = 0
        _DissolveMask ("Dissolve Mask", 2D) = "white" { }
        _ContinuousDissolve ("Continuous Dissolve Speed", Float) = 0
        [HideInInspector] m_start_pointToPoint ("point to point", Float) = 0
        [Enum(Local, 0, World, 1)] _DissolveP2PWorldLocal ("World/Local", Int) = 0
        _DissolveP2PEdgeLength ("Edge Length", Float) = 0.1
        [Vector3]_DissolveStartPoint ("Start Point", Vector) = (0, -1, 0, 0)
        [Vector3]_DissolveEndPoint ("End Point", Vector) = (0, 1, 0, 0)
        [HideInInspector] m_end_pointToPoint ("Point To Point", Float) = 0
        
        [HideInInspector] m_panosphereOptions ("Panosphere / Cubemaps", Float) = 0
        [Toggle(_DETAIL_MULX2)]_PanoToggle ("Enable Panosphere", Float) = 0
        _PanosphereColor ("Color", Color) = (1, 1, 1, 1)
        _PanosphereTexture ("Texture", 2D) = "white" { }
        _PanoMapTexture ("Mask", 2D) = "white" { }
        _PanoEmission ("Emission Strength", Range(0, 10)) = 0
        _PanoBlend ("Alpha", Range(0, 1)) = 0
        [Vector3]_PanospherePan ("Pan Speed", Vector) = (0, 0, 0, 0)
        [ToggleUI]_PanoCubeMapToggle ("Use Cubemap", Float) = 0
        [TextureNoSO]_PanoCubeMap ("CubeMap", Cube) = "" { }
        
        [HideInInspector] m_StencilPassOptions ("Stencil", Float) = 0
        [IntRange] _StencilRef ("Stencil Reference Value", Range(0, 255)) = 0
        //[IntRange] _StencilReadMaskRef ("Stencil ReadMask Value", Range(0, 255)) = 0
        //[IntRange] _StencilWriteMaskRef ("Stencil WriteMask Value", Range(0, 255)) = 0
        [Enum(UnityEngine.Rendering.StencilOp)] _StencilPassOp ("Stencil Pass Op", Float) = 0
        [Enum(UnityEngine.Rendering.StencilOp)] _StencilFailOp ("Stencil Fail Op", Float) = 0
        [Enum(UnityEngine.Rendering.StencilOp)] _StencilZFailOp ("Stencil ZFail Op", Float) = 0
        [Enum(UnityEngine.Rendering.CompareFunction)] _StencilCompareFunction ("Stencil Compare Function", Float) = 8
        
        [HideInInspector] m_start_ParticleStencilPassOptions ("Particle Stencil", Float) = 0
        [IntRange] _ParticleStencilRef ("Stencil Reference Value", Range(0, 255)) = 0
        [Enum(UnityEngine.Rendering.StencilOp)] _ParticleStencilPassOp ("Stencil Pass Op", Float) = 0
        [Enum(UnityEngine.Rendering.StencilOp)] _ParticleStencilFailOp ("Stencil Fail Op", Float) = 0
        [Enum(UnityEngine.Rendering.StencilOp)] _ParticleStencilZFailOp ("Stencil ZFail Op", Float) = 0
        [Enum(UnityEngine.Rendering.CompareFunction)] _ParticleStencilCompareFunction ("Stencil Compare Function", Float) = 8
        [HideInInspector] m_end_ParticleStencilPassOptions ("Particle Stencil", Float) = 0
        
        [HideInInspector] m_mirrorOptions ("Mirror", Float) = 0
        [Toggle(_REQUIRE_UV2)]_EnableMirrorOptions ("Enable Mirror Options", Float) = 0
        [Enum(ShowInBoth, 0, ShowOnlyInMirror, 1, DontShowInMirror, 2)] _Mirror ("Show in mirror", Int) = 0
        [ToggleUI]_EnableMirrorTexture ("Enable Mirror Texture", Float) = 0
        _MirrorTexture ("Mirror Tex", 2D) = "white" { }
        
        [HideInInspector] m_RandomOptions ("Random", Float) = 0
        [Toggle(_SUNDISK_NONE)]_EnableRandom ("Enable Random", Float) = 0
        [HideInInspector] m_start_Angle ("Angular Rendering", Float) = 0
        [Enum(Camera Face Model, 0, Model Face Camera, 1, Face Each Other, 2)] _AngleType ("Angle Type", Int) = 0
        [Enum(Model, 0, Vertex, 1)] _AngleCompareTo ("Model or Vert Positon", Int) = 0
        [Vector3]_AngleForwardDirection ("Forward Direction", Vector) = (0, 0, 1, 0)
        _CameraAngleMin ("Camera Angle Min", Range(0, 180)) = 45
        _CameraAngleMax ("Camera Angle Max", Range(0, 180)) = 90
        _ModelAngleMin ("Model Angle Min", Range(0, 180)) = 45
        _ModelAngleMax ("Model Angle Max", Range(0, 180)) = 90
        _AngleMinAlpha ("Min Alpha", Range(0, 1)) = 0
        [HideInInspector] m_end_Angle ("Angular Rendering", Float) = 0
        
        [HideInInspector] m_renderingOptions ("Rendering Options", Float) = 0
        [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
        [Enum(UnityEngine.Rendering.CompareFunction)] _ZTest ("ZTest", Float) = 4
        [Enum(UnityEngine.Rendering.BlendMode)] _SourceBlend ("Source Blend", Float) = 5
        [Enum(UnityEngine.Rendering.BlendMode)] _DestinationBlend ("Destination Blend", Float) = 10
        [Enum(Off, 0, On, 1)] _ZWrite ("ZWrite", Int) = 1
        _ZBias ("ZBias", Float) = 0.0
        
        [HideInInspector] m_debugOptions ("Debug", Float) = 0
        [Toggle(_COLOROVERLAY_ON)]_DebugDisplayDebug ("Display Debug Info", Float) = 0
        [Enum(Off, 0, Vertex Normal, 1, Pixel Normal, 2, Tangent, 3, Binormal, 4)] _DebugMeshData ("Mesh Data", Int) = 0
        [Enum(Off, 0, Attenuation, 1, Direct Lighting, 2, Indirect Lighting, 3, light Map, 4, Ramped Light Map, 5, Final Lighting, 6)] _DebugLightingData ("Lighting Data", Int) = 0
        [Enum(Off, 0, View Dir, 1, Tangent View Dir, 2, Forward Dir, 3, WorldPos, 4, View Dot Normal, 5)] _DebugCameraData ("Camera Data", Int) = 0
    }
    
    CustomEditor "Thry.ShaderEditor"
    SubShader
    {
        Tags { "DisableBatching" = "True" "RenderType" = "TransparentCutout" "Queue" = "AlphaTest" }
        
        Pass
        {
            Name "MainPass"
            Tags { "LightMode" = "ForwardBase" }
            Stencil
            {
                Ref [_StencilRef]
                Comp [_StencilCompareFunction]
                Pass [_StencilPassOp]
                Fail [_StencilFailOp]
                ZFail [_StencilZFailOp]
            }
            ZWrite [_ZWrite]
            Cull [_Cull]
            AlphaToMask On
            ZTest [_ZTest]
            Offset [_ZBias], [_ZBias]
            CGPROGRAM
            
            #pragma target 4.0
            #define FORWARD_BASE_PASS
            #pragma shader_feature _PARALLAXMAP
            // Mirror
            #pragma shader_feature _REQUIRE_UV2
            // Random
            #pragma shader_feature _SUNDISK_NONE
            // Dissolve
            #pragma shader_feature _ALPHABLEND_ON
            // Panosphere
            #pragma shader_feature _DETAIL_MULX2
            // Lighting
            #pragma shader_feature _NORMALMAP
            // Flipbook
            #pragma shader_feature _FADING_ON
            // Rim Lighting
            #pragma shader_feature _GLOSSYREFLECTIONS_OFF
            // Metal
            #pragma shader_feature _METALLICGLOSSMAP
            // Matcap
            #pragma shader_feature _COLORADDSUBDIFF_ON
            // Specular
            #pragma shader_feature _SPECGLOSSMAP
            // SubSurface
            #pragma shader_feature _TERRAIN_NORMAL_MAP
            // Debug
            #pragma shader_feature _COLOROVERLAY_ON
            #pragma shader_feature _EMISSION
            // Clear Coat
            #pragma shader_feature _COLORCOLOR_ON
            #pragma multi_compile_instancing
            #pragma multi_compile_fwdbase
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_fog
            #pragma vertex vert
            #pragma fragment frag
            #include "../Includes/PoiPass.cginc"
            ENDCG
            
        }
        
        Pass
        {
            Name "ForwardAddPass"
            Tags { "LightMode" = "ForwardAdd" }
            Stencil
            {
                Ref [_StencilRef]
                Comp [_StencilCompareFunction]
                Pass [_StencilPassOp]
                Fail [_StencilFailOp]
                ZFail [_StencilZFailOp]
            }
            ZWrite Off
            Blend One One
            Cull [_Cull]
            AlphaToMask On
            ZTest [_ZTest]
            Offset [_ZBias], [_ZBias]
            CGPROGRAM
            
            #pragma target 4.0
            #define FORWARD_ADD_PASS
            #define BINORMAL_PER_FRAGMENT
            #pragma shader_feature _PARALLAX_MAP
            // Mirror
            #pragma shader_feature _REQUIRE_UV2
            // Random
            #pragma shader_feature _SUNDISK_NONE
            // Dissolve
            #pragma shader_feature _ALPHABLEND_ON
            // Panosphere
            #pragma shader_feature _DETAIL_MULX2
            // Lighting
            #pragma shader_feature _NORMALMAP
            // Flipbook
            #pragma shader_feature _FADING_ON
            // Rim Lighting
            #pragma shader_feature _GLOSSYREFLECTIONS_OFF
            // Metal
            #pragma shader_feature _METALLICGLOSSMAP
            // Matcap
            #pragma shader_feature _COLORADDSUBDIFF_ON
            // Specular
            #pragma shader_feature _SPECGLOSSMAP
            // SubSurface
            #pragma shader_feature _TERRAIN_NORMAL_MAP
            // Debug
            #pragma shader_feature _COLOROVERLAY_ON
            #pragma multi_compile_instancing
            #pragma multi_compile_fwdadd_fullshadows
            #pragma vertex vert
            #pragma fragment frag
            #include "../Includes/PoiPass.cginc"
            ENDCG
            
        }
        
        Pass
        {
            Name "ParticlePass"
            Tags { "LightMode" = "ForwardBase" }
            
            Stencil
            {
                Ref [_ParticleStencilRef]
                Comp [_ParticleStencilCompareFunction]
                Pass [_ParticleStencilPassOp]
                Fail [_ParticleStencilFailOp]
                ZFail [_ParticleStencilZFailOp]
            }
            ZWrite On
            Cull Back
            AlphaToMask On

            CGPROGRAM
            #pragma target 4.0
            #pragma multi_compile_instancing
            #pragma multi_compile_fwdbase
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_fog
            #pragma vertex particleVert
            #pragma geometry particleGeom
            #pragma fragment particleFrag
            #include "../Includes/PoiParticlePass.cginc"
            ENDCG

        }

        Pass
        {
            Name "ShadowCasterPass"
            Tags { "LightMode" = "ShadowCaster" }
            Stencil
            {
                Ref [_StencilRef]
                Comp [_StencilCompareFunction]
                Pass [_StencilPassOp]
                Fail [_StencilFailOp]
                ZFail [_StencilZFailOp]
            }
            ZWrite [_ZWrite]
            Cull [_Cull]
            ZTest [_ZTest]
            Offset [_ZBias], [_ZBias]
            CGPROGRAM
            
            #pragma target 4.0
            #define CUTOUT
            #define POISHADOW
            // Mirror
            #pragma shader_feature _REQUIRE_UV2
            // Random
            #pragma shader_feature _SUNDISK_NONE
            // Dissolve
            #pragma shader_feature _ALPHABLEND_ON
            #pragma multi_compile_instancing
            #pragma vertex vertShadowCaster
            #pragma fragment fragShadowCaster
            #include "../Includes/PoiPassShadow.cginc"
            ENDCG
            
        }
    }
Fallback "Toon/Lit Cutout (Double)"
}
