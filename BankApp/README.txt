
https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli
https://learn.microsoft.com/en-us/ef/core/cli/powershell?source=recommendations
https://learn.microsoft.com/en-us/ef/core/cli/powershell
https://learn.microsoft.com/en-us/ef/core/cli/dotnet
https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?source=recommendations&tabs=dotnet-core-cli
https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
https://learn.microsoft.com/en-us/ef/core/extensions/
https://learn.microsoft.com/en-us/ef/core/testing/testing-without-the-database
https://learn.microsoft.com/en-us/ef/core/managing-schemas/ensure-created
	https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/existing-database?source=recommendations

https://code-maze.com/net-core-web-api-ef-core-code-first/
https://code-maze.com/aspnetcore-distributed-caching/
https://code-maze.com/aspnetcore-distributed-caching/
https://www.c-sharpcorner.com/article/implementation-of-the-redis-cache-in-the-net-core-api/

https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly
https://inthetechpit.com/2022/05/20/retry-and-circuit-breaker-policy-example-net-6-and-polly/
https://nodogmablog.bryanhogan.net/2022/02/polly-with-net-6-part-1-dependency-injection-of-policy-to-controller/
https://code-maze.com/creating-resilient-microservices-in-net-with-polly/

https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/monitor-app-health

REDIS
https://learn.microsoft.com/en-us/rest/api/redis/redis/create?tabs=HTTP
https://learn.microsoft.com/en-us/rest/api/redis/redis/list-keys?tabs=HTTP
https://stackexchange.github.io/StackExchange.Redis/Configuration.html
https://www.thecodebuzz.com/connection-resiliency-redis-cache-stackexchange-redi-best-practices/

ELASTIC
https://www.elastic.co/guide/en/elasticsearch/reference/current/docker.html

https://github.com/PacktPublishing/ASP.NET-Core-and-Vue.js
https://github.com/PacktPublishing/ASP.NET-Core-and-Vue.js/blob/master/Chapter13/Travel/src/presentation/Travel.WebApi/Startup.cs
https://github.com/PacktPublishing/ASP.NET-Core-and-Vue.js/blob/master/Chapter13/Travel/src/presentation/Travel.WebApi/Travel.WebApi.csproj

https://vuejs.org/guide/essentials/class-and-style.html
https://vuex.vuejs.org/api/
https://router.vuejs.org/guide/migration/#removal-of-append-prop-in-router-link
https://router.vuejs.org/guide/essentials/nested-routes.html#nested-named-routes

https://day.js.org/
https://day.js.org/docs/en/display/format
https://www.npmjs.com/package/dayjs


dotnet tool install --global dotnet-ef

dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:Chinook "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook"
dotnet ef dbcontext scaffold Name=ConnectionStrings:Chinook Microsoft.EntityFrameworkCore.SqlServer

drop-database -startupProject BankApp -project BankApp.Data -Context BankApp.Data.Contexts.BankContext
remove-migration -startupProject BankApp -project BankApp.Data -Context BankApp.Data.Contexts.BankContext
add-migration Initial -startupProject BankApp -project BankApp.Data
update-database -startupProject BankApp -project BankApp.Data

vue create vue-app
manual
router
vuex
unit-testing
3.x
history mode
 $ cd vue-app
 $ npm run serve
npm i vuetify@next @mdi/font

vue create client-app
vue add bootstrap
npm i bootstrap
npm i font-awesome
npm i axios
vue i moment
vue i dayjs
npm i @vuelidate/core @vuelidate/validators
 $ cd client-app
 $ npm run serve
npm i vuetify@next @mdi/font


BankApp

Installing:

Microsoft.AspNetCore.SpaServices.Extensions.6.0.0
Microsoft.Extensions.DependencyInjection.6.0.0
Microsoft.Extensions.DependencyInjection.Abstractions.6.0.0
Microsoft.Extensions.FileProviders.Abstractions.6.0.0
Microsoft.Extensions.FileProviders.Physical.6.0.0
Microsoft.Extensions.FileSystemGlobbing.6.0.0
Microsoft.Extensions.Logging.6.0.0
Microsoft.Extensions.Logging.Abstractions.6.0.0
Microsoft.Extensions.Options.6.0.0
Microsoft.Extensions.Primitives.6.0.0
System.Diagnostics.DiagnosticSource.6.0.0
System.Runtime.CompilerServices.Unsafe.6.0.0
VueCliMiddleware.6.0.0

BankApp

