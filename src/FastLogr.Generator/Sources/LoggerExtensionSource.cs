using System.Text;
using FastLogr.Generator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FastLogr.Generator.Sources;

internal static class LoggerExtensionSource
{
    internal static SourceText GetSource(LogMessageToGenerate logMessageToGenerate)
    {
        var fullTypeArgumentList = logMessageToGenerate.ActionTypes;
        fullTypeArgumentList = fullTypeArgumentList.Insert(0, IdentifierName("ILogger"));
        fullTypeArgumentList = fullTypeArgumentList.Insert(1,Token(SyntaxKind.CommaToken));
        fullTypeArgumentList = fullTypeArgumentList.Add(Token(SyntaxKind.CommaToken));
        fullTypeArgumentList = fullTypeArgumentList.Add(IdentifierName(nameof(Exception)));

        var usings = new List<UsingDirectiveSyntax>()
        {
            UsingDirective(
                IdentifierName("System")),
            UsingDirective(
                QualifiedName(
                    QualifiedName(
                        IdentifierName("Microsoft"),
                        IdentifierName("Extensions")),
                    IdentifierName("Logging")))
        };
        usings.AddRange(logMessageToGenerate.Usings);

        var staticActionName = $"s_{logMessageToGenerate.ClassName.ToLowerCamelCase()}";
        
        return CompilationUnit()
            .WithUsings(
                List(
                    usings))
            .WithMembers(
                SingletonList<MemberDeclarationSyntax>(
                    FileScopedNamespaceDeclaration(
                            QualifiedName(
                                QualifiedName(
                                    IdentifierName("SourceGenPlayground"),
                                    IdentifierName("Example")),
                                IdentifierName("Worker")))
                        .WithMembers(
                            SingletonList<MemberDeclarationSyntax>(
                                ClassDeclaration($"{logMessageToGenerate.ClassName}Extensions")
                                    .WithModifiers(
                                        TokenList(
                                            new[]
                                            {
                                                Token(SyntaxKind.PublicKeyword),
                                                Token(SyntaxKind.StaticKeyword)
                                            }))
                                    .WithMembers(
                                        List(
                                            new MemberDeclarationSyntax[]
                                            {
                                                FieldDeclaration(
                                                        VariableDeclaration(
                                                                GenericName(
                                                                        Identifier("Action"))
                                                                    .WithTypeArgumentList(
                                                                        TypeArgumentList(
                                                                            SeparatedList<TypeSyntax>(
                                                                                fullTypeArgumentList))))
                                                            .WithVariables(
                                                                SingletonSeparatedList(
                                                                    VariableDeclarator(
                                                                            Identifier(
                                                                                staticActionName))
                                                                        .WithInitializer(
                                                                            EqualsValueClause(
                                                                                InvocationExpression(
                                                                                        MemberAccessExpression(
                                                                                            SyntaxKind
                                                                                                .SimpleMemberAccessExpression,
                                                                                            IdentifierName(
                                                                                                "LoggerMessage"),
                                                                                            GenericName(
                                                                                                    Identifier(
                                                                                                        "Define"))
                                                                                                .WithTypeArgumentList(
                                                                                                    TypeArgumentList(
                                                                                                        SeparatedList<
                                                                                                            TypeSyntax>(
                                                                                                            logMessageToGenerate.ActionTypes)))))
                                                                                    .WithArgumentList(
                                                                                        ArgumentList(
                                                                                            SeparatedList<
                                                                                                ArgumentSyntax>(
                                                                                                new SyntaxNodeOrToken[]
                                                                                                {
                                                                                                    Argument(
                                                                                                        MemberAccessExpression(
                                                                                                            SyntaxKind
                                                                                                                .SimpleMemberAccessExpression,
                                                                                                            IdentifierName(
                                                                                                                "LogLevel"),
                                                                                                            IdentifierName(
                                                                                                                logMessageToGenerate.LogLevel.ToString()))),
                                                                                                    Token(SyntaxKind
                                                                                                        .CommaToken),
                                                                                                    Argument(
                                                                                                        ObjectCreationExpression(
                                                                                                                IdentifierName(
                                                                                                                    "EventId"))
                                                                                                            .WithArgumentList(
                                                                                                                ArgumentList(
                                                                                                                    SeparatedList
                                                                                                                        <ArgumentSyntax>(
                                                                                                                            new
                                                                                                                                SyntaxNodeOrToken
                                                                                                                                []
                                                                                                                                {
                                                                                                                                    Argument(
                                                                                                                                        LiteralExpression(
                                                                                                                                            SyntaxKind
                                                                                                                                                .NumericLiteralExpression,
                                                                                                                                            Literal(logMessageToGenerate.EventId.Id))),
                                                                                                                                    Token(
                                                                                                                                        SyntaxKind
                                                                                                                                            .CommaToken),
                                                                                                                                    Argument(
                                                                                                                                        LiteralExpression(
                                                                                                                                            SyntaxKind
                                                                                                                                                .StringLiteralExpression,
                                                                                                                                            Literal(logMessageToGenerate.EventId.Name ?? "")))
                                                                                                                                })))),
                                                                                                    Token(SyntaxKind
                                                                                                        .CommaToken),
                                                                                                    Argument(
                                                                                                        LiteralExpression(
                                                                                                            SyntaxKind
                                                                                                                .StringLiteralExpression,
                                                                                                            Literal(logMessageToGenerate.TemplateMessage)))
                                                                                                }))))))))
                                                    .WithModifiers(
                                                        TokenList(
                                                            new[]
                                                            {
                                                                Token(SyntaxKind.PrivateKeyword),
                                                                Token(SyntaxKind.StaticKeyword),
                                                                Token(SyntaxKind.ReadOnlyKeyword)
                                                            })),
                                                MethodDeclaration(
                                                        PredefinedType(
                                                            Token(SyntaxKind.VoidKeyword)),
                                                        Identifier(logMessageToGenerate.ClassName))
                                                    .WithModifiers(
                                                        TokenList(
                                                            new[]
                                                            {
                                                                Token(SyntaxKind.PublicKeyword),
                                                                Token(SyntaxKind.StaticKeyword)
                                                            }))
                                                    .WithParameterList(
                                                        ParameterList(
                                                            SeparatedList<ParameterSyntax>(BuildMethodParameters(logMessageToGenerate))))
                                                    .WithExpressionBody(
                                                        ArrowExpressionClause(
                                                            InvocationExpression(
                                                                    IdentifierName(staticActionName))
                                                                .WithArgumentList(
                                                                    ArgumentList(
                                                                        SeparatedList<ArgumentSyntax>(
                                                                            BuildPassedParameters(logMessageToGenerate))))))
                                                    .WithSemicolonToken(
                                                        Token(SyntaxKind.SemicolonToken))
                                            }))))))
            .NormalizeWhitespace()
            .GetText(Encoding.UTF8);
    }

