// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Razor.Generator;
using Microsoft.AspNet.Razor.Generator.Compiler.CSharp;
using Microsoft.Framework.Internal;

namespace Microsoft.AspNet.Mvc.Razor
{
    public class ModelChunkVisitor : MvcCSharpCodeVisitor
    {
        public ModelChunkVisitor([NotNull] CSharpCodeWriter writer,
                                 [NotNull] CodeBuilderContext context)
            : base(writer, context)
        {
        }

        protected override void Visit(ModelChunk chunk)
        {
            var csharpVisitor = new CSharpCodeVisitor(Writer, Context);

            Writer.Write(chunk.BaseType).Write("<");
            csharpVisitor.CreateExpressionCodeMapping(chunk.ModelType, chunk);
            Writer.Write(">");
        }
    }
}