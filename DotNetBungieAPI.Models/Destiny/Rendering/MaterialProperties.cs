namespace DotNetBungieAPI.Models.Destiny.Rendering;

public sealed record MaterialProperties
{
    [JsonPropertyName("detail_diffuse_transform")]
    public ReadOnlyCollection<float> DetailDiffuseTransform { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("detail_normal_transform")]
    public ReadOnlyCollection<float> DetailNormalTransform { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("spec_aa_xform")]
    public ReadOnlyCollection<float> SpecAaXform { get; init; } = ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_albedo_tint")]
    public ReadOnlyCollection<float> PrimaryAlbedoTint { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_emissive_tint_color")]
    public ReadOnlyCollection<float> PrimaryEmissiveTintColor { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_material_params")]
    public ReadOnlyCollection<float> PrimaryMaterialParams { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_material_advanced_params")]
    public ReadOnlyCollection<float> PrimaryMaterialAdvancedParams { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_roughness_remap")]
    public ReadOnlyCollection<float> PrimaryRoughnessRemap { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_worn_albedo_tint")]
    public ReadOnlyCollection<float> PrimaryWornAlbedoTint { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_wear_remap")]
    public ReadOnlyCollection<float> PrimaryWearRemap { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_worn_roughness_remap")]
    public ReadOnlyCollection<float> PrimaryWornRoughnessRemap { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_worn_material_parameters")]
    public ReadOnlyCollection<float> PrimaryWornMaterialParameters { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_albedo_tint")]
    public ReadOnlyCollection<float> SecondaryAlbedoTint { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_emissive_tint_color")]
    public ReadOnlyCollection<float> SecondaryEmissiveTintColor { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_material_params")]
    public ReadOnlyCollection<float> SecondaryMaterialParams { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_material_advanced_params")]
    public ReadOnlyCollection<float> SecondaryMaterialAdvancedParams { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_roughness_remap")]
    public ReadOnlyCollection<float> SecondaryRoughnessRemap { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_worn_albedo_tint")]
    public ReadOnlyCollection<float> SecondaryWornAlbedoTint { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_wear_remap")]
    public ReadOnlyCollection<float> SecondaryWearRemap { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_worn_roughness_remap")]
    public ReadOnlyCollection<float> SecondaryWornRoughnessRemap { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_worn_material_parameters")]
    public ReadOnlyCollection<float> SecondaryWornMaterialParameters { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("worn_albedo_tint")]
    public ReadOnlyCollection<float> WornAlbedoTint { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("wear_remap")]
    public ReadOnlyCollection<float> WearRemap { get; init; } = ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("worn_roughness_remap")]
    public ReadOnlyCollection<float> WornRoughnessRemap { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("worn_material_parameters")]
    public ReadOnlyCollection<float> WornMaterialParameters { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("emissive_tint_color_and_intensity_bias")]
    public ReadOnlyCollection<float> EmissiveTintColorAndIntensityBias { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_emissive_tint_color_and_intensity_bias")]
    public ReadOnlyCollection<float> PrimaryEmissiveTintColorAndIntensityBias { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_emissive_tint_color_and_intensity_bias")]
    public ReadOnlyCollection<float> SecondaryEmissiveTintColorAndIntensityBias { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("specular_properties")]
    public ReadOnlyCollection<float> SpecularProperties { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("lobe_pbr_params")]
    public ReadOnlyCollection<float> LobePbrParams { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("tint_pbr_params")]
    public ReadOnlyCollection<float> TintPbrParams { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("emissive_pbr_params")]
    public ReadOnlyCollection<float> EmissivePbrParams { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("subsurface_scattering_strength_and_emissive")]
    public ReadOnlyCollection<float> SubsurfaceScatteringStrengthAndEmissive { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("primary_subsurface_scattering_strength_and_emissive")]
    public ReadOnlyCollection<float> PrimarySubsurfaceScatteringStrengthAndEmissive { get; init; } =
        ReadOnlyCollection<float>.Empty;

    [JsonPropertyName("secondary_subsurface_scattering_strength_and_emissive")]
    public ReadOnlyCollection<float> SecondarySubsurfaceScatteringStrengthAndEmissive { get; init; } =
        ReadOnlyCollection<float>.Empty;
}
