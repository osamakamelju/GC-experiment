# GC-experiment i .NET Core

Detta projekt är en del av ett examensarbete vid Tekniska Högskolan i Jönköping, och fokuserar på minneshantering i .NET Core med särskild betoning på Garbage Collection (GC).

## 🧠 Syfte

Syftet är att undersöka hur olika GC-strategier i .NET Core påverkar applikationens prestanda, med hjälp av både teoretisk analys och praktiska kodexperiment.

## 📁 Innehåll

Projektet innehåller enkla C#-program som testar olika scenarier:

- Allokering av många små objekt
- Allokering av stora objekt (LOH)
- Manuell GC-aktivering
- Mätning av exekveringstid och minnesförbrukning

## 🚀 Kom igång

### Förutsättningar

- .NET 8 SDK installerat
- Visual Studio Code eller annan C#-kompatibel editor

### Kör testkod

```bash
dotnet build
dotnet run
