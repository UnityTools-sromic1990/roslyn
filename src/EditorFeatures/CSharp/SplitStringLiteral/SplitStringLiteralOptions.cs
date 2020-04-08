﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Options.Providers;

namespace Microsoft.CodeAnalysis.Editor.CSharp.SplitStringLiteral
{
    internal class SplitStringLiteralOptions
    {
        public static PerLanguageOption<bool> Enabled =
            new PerLanguageOption<bool>(nameof(SplitStringLiteralOptions), nameof(Enabled), defaultValue: true,
                storageLocations: new RoamingProfileStorageLocation("TextEditor.%LANGUAGE%.Specific.SplitStringLiterals"));
    }

    [ExportOptionProvider(LanguageNames.CSharp), Shared]
    internal class SplitStringLiteralOptionsProvider : IOptionProvider
    {
        [ImportingConstructor]
        public SplitStringLiteralOptionsProvider()
        {
        }

        public ImmutableArray<IOption> Options { get; } = ImmutableArray.Create<IOption>(
            SplitStringLiteralOptions.Enabled);
    }
}
