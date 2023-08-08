using FastLogr.Generator.Sources;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FastLogr.Generator;

[Generator]
public class FastLogrGenerator : IIncrementalGenerator
{
    private const string MarkerAttributeFullQualifiedNameTest = "FastLogr.Attributes.LogMessageAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var logMessagesToGenerate = context.SyntaxProvider.ForAttributeWithMetadataName(
            MarkerAttributeFullQualifiedNameTest,
            static (syntaxNode, _) => true,
            GetSemanticTargetForGeneration).Where(x => x is not null);
        
        context.RegisterSourceOutput(logMessagesToGenerate, GenerateLogMessages!);
    }
    
    private static void GenerateLogMessages(SourceProductionContext context, LogMessageToGenerate logMessageToGenerate)
    {
        context.AddSource($"{logMessageToGenerate.ClassName}Extensions.g.cs", LoggerExtensionSource.GetSource(logMessageToGenerate));
    }

    private static LogMessageToGenerate? GetSemanticTargetForGeneration(GeneratorAttributeSyntaxContext context, CancellationToken ct)
    {
        var ancestors = context.TargetNode.Ancestors();
        if (ancestors.FirstOrDefault(x => x.IsKind(SyntaxKind.CompilationUnit)) is not CompilationUnitSyntax compilationUnit)
        {
            return null;
        }
        
        var markerAttribute = context.SemanticModel.Compilation.GetTypeByMetadataName(MarkerAttributeFullQualifiedNameTest);
        if (markerAttribute is null)
        {
            return null;
        }
        
        var attribute = context.Attributes.FirstOrDefault(a =>
            a.AttributeClass is not null && a.AttributeClass.Equals(markerAttribute, SymbolEqualityComparer.Default));
        
        if (attribute is null)
        {
            return null;
        }

        if (context.TargetNode.Parent is not VariableDeclarationSyntax parent)
        {
            return null;
        }

        if (parent.Type is not GenericNameSyntax parentType)
        {
            return null;
        }
        
        var className = context.TargetSymbol.Name;
        
        var actionTypes = new SyntaxNodeOrTokenList();
        var arguments = parentType.TypeArgumentList.Arguments;
        foreach (var argument in arguments)
        {
            actionTypes = actionTypes.Add(argument);
            if (arguments.Last() != argument)
            {
                actionTypes = actionTypes.Add(Token(SyntaxKind.CommaToken));
            }
        }
        
        var messageTemplate = attribute.NamedArguments.First(a => a.Key == "MessageTemplate").Value.Value;
        var logLevel = attribute.NamedArguments.FirstOrDefault(a => a.Key == "LogLevel").Value.Value ?? LogLevel.Information;
        var eventId = attribute.NamedArguments.FirstOrDefault(a => a.Key == "EventId").Value.Value ?? 0;
        var eventName = attribute.NamedArguments.FirstOrDefault(a => a.Key == "EventName").Value.Value;
        
        
        return new LogMessageToGenerate(className, actionTypes, (LogLevel)logLevel, new EventId((int)eventId, (string?)eventName), (string)messageTemplate!, compilationUnit.Usings);
    }
}