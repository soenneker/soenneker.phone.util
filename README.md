[![](https://img.shields.io/nuget/v/soenneker.phone.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.phone.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.phone.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.phone.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.phone.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.phone.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.phone.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.phone.util/actions/workflows/codeql.yml)

# Soenneker.Phone.Util

A utility library for phone related operations.

## Install

```bash
dotnet add package Soenneker.Phone.Util
```

## Quick start

```csharp
using Soenneker.Phone.Util.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddPhoneUtilAsSingleton();
```

Adds `IPhoneUtil` as a singleton service.

## What you get

- `IPhoneUtil` — A utility library for phone related operations.
- `PhoneUtilRegistrar` — A utility library for phone related operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IPhoneUtil.ToE164(phone, defaultRegion, cancellationToken)` | Converts any dialable string to strict “+E.164” using libphonenumber. National numbers must supply `defaultRegion` (ISO‑3166 alpha‑2, e.g. "US", "GB"). International numbers already starting with ‘+’ are parsed regardless of region. | A task whose result is the text returned by to E. |
| `PhoneUtilRegistrar.AddPhoneUtilAsSingleton(services)` | Adds `IPhoneUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `PhoneUtilRegistrar.AddPhoneUtilAsScoped(services)` | Adds `IPhoneUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Important behavior

- `IPhoneUtil.ToE164(phone, defaultRegion, cancellationToken)`: The input is not a valid number for the given region.

## Practical notes

- Cancellation stops pending work; it does not undo work that has already completed.
