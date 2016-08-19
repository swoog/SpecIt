Param(
  [string]$versionNumber
)
Write-Output "Change version of all projects"
$projects = Get-ChildItem -Path "src" -Recurse "Project.json"
foreach($project in $projects){
	Write-Output "Change version of $($project.FullName)"
	(Get-Content $($project.FullName)).replace('99.99.99.99', $versionNumber) | Set-Content $($project.FullName)
}