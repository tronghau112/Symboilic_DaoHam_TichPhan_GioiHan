; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "My Program"
#define MyAppVersion "1.5"
#define MyAppPublisher "My Company, Inc."
#define MyAppURL "http://www.example.com/"
#define MyAppExeName "DaoHamTichPhanGioiHan.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{CD82518E-3024-4992-B227-979C096413F4}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=E:\C#\AppSymboilic\App
OutputBaseFilename=AppSymboilic
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "E:\C#\AppSymboilic\Release\DaoHamTichPhanGioiHan.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\DaoHamTichPhanGioiHan.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\DaoHamTichPhanGioiHan.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\display.bat"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\DoAn.mla"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\input.mpl"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\input.tex"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\output.aux"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\output.log"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\output.pdf"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\output.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\C#\AppSymboilic\Release\solve.bat"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