Installing:

Microsoft.EntityFrameworkCore.6.0.0
Microsoft.EntityFrameworkCore.Abstractions.6.0.0
Microsoft.EntityFrameworkCore.Analyzers.6.0.0
Microsoft.Extensions.Caching.Abstractions.6.0.0
Microsoft.Extensions.Caching.Memory.6.0.0
System.Collections.Immutable.6.0.0

Infrastructure\BankApp.Data

Installing:

Microsoft.EntityFrameworkCore.6.0.0
Microsoft.EntityFrameworkCore.Abstractions.6.0.0
Microsoft.EntityFrameworkCore.Analyzers.6.0.0
Microsoft.Extensions.Caching.Abstractions.6.0.0
Microsoft.Extensions.Caching.Memory.6.0.0
Microsoft.Extensions.DependencyInjection.6.0.0
Microsoft.Extensions.DependencyInjection.Abstractions.6.0.0
Microsoft.Extensions.Logging.6.0.0
Microsoft.Extensions.Logging.Abstractions.6.0.0
Microsoft.Extensions.Options.6.0.0
Microsoft.Extensions.Primitives.6.0.0
System.Collections.Immutable.6.0.0
System.Diagnostics.DiagnosticSource.6.0.0
System.Runtime.CompilerServices.Unsafe.6.0.0

BankApp

Installing:

Microsoft.EntityFrameworkCore.Relational.6.0.0
Microsoft.Extensions.Configuration.Abstractions.6.0.0

Infrastructure\BankApp.Data

Installing:

Microsoft.EntityFrameworkCore.Relational.6.0.0
Microsoft.Extensions.Configuration.Abstractions.6.0.0

BankApp

Installing:

Humanizer.Core.2.8.26
Microsoft.EntityFrameworkCore.Design.6.0.0

Infrastructure\BankApp.Data

Installing:

Humanizer.Core.2.8.26
Microsoft.EntityFrameworkCore.Design.6.0.0

BankApp

Installing:

Microsoft.CSharp.4.5.0
Microsoft.Data.SqlClient.2.1.4
Microsoft.Data.SqlClient.SNI.runtime.2.1.1
Microsoft.EntityFrameworkCore.SqlServer.6.0.0
Microsoft.Identity.Client.4.21.1
Microsoft.IdentityModel.JsonWebTokens.6.8.0
Microsoft.IdentityModel.Logging.6.8.0
Microsoft.IdentityModel.Protocols.6.8.0
Microsoft.IdentityModel.Protocols.OpenIdConnect.6.8.0
Microsoft.IdentityModel.Tokens.6.8.0
Microsoft.NETCore.Platforms.3.1.0
Microsoft.Win32.Registry.4.7.0
Microsoft.Win32.SystemEvents.4.7.0
System.Configuration.ConfigurationManager.4.7.0
System.Drawing.Common.4.7.0
System.IdentityModel.Tokens.Jwt.6.8.0
System.Runtime.Caching.4.7.0
System.Security.AccessControl.4.7.0
System.Security.Cryptography.Cng.4.5.0
System.Security.Cryptography.ProtectedData.4.7.0
System.Security.Permissions.4.7.0
System.Security.Principal.Windows.4.7.0
System.Text.Encoding.CodePages.4.7.0
System.Windows.Extensions.4.7.0

Infrastructure\BankApp.Data

Installing:

Microsoft.CSharp.4.5.0
Microsoft.Data.SqlClient.2.1.4
Microsoft.Data.SqlClient.SNI.runtime.2.1.1
Microsoft.EntityFrameworkCore.SqlServer.6.0.0
Microsoft.Identity.Client.4.21.1
Microsoft.IdentityModel.JsonWebTokens.6.8.0
Microsoft.IdentityModel.Logging.6.8.0
Microsoft.IdentityModel.Protocols.6.8.0
Microsoft.IdentityModel.Protocols.OpenIdConnect.6.8.0
Microsoft.IdentityModel.Tokens.6.8.0
Microsoft.NETCore.Platforms.3.1.0
Microsoft.Win32.Registry.4.7.0
Microsoft.Win32.SystemEvents.4.7.0
System.Configuration.ConfigurationManager.4.7.0
System.Drawing.Common.4.7.0
System.IdentityModel.Tokens.Jwt.6.8.0
System.Runtime.Caching.4.7.0
System.Security.AccessControl.4.7.0
System.Security.Cryptography.Cng.4.5.0
System.Security.Cryptography.ProtectedData.4.7.0
System.Security.Permissions.4.7.0
System.Security.Principal.Windows.4.7.0
System.Text.Encoding.CodePages.4.7.0
System.Windows.Extensions.4.7.0

