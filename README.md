[![](https://img.shields.io/nuget/v/soenneker.phone.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.phone.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.phone.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.phone.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.phone.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.phone.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.phone.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.phone.util/actions/workflows/codeql.yml)

# Soenneker.Phone.Util

Parse, validate, and format phone numbers as E.164 with libphonenumber.

## Install

```bash
dotnet add package Soenneker.Phone.Util
```

## Registration

```csharp
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Phone.Util.Registrars;

services.AddPhoneUtilAsScoped();
```

The scoped registration keeps the lightweight utility scoped while reusing the singleton libphonenumber provider. `AddPhoneUtilAsSingleton()` is also available.

## Usage

Inject `IPhoneUtil`, then pass a national number and its ISO 3166-1 alpha-2 region:

```csharp
using Soenneker.Phone.Util.Abstract;

string phone = await phoneUtil.ToE164(
    "(415) 555-2671",
    "US",
    cancellationToken);

// +14155552671
```

Numbers already written in international form are parsed independently of the default region:

```csharp
string phone = await phoneUtil.ToE164(
    "+44 20 7946 0958",
    cancellationToken: cancellationToken);
```

The method validates the parsed number before formatting it. Syntax and region parsing failures throw `NumberParseException`; a number that parses but is not valid for the resolved region throws `InvalidOperationException`. This validates numbering-plan structure, not whether the number is assigned, reachable, or owned by a particular person.
