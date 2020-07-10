param(
[string]$Principle = ' ers',
[string]$LogName = 'Application'
)

# Get SDDL:
$orgSDDL = gp ('HKLM:\SYSTEM\CurrentControlSet\Services\Eventlog\'+$LogName) CustomSD | select -exp CustomSD;

write-host 'Before:'
$orgSDDL;

# Create ACL
$acl = new-object System.Security.AccessControl.RegistrySecurity;
$acl.SetSecurityDescriptorSddlForm($orgSDDL);

# Create ACE
$ace = New-Object System.Security.AccessControl.RegistryAccessRule $Principle,3,'allow';

# Combine ACL
$acl.AddAccessRule($ace);
$newSDDL = $acl.SDDL;

write-host 'After:'
$newSDDL;

# Store SDDL:
sp ('HKLM:\SYSTEM\CurrentControlSet\Services\Eventlog\'+$LogName) CustomSD $newSDDL;

# Compose Key:
$LogPath = 'HKLM:\SYSTEM\CurrentControlSet\services\eventlog\'+$LogName;
if(Test-Path $LogPath)
{
    $acl = Get-Acl $LogPath
    $ace = New-Object System.Security.AccessControl.RegistryAccessRule $Principle,'WriteKey, ReadKey','allow'
    $acl.AddAccessRule($ace)
    #Set-Acl $LogPath $acl
}else{Write-Error "Cannot acesss log $LogName"}