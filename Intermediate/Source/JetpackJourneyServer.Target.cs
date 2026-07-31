using UnrealBuildTool;

public class JetpackJourneyServerTarget : TargetRules
{
	public JetpackJourneyServerTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Server;
		ExtraModuleNames.Add("JetpackJourney");
	}
}
