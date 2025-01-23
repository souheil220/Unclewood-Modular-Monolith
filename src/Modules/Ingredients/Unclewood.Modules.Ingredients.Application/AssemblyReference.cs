using System.Reflection;

namespace Unclewood.Modules.Ingredients.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}