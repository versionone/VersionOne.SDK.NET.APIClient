param(
    [alias("t")]
    [string]$tasks = ''
)

function DownloadSetup {
    $source = "https://raw.github.com/openAgile/psake-tools/master/setup.ps1"  
    Invoke-WebRequest -Uri $source -OutFile setup.ps1
}

try {
    DownloadSetup
    .\setup.ps1 $tasks
}
Catch {
    Write-Host $_.Exception.Message
    exit 1
}