using System.Runtime.InteropServices;
using System.Reflection;

[assembly: AssemblyTitle(rabcrClient.Release.GameName)]
[assembly: AssemblyProduct(rabcrClient.Release.ShortGameName)]
[assembly: AssemblyConfiguration(rabcrClient.Release.ShortGameName+" "+rabcrClient.Release.VersionString+ ((rabcrClient.Release.VersionSpecialName!="") ? " ("+rabcrClient.Release.VersionSpecialName+")" :""))]
[assembly: AssemblyDescription(rabcrClient.Release.ShortGameName)]
[assembly: AssemblyCompany(rabcrClient.Release.Company)]
[assembly: AssemblyCopyright(rabcrClient.Release.Company+" © 2020")]
[assembly: Guid("327a83c3-ba24-4b6d-9c7c-3a86147cc667")]
[assembly: ComVisible(false)]

#pragma warning disable CS7035
[assembly: AssemblyFileVersion(rabcrClient.Release.VersionString)]
#pragma warning restore CS7035
[assembly: AssemblyVersion(rabcrClient.Release.VersionString)]
[assembly: AssemblyInformationalVersion(rabcrClient.Release.VersionString)]

[assembly: ComCompatibleVersion(
    rabcrClient.Release.VersionMajor,
    rabcrClient.Release.VersionMinor,
    rabcrClient.Release.VersionBuild,
    rabcrClient.Release.VersionRevision)
]