Param(
  [string]$versionNumber
)
Write-Output "Pack all projects"
$projects = Get-ChildItem -Path "src" -Recurse "Project.json"
Write-Output $projects
foreach($project in $projects){
	if (!$project.FullName.EndsWith("Tests"))
	{
		Write-Output "otnet pack -c Release --no-build $($project.FullName) --version-suffix $versionNumber"
		dotnet pack -c Release --no-build $($project.FullName) --version-suffix $versionNumber
	}
}