BankApp

Installing:

Microsoft.EntityFrameworkCore.Tools.6.0.0

Infrastructure\BankApp.Data

Installing:

Microsoft.EntityFrameworkCore.Tools.6.0.0


BankApp

Installing:

Microsoft.Extensions.Configuration.2.0.0
Microsoft.Extensions.Configuration.Binder.2.0.0
Microsoft.Extensions.DependencyModel.3.0.0
Serilog.2.10.0
Serilog.Settings.Configuration.3.4.0
System.Text.Json.4.6.0


BankApp

Installing:

Serilog.Sinks.File.5.0.0


BankApp

Installing:

Serilog.Sinks.Console.4.1.0



BankApp

Installing:

Serilog.Sinks.Debug.2.0.0



BankApp

Updates:

Microsoft.Data.SqlClient.2.1.4 -> Microsoft.Data.SqlClient.5.0.1
Microsoft.Data.SqlClient.SNI.runtime.2.1.1 -> Microsoft.Data.SqlClient.SNI.runtime.5.0.1
Microsoft.Extensions.Configuration.2.0.0 -> Microsoft.Extensions.Configuration.6.0.1
Microsoft.Extensions.Configuration.Binder.2.0.0 -> Microsoft.Extensions.Configuration.Binder.6.0.0
Microsoft.Identity.Client.4.21.1 -> Microsoft.Identity.Client.4.45.0
Microsoft.IdentityModel.JsonWebTokens.6.8.0 -> Microsoft.IdentityModel.JsonWebTokens.6.21.0
Microsoft.IdentityModel.Logging.6.8.0 -> Microsoft.IdentityModel.Logging.6.21.0
Microsoft.IdentityModel.Protocols.6.8.0 -> Microsoft.IdentityModel.Protocols.6.21.0
Microsoft.IdentityModel.Protocols.OpenIdConnect.6.8.0 -> Microsoft.IdentityModel.Protocols.OpenIdConnect.6.21.0
Microsoft.IdentityModel.Tokens.6.8.0 -> Microsoft.IdentityModel.Tokens.6.21.0
Microsoft.NETCore.Platforms.3.1.0 -> Microsoft.NETCore.Platforms.5.0.0
Microsoft.Win32.Registry.4.7.0 -> Microsoft.Win32.Registry.5.0.0
Microsoft.Win32.SystemEvents.4.7.0 -> Microsoft.Win32.SystemEvents.6.0.0
Serilog.2.10.0 -> Serilog.2.12.0
System.Configuration.ConfigurationManager.4.7.0 -> System.Configuration.ConfigurationManager.6.0.1
System.Drawing.Common.4.7.0 -> System.Drawing.Common.6.0.0
System.IdentityModel.Tokens.Jwt.6.8.0 -> System.IdentityModel.Tokens.Jwt.6.21.0
System.Runtime.Caching.4.7.0 -> System.Runtime.Caching.5.0.0
System.Security.AccessControl.4.7.0 -> System.Security.AccessControl.6.0.0
System.Security.Cryptography.Cng.4.5.0 -> System.Security.Cryptography.Cng.5.0.0
System.Security.Cryptography.ProtectedData.4.7.0 -> System.Security.Cryptography.ProtectedData.6.0.0
System.Security.Permissions.4.7.0 -> System.Security.Permissions.6.0.0
System.Security.Principal.Windows.4.7.0 -> System.Security.Principal.Windows.5.0.0
System.Text.Encoding.CodePages.4.7.0 -> System.Text.Encoding.CodePages.5.0.0
System.Text.Json.4.6.0 -> System.Text.Json.4.7.2
System.Windows.Extensions.4.7.0 -> System.Windows.Extensions.6.0.0

Installing:

