Param(
  [string]$versionNumber
)
Write-Output "Pack all not tests projects"
$projects = Get-ChildItem -Path "src" -Recurse "Project.json"
foreach($project in $projects){
	if (!$project.FullName.EndsWith("Tests\project.json"))
	{
		Write-Output "dotnet pack -c Release --no-build $($project.FullName) --version-suffix $versionNumber"
		dotnet pack -c Release --no-build $($project.FullName) --version-suffix $versionNumber
	}
}