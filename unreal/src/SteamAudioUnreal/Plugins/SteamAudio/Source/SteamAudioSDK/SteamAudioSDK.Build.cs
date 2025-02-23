//
// Copyright (C) Valve Corporation. All rights reserved.
//

using UnrealBuildTool;

public class SteamAudioSDK : ModuleRules
{
    public SteamAudioSDK(ReadOnlyTargetRules Target) : base(Target)
    {
        // This module doesn't contain any source code, it just allows other modules to link to the Steam Audio SDK.
        Type = ModuleType.External;

        PublicIncludePaths.Add("$(PluginDir)/Source/SteamAudioSDK/include");

        if (Target.Platform == UnrealTargetPlatform.Win32)
        {
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/windows-x86/phonon.lib");

            PublicDelayLoadDLLs.Add("phonon.dll");

            RuntimeDependencies.Add("$(PluginDir)/Source/SteamAudioSDK/lib/windows-x86/phonon.dll");
        } 
        else if (Target.Platform == UnrealTargetPlatform.Win64)
        {
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/windows-x64/phonon.lib");

            PublicDelayLoadDLLs.Add("phonon.dll");
            PublicDelayLoadDLLs.Add("TrueAudioNext.dll");
            PublicDelayLoadDLLs.Add("GPUUtilities.dll");

            RuntimeDependencies.Add("$(PluginDir)/Source/SteamAudioSDK/lib/windows-x64/phonon.dll");
            RuntimeDependencies.Add("$(PluginDir)/Source/SteamAudioSDK/lib/windows-x64/TrueAudioNext.dll");
            RuntimeDependencies.Add("$(PluginDir)/Source/SteamAudioSDK/lib/windows-x64/GPUUtilities.dll");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/linux-x64/libphonon.so");

            PublicDelayLoadDLLs.Add("$(PluginDir)/Source/SteamAudioSDK/lib/linux-x64/libphonon.so");

            RuntimeDependencies.Add("$(PluginDir)/Source/SteamAudioSDK/lib/linux-x64/libphonon.so");
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/osx/libphonon.dylib");

            PublicDelayLoadDLLs.Add("$(PluginDir)/Source/SteamAudioSDK/lib/osx/libphonon.dylib");

            RuntimeDependencies.Add("$(PluginDir)/Source/SteamAudioSDK/lib/osx/libphonon.dylib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Android)
        {
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/android/armeabi-v7a/libphonon.so");
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/android/arm64-v8a/libphonon.so");
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/android/x86/libphonon.so");
            PublicAdditionalLibraries.Add("$(PluginDir)/Source/SteamAudioSDK/lib/android/x86_64/libphonon.so");

            string APLName = "SteamAudioSDK_APL.xml";
            string APLPathRelativeToEngine = Utils.MakePathRelativeTo(System.IO.Path.Combine(ModuleDirectory, APLName), Target.RelativeEnginePath);
            AdditionalPropertiesForReceipt.Add("AndroidPlugin", APLPathRelativeToEngine);
        }
    }
}