Azure.Core.1.24.0
Azure.Identity.1.6.0
Microsoft.Bcl.AsyncInterfaces.1.1.1
Microsoft.Extensions.Options.ConfigurationExtensions.6.0.0
Microsoft.Identity.Client.Extensions.Msal.2.19.3
Microsoft.IdentityModel.Abstractions.6.21.0
Microsoft.NETCore.Targets.1.1.0
Microsoft.SqlServer.Server.1.0.0
Serilog.Sinks.MSSqlServer.6.0.0
Serilog.Sinks.PeriodicBatching.3.1.0
System.Buffers.4.5.1
System.Formats.Asn1.5.0.0
System.Globalization.4.3.0
System.IO.4.3.0
System.Memory.4.5.4
System.Memory.Data.1.0.2
System.Numerics.Vectors.4.5.0
System.Reflection.4.3.0
System.Reflection.Primitives.4.3.0
System.Resources.ResourceManager.4.3.0
System.Runtime.4.3.0
System.Text.Encoding.4.3.0
System.Text.Encodings.Web.4.7.2
System.Threading.Tasks.4.3.0
System.Threading.Tasks.Extensions.4.5.4



BankApp

Installing:

Serilog.Sinks.Async.1.5.0


BankApp

Installing:

Microsoft.Extensions.Hosting.Abstractions.3.1.8
Serilog.AspNetCore.6.1.0
Serilog.Extensions.Hosting.5.0.1
Serilog.Extensions.Logging.3.1.0
Serilog.Formatting.Compact.1.1.0



BankApp

Installing:

Serilog.Enrichers.Environment.2.2.0


BankApp

Installing:

Serilog.Enrichers.Thread.3.1.0


BankApp

Installing:

Serilog.Enrichers.Process.2.0.2


BankApp

Updates:

Microsoft.CSharp.4.5.0 -> Microsoft.CSharp.4.7.0

Installing:

Newtonsoft.Json.13.0.1
Serilog.Enrichers.Context.4.6.0


BankApp

Installing:

Serilog.Enrichers.AssemblyName.1.0.9


BankApp

Installing:

Serilog.Exceptions.8.4.0
System.Reflection.TypeExtensions.4.7.0


BankApp

Installing:

FluentValidation.11.2.1
FluentValidation.AspNetCore.11.2.2
FluentValidation.DependencyInjectionExtensions.11.2.1


Infrastructure\BankApp.Identity

Installing:

Microsoft.AspNetCore.Authentication.OpenIdConnect.6.0.0
Microsoft.CSharp.4.5.0
Microsoft.IdentityModel.JsonWebTokens.6.10.0
Microsoft.IdentityModel.Logging.6.10.0
Microsoft.IdentityModel.Protocols.6.10.0
Microsoft.IdentityModel.Protocols.OpenIdConnect.6.10.0
Microsoft.IdentityModel.Tokens.6.10.0
System.IdentityModel.Tokens.Jwt.6.10.0
System.Security.Cryptography.Cng.4.5.0


Infrastructure\BankApp.Identity

Installing:

Microsoft.AspNetCore.Authentication.JwtBearer.6.0.0


BankApp

Installing:

Microsoft.AspNetCore.Authentication.OpenIdConnect.6.0.0


BankApp

Installing:

Microsoft.AspNetCore.Authentication.JwtBearer.6.0.0


BankApp

Installing:

Elasticsearch.Net.7.8.1
Serilog.Formatting.Elasticsearch.8.4.1
Serilog.Sinks.Elasticsearch.8.4.1

BankApp

Installing:

Serilog.Sinks.Splunk.3.7.0

BankApp

Installing:

Microsoft.AspNetCore.Mvc.Versioning.5.0.0

BankApp

Installing:

Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer.5.0.0

BankApp

Installing:

Microsoft.Extensions.Http.6.0.0
Microsoft.Extensions.Http.Polly.6.0.0
Polly.7.2.2
Polly.Extensions.Http.3.0.0

BankApp

Updates:

Microsoft.Extensions.Hosting.Abstractions.3.1.8 -> Microsoft.Extensions.Hosting.Abstractions.6.0.0

Installing:

Microsoft.Extensions.Diagnostics.HealthChecks.6.0.0
Microsoft.Extensions.Diagnostics.HealthChecks.Abstractions.6.0.0
Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore.6.0.0


BankApp

Installing:

Microsoft.Extensions.Diagnostics.HealthChecks.6.0.0


BankApp

Installing:

Microsoft.Extensions.Caching.StackExchangeRedis.6.0.0
Pipelines.Sockets.Unofficial.2.2.0
StackExchange.Redis.2.2.4
System.Diagnostics.PerformanceCounter.5.0.0
System.IO.Pipelines.5.0.0

BankApp

Installing:

AutoMapper.12.0.0
AutoMapper.Extensions.Microsoft.DependencyInjection.12.0.0

BankApp

Installing:

Serilog.Formatting.Elasticsearch.8.4.1

