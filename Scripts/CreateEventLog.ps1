if (!(Get-Eventlog -LogName "Application" -Source POC_Cloud)){
      New-Eventlog -LogName "Application" -Source POC_Cloud
 }