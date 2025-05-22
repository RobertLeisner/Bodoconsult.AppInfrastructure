# What does the library

Bodoconsult.App is a library with basic functionality for multilayered monolithic applications like database based client server apps or windows services. 

Bodoconsult.App.GrpcBackgroundServices enhances the functionality of Bodoconsult.App for Windows services using GRPC.

It delivers the following main functionality:

1. App start infrastructure for Windows services apps using GRPC

# How to use the library

The source code contains NUnit test classes the following source code is extracted from. The samples below show the most helpful use cases for the library.

# App start infrastructure details

See page [app start infrastructure](../Bodoconsult.App/AppStartInfrastructure.md) for details.

# Using Protobuf definitions (protos) from Bodoconsult.App.GrpcBackgroundServices in GRPC clients

## Using the source code

You can integrate the protos to your project directly from repo. Simply copy the files to your project and used it same as your own protos.

## Using the Bodoconsult.App.GrpcBackgroundServices nuget package

See https://github.com/grpc/grpc/blob/master/src/csharp/BUILD-INTEGRATION.md#proto-only-nuget

Bodoconsult.App.GrpcBackgroundServices contains the following protos:

-	Protos\business_transaction_description.proto
-	Protos\common.proto
-	Protos\reply_data.proto
-	Protos\request_data.proto

Consuming the .proto file at client side:

-	Install the Bodoconsult.App.GrpcBackgroundServices Nuget package in your gRPC client project.
-	Add GeneratePathProperty="true" property to package reference in your gRPC client project file.
-	Add prefix $(PkgBodoconsult_App_GrpcBackgroundServices)\content\ while including the Protobuf reference. ('\content' is the directory name where all the content files are available by default.)

Note that, $(PkgBodoconsult_App_GrpcBackgroundServices) is by conventions where $(PkgGrpc_Shared) will be resolved to Grpc.Shared Nuget directory (the variable name starts with Pkg and is followed by the package name when . is replaced by _)

``` xml

	<ItemGroup>
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\business_transaction_description.proto" GrpcServices="Client" Link="Protos\business_transaction_description.proto" />
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\common.proto" Protos\common.proto" GrpcServices="Client"  Link="Protos\common.proto" />
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\reply_data.proto" GrpcServices="Client"  Link="Protos\reply_data.proto" />
		<Protobuf Include="$(PkgBodoconsult_App_GrpcBackgroundServices)\content\Protos\request_data.proto" GrpcServices="Client"  Link="Protos\request_data.proto" />
	</ItemGroup>

```

Source: https://sanket-naik.medium.com/sharing-grpc-proto-files-with-nuget-packages-made-easy-dd366a094b25


# About us

Bodoconsult <http://www.bodoconsult.de> is a Munich based software company from Germany.

Robert Leisner is senior software developer at Bodoconsult. See his profile on <http://www.bodoconsult.de/Curriculum_vitae_Robert_Leisner.pdf>.

