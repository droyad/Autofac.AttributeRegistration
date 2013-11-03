param([parameter(Mandatory=$true)] [string]$version)

$configs = (ls -r packages.config)
foreach($config in $configs)
{
	 [xml] $xml = (Get-Content $config)
	 foreach($package in $xml.packages.package)
	 {
		if($package.id -eq 'Autofac.AttributeRegistration')
		{
			$package.version = $version;
		}
	 }
	 $xml.Save($config);
}