    private static SyntaxNodeOrTokenList BuildMethodParameters(LogMessageToGenerate logMessageToGenerate)
    {
        var parameterList = new SyntaxNodeOrTokenList();
        parameterList = parameterList.Add(Parameter(
                Identifier("logger"))
            .WithModifiers(
                TokenList(
                    Token(SyntaxKind.ThisKeyword)))
            .WithType(
                IdentifierName("ILogger")));
        parameterList = parameterList.Add(Token(SyntaxKind.CommaToken));
        var count = 1;
        var actionTypes = logMessageToGenerate.ActionTypes;
        foreach (var actionType in actionTypes)
        {
            if (actionType == null || actionType.Kind() is SyntaxKind.CommaToken)
            {
                continue;
            }
            parameterList = parameterList.Add(Parameter(
                    Identifier($"arg{count}"))
                .WithType((TypeSyntax)actionType!));
            if (actionTypes.Last() != actionType)
            {
                parameterList = parameterList.Add(Token(SyntaxKind.CommaToken));
                count++;
            }
        }

        return parameterList;
    }
    
    private static SyntaxNodeOrTokenList BuildPassedParameters(LogMessageToGenerate logMessageToGenerate)
    {
        var parameterList = new SyntaxNodeOrTokenList();
        parameterList = parameterList.Add(Argument(IdentifierName("logger")));
        parameterList = parameterList.Add(Token(SyntaxKind.CommaToken));
        var count = 1;
        foreach (var actionType in logMessageToGenerate.ActionTypes)
        {
            if (actionType.Kind() is SyntaxKind.CommaToken)
            {
                continue;
            }
            parameterList = parameterList.Add(Argument(IdentifierName($"arg{count}")));
            parameterList = parameterList.Add(Token(SyntaxKind.CommaToken));
            count++;
        }

        parameterList = parameterList.Add(Argument(
            PostfixUnaryExpression(
                SyntaxKind
                    .SuppressNullableWarningExpression,
                LiteralExpression(
                    SyntaxKind
                        .DefaultLiteralExpression,
                    Token(SyntaxKind
                        .DefaultKeyword)))));

        return parameterList;
    }
}