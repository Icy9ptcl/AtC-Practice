Write-Output "v1.0, by @Icy9ptcl."
Write-Output "Welcome to AtCoder contest env generator batch!"
Write-Output ""

$confirm = "n"

Do {
  Write-Output "Type the name of AtCoder contest. For example, type abc166 and hit enter if you want to set up folders for AtCoder Beginner Contest 166."
  $contestName = Read-Host
  Write-Output ""
  Write-Output "Contest name is: $contestName"
  $confirm = Read-Host -Prompt "Is that okay? (y/n)"
} Until ($confirm.ToUpper() = "Y")

Write-Output ""
Write-Output "Generating folders via atcoder-cli..."

# Start-Process "https://atcoder.jp/contests/"+$1
acc new $contestName

Write-Output "Opening Explorer..."
$loc = Get-Location
Start-Process "$loc/$contestName";

Write-Output "Opening VSCode..."
code "./$contestName";

Write-Output "Done! Choose a problem and open that folder with VSCode, and run 'Initialize' task to begin."

Write-Output "This is the list of problems:"
$problems = ( Get-ChildItem -Directory "./$contestName" )
Write-Output $problems.Name

Write-Output "Good Luck!"
Read-Host -Prompt "Press any key to exit..."