#define PackageName      "NECN Hydro Succession"
#define PackageNameLong  "NECN Hydro Succession Extension"
#define Version          "5.0"
#define ReleaseType      "official"
#define ReleaseNumber    "5"

#define CoreVersion      "6.0"
#define CoreReleaseAbbr  ""

#include "package (Setup section) v6.0.iss"
#define ExtDir "C:\Program Files\LANDIS-II\v6\bin\extensions"
#define AppDir "C:\Program Files\LANDIS-II\v6"

[Files]
; Auxiliary libs
Source: ..\src\bin\Debug\Landis.Library.AgeOnlyCohorts.dll; DestDir: {#ExtDir}; Flags: replacesameversion
Source: ..\src\bin\Debug\Landis.Library.Cohorts.dll; DestDir: {#ExtDir}; Flags: replacesameversion
Source: ..\src\bin\Debug\Landis.Library.LeafBiomassCohorts.dll; DestDir: {#ExtDir}; Flags: replacesameversion
Source: ..\src\bin\Debug\Landis.Library.Succession.dll; DestDir: {#ExtDir}; Flags: replacesameversion
Source: ..\src\bin\Debug\Landis.Library.Metadata.dll; DestDir: {#ExtDir}; Flags:replacesameversion
Source: ..\src\bin\Debug\Landis.Library.Climate.dll; DestDir: {#ExtDir}; Flags: replacesameversion
Source: ..\src\bin\Debug\Landis.Library.BiomassCohorts-v2.dll; DestDir: {#ExtDir}; Flags: uninsneveruninstall replacesameversion
Source: ..\src\bin\Debug\Landis.Library.Biomass-v1.dll; DestDir: {#ExtDir}; Flags: uninsneveruninstall replacesameversion

; Succession
Source: ..\src\bin\Debug\Landis.Extension.Succession.NECN_Hydro.dll; DestDir: {#ExtDir}; Flags: replacesameversion

; Supporting documents
; Source: docs\LANDIS-II Century Succession v4.1 User Guide.pdf; DestDir: {#AppDir}\docs
Source: docs\LANDIS-II Climate Library v1.0 User Guide.pdf; DestDir: {#AppDir}\docs
; Source: docs\Century-calibrate-log-metadata.csv; DestDir: {#AppDir}\docs
; Source: docs\Century-prob-establish-log-metadata.csv; DestDir: {#AppDir}\docs
Source: examples\*.bat; DestDir: {#AppDir}\examples\century-succession
Source: examples\*.txt; DestDir: {#AppDir}\examples\century-succession
Source: examples\*.csv; DestDir: {#AppDir}\examples\century-succession
Source: examples\single_cell_3.img; DestDir: {#AppDir}\examples\century-succession
Source: examples\ecoregions.gis; DestDir: {#AppDir}\examples\century-succession
Source: examples\initial-communities.gis; DestDir: {#AppDir}\examples\century-succession

#define NECNHSucc "NECN Succession Hydro 5.0.txt"
Source: {#NECNHSucc}; DestDir: {#LandisPlugInDir}

[Run]
;; Run plug-in admin tool to add an entry for the plug-in
#define PlugInAdminTool  CoreBinDir + "\Landis.PlugIns.Admin.exe"

Filename: {#PlugInAdminTool}; Parameters: "remove ""NECN-H Succession"" "; WorkingDir: {#LandisPlugInDir}
Filename: {#PlugInAdminTool}; Parameters: "add ""{#NECNHSucc}"" "; WorkingDir: {#LandisPlugInDir}

[UninstallRun]

[Code]
#include "package (Code section) v3.iss"

//-----------------------------------------------------------------------------

function CurrentVersion_PostUninstall(currentVersion: TInstalledVersion): Integer;
begin
    Result := 0;
end;

//-----------------------------------------------------------------------------

function InitializeSetup_FirstPhase(): Boolean;
begin
  CurrVers_PostUninstall := @CurrentVersion_PostUninstall
  Result := True
end;