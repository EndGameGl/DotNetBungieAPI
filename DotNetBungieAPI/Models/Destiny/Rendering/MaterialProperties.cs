namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record MaterialProperties
{
    [JsonPropertyName("detail_diffuse_transform")]
    public ReadOnlyCollection<float> DetailDiffuseTransform { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("detail_normal_transform")]
    public ReadOnlyCollection<float> DetailNormalTransform { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("spec_aa_xform")]
    public ReadOnlyCollection<float> SpecAaXform { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_albedo_tint")]
    public ReadOnlyCollection<float> PrimaryAlbedoTint { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_emissive_tint_color")]
    public ReadOnlyCollection<float> PrimaryEmissiveTintColor { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_material_params")]
    public ReadOnlyCollection<float> PrimaryMaterialParams { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_material_advanced_params")]
    public ReadOnlyCollection<float> PrimaryMaterialAdvancedParams { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_roughness_remap")]
    public ReadOnlyCollection<float> PrimaryRoughnessRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_worn_albedo_tint")]
    public ReadOnlyCollection<float> PrimaryWornAlbedoTint { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_wear_remap")]
    public ReadOnlyCollection<float> PrimaryWearRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_worn_roughness_remap")]
    public ReadOnlyCollection<float> PrimaryWornRoughnessRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_worn_material_parameters")]
    public ReadOnlyCollection<float> PrimaryWornMaterialParameters { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_albedo_tint")]
    public ReadOnlyCollection<float> SecondaryAlbedoTint { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_emissive_tint_color")]
    public ReadOnlyCollection<float> SecondaryEmissiveTintColor { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_material_params")]
    public ReadOnlyCollection<float> SecondaryMaterialParams { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_material_advanced_params")]
    public ReadOnlyCollection<float> SecondaryMaterialAdvancedParams { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_roughness_remap")]
    public ReadOnlyCollection<float> SecondaryRoughnessRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_worn_albedo_tint")]
    public ReadOnlyCollection<float> SecondaryWornAlbedoTint { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_wear_remap")]
    public ReadOnlyCollection<float> SecondaryWearRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_worn_roughness_remap")]
    public ReadOnlyCollection<float> SecondaryWornRoughnessRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_worn_material_parameters")]
    public ReadOnlyCollection<float> SecondaryWornMaterialParameters { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("worn_albedo_tint")]
    public ReadOnlyCollection<float> WornAlbedoTint { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("wear_remap")]
    public ReadOnlyCollection<float> WearRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("worn_roughness_remap")]
    public ReadOnlyCollection<float> WornRoughnessRemap { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("worn_material_parameters")]
    public ReadOnlyCollection<float> WornMaterialParameters { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("emissive_tint_color_and_intensity_bias")]
    public ReadOnlyCollection<float> EmissiveTintColorAndIntensityBias { get; init; } =
        ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_emissive_tint_color_and_intensity_bias")]
    public ReadOnlyCollection<float> PrimaryEmissiveTintColorAndIntensityBias { get; init; } =
        ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_emissive_tint_color_and_intensity_bias")]
    public ReadOnlyCollection<float> SecondaryEmissiveTintColorAndIntensityBias { get; init; } =
        ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("specular_properties")]
    public ReadOnlyCollection<float> SpecularProperties { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("lobe_pbr_params")]
    public ReadOnlyCollection<float> LobePbrParams { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("tint_pbr_params")]
    public ReadOnlyCollection<float> TintPbrParams { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("emissive_pbr_params")]
    public ReadOnlyCollection<float> EmissivePbrParams { get; init; } = ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("subsurface_scattering_strength_and_emissive")]
    public ReadOnlyCollection<float> SubsurfaceScatteringStrengthAndEmissive { get; init; } =
        ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("primary_subsurface_scattering_strength_and_emissive")]
    public ReadOnlyCollection<float> PrimarySubsurfaceScatteringStrengthAndEmissive { get; init; } =
        ReadOnlyCollections<float>.Empty;

    [JsonPropertyName("secondary_subsurface_scattering_strength_and_emissive")]
    public ReadOnlyCollection<float> SecondarySubsurfaceScatteringStrengthAndEmissive { get; init; } =
        ReadOnlyCollections<float>.Empty;
}