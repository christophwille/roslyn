﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.LanguageService;
using Microsoft.CodeAnalysis.Shared.Extensions.ContextQuery;
using Microsoft.CodeAnalysis.Snippets.SnippetProviders;

namespace Microsoft.CodeAnalysis.Snippets
{
    internal abstract class AbstractIfSnippetProvider : AbstractConditionalBlockSnippetProvider
    {
        public override string Identifier => "if";

        public override string Description => FeaturesResources.if_statement;

        public override ImmutableArray<string> AdditionalFilterTexts { get; } = ["statement"];

        protected override Func<SyntaxNode?, bool> GetSnippetContainerFunction(ISyntaxFacts syntaxFacts) => syntaxFacts.IsIfStatement;

        protected override SyntaxNode GenerateStatement(SyntaxGenerator generator, SyntaxContext syntaxContext, InlineExpressionInfo? inlineExpressionInfo)
            => generator.IfStatement(inlineExpressionInfo?.Node.WithoutLeadingTrivia() ?? generator.TrueLiteralExpression(), []);
    }
}
