Write-Output "Backing up project..."
#Remove-Item -Recurse "./.old"
New-Item -Name ".old" -ItemType "directory"
(Get-ChildItem ./ -Exclude ".old" ) | Copy-Item -Destination "./.old" -Recurse

$contestName = (get-item ".").parent.Name
$probName = (get-item ".").Name
$projName = $contestName + '_' + $probname

Write-Output "Creating new console project..."
Write-Output "The project name will be $projName"
dotnet new console --name $projName -o "./" --force

Write-Output "Moving data/Program.cs ..."

Write-Output "Configurating project name..."
$content = ((Get-Content -Path "./data/Program.cs" -Raw) -replace "<Project_Name>", $projName)
Set-Content -Path "./Program.cs" -Value $content

Remove-Item "./data" -Recurse
