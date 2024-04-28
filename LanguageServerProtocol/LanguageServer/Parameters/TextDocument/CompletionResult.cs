﻿using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c>
    /// </summary>
    /// <remarks>
    /// <see cref="CompletionItem"/>[] | <see cref="TextDocument.CompletionList"/>
    /// </remarks>
    public class CompletionResult : Either
    {
        /// <summary>
        /// Defines an implicit conversion of a <see cref="CompletionItem"/>[] to a <see cref="CompletionResult"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator CompletionResult(CompletionItem[] value) => new(value);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="TextDocument.CompletionList"/> to a <see cref="CompletionResult"/>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator CompletionResult(CompletionList value) => new(value);

        /// <summary>
        /// Initializes a new instance of <c>CompletionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public CompletionResult(CompletionItem[] value) : base(value, typeof(CompletionItem[])) { }

        /// <summary>
        /// Initializes a new instance of <c>CompletionResult</c> with the specified value.
        /// </summary>
        /// <param name="value"></param>
        public CompletionResult(CompletionList value) : base(value, typeof(CompletionList)) { }

        /// <summary>
        /// Returns true if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.CompletionItem[]"/>.
        /// </summary>
        public bool IsCompletionItemArray => type == typeof(CompletionItem[]);

        /// <summary>
        /// Returns true if its underlying value is a <see cref="CompletionList"/>.
        /// </summary>
        public bool IsCompletionList => type == typeof(CompletionList);

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="T:LanguageServer.Parameters.TextDocument.CompletionItem[]"/>.
        /// </summary>
        public CompletionItem[] CompletionItemArray => (CompletionItem[])value;

        /// <summary>
        /// Gets the value of the current object if its underlying value is a <see cref="CompletionList"/>.
        /// </summary>
        public CompletionList CompletionList => (CompletionList)value;
    }
}
