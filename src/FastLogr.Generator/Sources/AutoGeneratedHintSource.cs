using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace FastLogr.Generator.Sources;

internal static class AutoGeneratedHintSource
{
    internal static SyntaxToken GetSyntaxToken(SyntaxKind syntaxKind) =>
        Token(
            TriviaList(AutoGeneratedHint()),
            syntaxKind,
            TriviaList());

    internal static SyntaxTrivia[] AutoGeneratedHint() => new[]
    {
        Comment(
            "//------------------------------------------------------------------------------"),
        Comment("// <auto-generated>"),
        Comment("//     This code was generated by a tool."),
        Comment("//"), Comment(
            "//     Changes to this file may cause incorrect behavior and will be lost if"),
        Comment("//     the code is regenerated."),
        Comment("// </auto-generated>"), Comment(
            "//------------------------------------------------------------------------------")
    };
}