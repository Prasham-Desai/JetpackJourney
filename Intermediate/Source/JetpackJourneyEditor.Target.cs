using UnrealBuildTool;

public class JetpackJourneyEditorTarget : TargetRules
{
	public JetpackJourneyEditorTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Editor;
		ExtraModuleNames.Add("JetpackJourney");
	}
}
