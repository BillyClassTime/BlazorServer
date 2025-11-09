# Ruta base del proyecto
$basePath = "$PSScriptRoot\BlazorServer"

# Paso 1: Renombrar archivo de configuración si es necesario
$appsettingsPath = Join-Path $basePath "appsettings.json"
$examplePath = Join-Path $basePath "appsetting_sExample.json"

Write-Host "🔍 Verificando archivo de configuración..."
if (-Not (Test-Path $appsettingsPath) -and (Test-Path $examplePath)) {
    Rename-Item -Path $examplePath -NewName "appsettings.json"
    Write-Host "✅ Archivo renombrado correctamente."
} else {
    Write-Host "ℹ️ appsettings.json ya existe o el archivo de ejemplo no está presente."
}

# Paso 2: Ejecutar BlazorServer en segundo plano
Write-Host "🚀 Iniciando BlazorServer..."
$blazorProc = Start-Process "dotnet" "run --project $basePath" -PassThru -WindowStyle Hidden


# Paso 3: Esperar a que el servidor esté disponible
Write-Host "⏳ Esperando a que el servidor esté disponible en http://localhost:5000..."
$maxWait = 20
$attempt = 0
while ($attempt -lt $maxWait) {
    try {
        $response = Invoke-WebRequest -Uri "http://localhost:5000" -UseBasicParsing -TimeoutSec 1
        Write-Host "✅ Servidor disponible en el intento $($attempt + 1)"
        break
    } catch {
        Write-Host "❌ Intento $($attempt + 1): servidor no disponible aún..."
        Start-Sleep -Seconds 1
        $attempt++
    }
}
if ($attempt -eq $maxWait) {
    Write-Host "❌ ERROR: El servidor no respondió en $maxWait segundos."
    exit 1
}

# Paso 4: Ejecutar pruebas de BlazorServer.Test
Write-Host "🧪 Ejecutando pruebas unitarias..."
dotnet test "$PSScriptRoot\BlazorServer.Tests"

# Paso 5: Ejecutar pruebas E2E
Write-Host "🧪 Ejecutando pruebas E2E..."
dotnet test "$PSScriptRoot\BlazorServer.E2E"

# Paso 6: Finalizar proceso de BlazorServer
Write-Host "🛑 Finalizando proceso de BlazorServer..."
if ($blazorProc -and !$blazorProc.HasExited) {
    try {
        $blazorProc.Kill()
        Write-Host "✅ Proceso BlazorServer (PID $($blazorProc.Id)) finalizado correctamente."
    } catch {
        Write-Host "❌ No se pudo finalizar el proceso BlazorServer: $_"
    }
} else {
    Write-Host "ℹ️ El proceso BlazorServer ya no está activo o no fue lanzado correctamente."
}

#Get-Process dotnet | Format-Table Id, ProcessName, StartTime, MainWindowTitle