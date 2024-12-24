# Verifica se o depcheck está instalado
if (-not (Get-Command depcheck -ErrorAction SilentlyContinue)) {
    Write-Host "Depcheck não está instalado. Instalando..."
    npm install -g depcheck
}

# Executa o depcheck e converte a saída para JSON
$dependencies = depcheck --json | ConvertFrom-Json

# Verifica se há dependências não utilizadas
if ($dependencies.dependencies.Count -eq 0) {
    Write-Host "Não há dependências não utilizadas para remover."
    exit
}

# Mostra as dependências não utilizadas
Write-Host "Dependências não utilizadas:"
Write-Host $dependencies.dependencies

# Confirmação para remoção das dependências
$confirm = Read-Host "Deseja remover essas dependências? (S/N)"
if ($confirm -ne "S" -and $confirm -ne "s") {
    "Operação cancelada."
    exit
}

# Remove as dependências não utilizadas
$dependencies.dependencies | ForEach-Object {

    Write-Host $_

    # Remove a dependência

    npm uninstall $_ -S -f
    Write-Host "Dependência removida: $_"
    }

Write-Host "Dependências removidas com sucesso."
