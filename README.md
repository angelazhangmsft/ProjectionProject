# ProjectionProject

This repro project demonstrates errors that arise when referencing a C#/WinRT interop project from a C# .NET 5 app.

This structure of this solution is: **ConsoleApp1** -> **SimpleMathProjection** -> **SimpleMathComponent**.

The projection interop project, **SimpleMathProjection**, references a C++/WinRT component called **SimpleMathComponent**. Currently, consuming the component through a project reference to the projection project raises a NETSDK1130 error. To remove this error from **ConsoleApp1**, consumers would have to reference the C#/WinRT NuGet package which shouldn't be required.

The NETSDK1130 error occurs because SimpleMathComponent.winmd is transitively passed through from the **SimpleMathComponent** project. It's possible to block this winmd from passing through to consumers by using this property in the projection project:

```xml
<ItemGroup>
    <!-- Referencing the C++/WinRT component to create a projection from -->
    <ProjectReference Include="..\SimpleMathComponent\SimpleMathComponent.vcxproj">
        <PrivateAssets>all</PrivateAssets>
    </ProjectReference>  
</ItemGroup>
 ```
 
 However, this also blocks the implementation dll (SimpleMathComponent.dll) from the consuming app **ConsoleApp1**, which causes a runtime error.
 
 Update: I've added **ConsoleAppPackageRef** to demonstrate referencing the interop project as a package reference. The interop project builds a package with a nuspec file - more details are in these docs: https://docs.microsoft.com/en-us/windows/uwp/csharp-winrt/net-projection-from-cppwinrt-component
