using UnrealBuildTool;

public class JetpackJourneyTarget : TargetRules
{
	public JetpackJourneyTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Game;
		ExtraModuleNames.Add("JetpackJourney");
	}
}
