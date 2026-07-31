using UnrealBuildTool;

public class JetpackJourneyClientTarget : TargetRules
{
	public JetpackJourneyClientTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Client;
		ExtraModuleNames.Add("JetpackJourney");
	}
}
