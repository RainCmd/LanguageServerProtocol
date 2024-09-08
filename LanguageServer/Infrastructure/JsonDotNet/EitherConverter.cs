using LanguageServer.Json;
using LanguageServer.Parameters;
using LanguageServer.Parameters.General;
using LanguageServer.Parameters.TextDocument;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace LanguageServer.Infrastructure.JsonDotNet
{
    /// <summary>
    /// 将Either派生类型转换为JSON或从JSON转换。
    /// </summary>
    public class EitherConverter : JsonConverter
    {
        private readonly Dictionary<Type, Func<JToken, object?>> table;

        /// <summary>
        /// 初始化实例
        /// </summary>
        public EitherConverter()
        {
            table = new Dictionary<Type, Func<JToken, object?>>
            {
                [typeof(ChangeNotificationsOptions)] = ToChangeNotificationsOptions,
                [typeof(CodeActionResult)] = ToCodeActionResult,
                [typeof(ColorProviderOptionsOrBoolean)] = ToColorProviderOptionsOrBoolean,
                [typeof(CompletionResult)] = ToCompletionResult,
                [typeof(DiagnosticOptionsOrProviderOptions)] = ToDiagnosticOptionsOrProviderOptions,
                [typeof(Documentation)] = ToDocumentation,
                [typeof(DocumentSymbolResult)] = ToDocumentSymbolResult,
                [typeof(FoldingRangeProviderOptionsOrBoolean)] = ToFoldingRangeProviderOptionsOrBoolean,
                [typeof(HoverContents)] = ToHoverContents,
                [typeof(LocationSingleOrArray)] = ToLocationSingleOrArray,
                [typeof(NumberOrString)] = ToNumberOrString,
                [typeof(ProviderOptionsOrBoolean)] = ToProviderOptionsOrBoolean,
                [typeof(TextDocumentContentChangeEvent)] = ToTextDocumentContentChangeEvent,
                [typeof(TextDocumentSync)] = ToTextDocumentSync,
                [typeof(TextEditOrInsertReplaceEdit)] = ToTextEditOrInsertReplaceEdit,
                [typeof(DocumentDiagnosticReport)] = ToDocumentDiagnosticReport,
                [typeof(RelatedDocumentDiagnosticReport)] = ToRelatedDocumentDiagnosticReport,
                [typeof(InlineValueResult)] = ToInlineValueResult,
                [typeof(InlayHintLabel)] = ToInlayHintLabel,
                [typeof(RenameOptionsOrBoolean)] = ToRenameOptionsOrBoolean,
            };
        }

        /// <summary>
        /// 确定此实例是否可以转换指定的对象类型。
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Either).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <summary>
        /// 读取对象的JSON表示。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (table.TryGetValue(objectType, out var convert))
                return convert(JToken.Load(reader));
            throw new NotImplementedException($"Could not deserialize '{objectType.FullName}'.");
        }

        #region Deserialization

        private ChangeNotificationsOptions? ToChangeNotificationsOptions(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Boolean => new ChangeNotificationsOptions(token.ToObject<bool>()),
                JTokenType.String => new ChangeNotificationsOptions(token.ToObject<string>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private CodeActionResult? ToCodeActionResult(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Array:
                    var array = (JArray)token;
                    if (array.Count == 0) return new CodeActionResult(Array.Empty<Command>());

                    var element = (array[0] as JObject) ?? throw new JsonSerializationException();
                    if (element.Property("edit") != null) return new CodeActionResult(array.ToObject<CodeAction[]>()!);

                    var command = element.Property("command") ?? throw new JsonSerializationException();
                    if (command.Type == JTokenType.Object) return new CodeActionResult(array.ToObject<CodeAction[]>()!);
                    else if (command.Type == JTokenType.String) return new CodeActionResult(array.ToObject<Command[]>()!);
                    throw new JsonSerializationException();
                default: throw new JsonSerializationException();
            }
        }

        private ColorProviderOptionsOrBoolean? ToColorProviderOptionsOrBoolean(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Boolean => new ColorProviderOptionsOrBoolean(token.ToObject<bool>()),
                JTokenType.Object => new ColorProviderOptionsOrBoolean(token.ToObject<ColorProviderOptions>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private CompletionResult? ToCompletionResult(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Array => new CompletionResult(token.ToObject<CompletionItem[]>()!),
                JTokenType.Object => new CompletionResult(token.ToObject<CompletionList>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private DiagnosticOptionsOrProviderOptions? ToDiagnosticOptionsOrProviderOptions(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Object:
                    {
                        var obj = (token as JObject) ?? throw new JsonSerializationException();
                        if (obj.Property("workspaceDiagnostics") != null)
                            return new DiagnosticOptionsOrProviderOptions(token.ToObject<DiagnosticOptions>()!);
                        else
                            return new DiagnosticOptionsOrProviderOptions(token.ToObject<ProviderOptions>()!);
                    }
                default:
                    throw new JsonSerializationException();

            }
        }

        private Documentation? ToDocumentation(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.String => new Documentation(token.ToObject<string>()!),
                JTokenType.Object => new Documentation(token.ToObject<MarkupContent>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private DocumentSymbolResult? ToDocumentSymbolResult(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Array:
                    var array = (JArray)token;
                    if (array.Count == 0) return new DocumentSymbolResult(Array.Empty<DocumentSymbol>());

                    var element = (array[0] as JObject) ?? throw new JsonSerializationException();
                    if (element.Property("range") != null) return new DocumentSymbolResult(array.ToObject<DocumentSymbol[]>()!);
                    else if (element.Property("location") != null) return new DocumentSymbolResult(array.ToObject<SymbolInformation[]>()!);
                    throw new JsonSerializationException();
                default: throw new JsonSerializationException();

            }
        }

        private FoldingRangeProviderOptionsOrBoolean? ToFoldingRangeProviderOptionsOrBoolean(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Boolean => new FoldingRangeProviderOptionsOrBoolean(token.ToObject<bool>()),
                JTokenType.Object => new FoldingRangeProviderOptionsOrBoolean(token.ToObject<FoldingRangeProviderOptions>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private HoverContents? ToHoverContents(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.String: return new HoverContents(token.ToObject<string>()!);
                case JTokenType.Object:
                    var obj = (JObject)token;
                    return new HoverContents(obj.ToObject<MarkupContent>()!);
                    throw new JsonSerializationException();
                case JTokenType.Array:
                    var array = (JArray)token;
                    if (array.Count == 0) return new HoverContents(Array.Empty<string>());

                    var element = (array[0] as JObject) ?? throw new JsonSerializationException();
                    if (element.Type == JTokenType.String) return new HoverContents(array.ToObject<string[]>()!);
                    else if (element.Type == JTokenType.Object) return new HoverContents(array.ToObject<MarkupContent[]>()!);
                    throw new JsonSerializationException();
                default: throw new JsonSerializationException();
            }
        }

        private LocationSingleOrArray? ToLocationSingleOrArray(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Object => new LocationSingleOrArray(token.ToObject<Location>()!),
                JTokenType.Array => new LocationSingleOrArray(token.ToObject<Location[]>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private NumberOrString? ToNumberOrString(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Integer => new NumberOrString(token.ToObject<long>()),
                JTokenType.String => new NumberOrString(token.ToObject<string>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private ProviderOptionsOrBoolean? ToProviderOptionsOrBoolean(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Boolean => new ProviderOptionsOrBoolean(token.ToObject<bool>()),
                JTokenType.Object => new ProviderOptionsOrBoolean(token.ToObject<ProviderOptions>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private TextDocumentContentChangeEvent? ToTextDocumentContentChangeEvent(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Object:
                    var obj = (JObject)token;
                    if (obj.ContainsKey("range")) return obj.ToObject<TextDocumentContentChange>()!;
                    else return obj.ToObject<TextDocumentContentWhole>()!;
                default: throw new JsonSerializationException();
            }
        }

        private TextDocumentSync? ToTextDocumentSync(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Integer => new TextDocumentSync(token.ToObject<TextDocumentSyncKind>()),
                JTokenType.Object => new TextDocumentSync(token.ToObject<TextDocumentSyncOptions>()!),
                _ => throw new JsonSerializationException(),
            };
        }

        private TextEditOrInsertReplaceEdit? ToTextEditOrInsertReplaceEdit(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Object:
                    var obj = (JObject)token;
                    if (obj.ContainsKey("range")) return obj.ToObject<TextEdit>()!;
                    else return obj.ToObject<InsertReplaceEdit>()!;
                default: throw new JsonSerializationException();
            }
        }

        private DocumentDiagnosticReport? ToDocumentDiagnosticReport(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Object:
                    var obj = (JObject)token;
                    if (obj.TryGetValue("kind", out var kind) && kind.Type == JTokenType.String)
                    {
                        if (kind.ToObject<string>() == DocumentDiagnosticReportKind.Full) return obj.ToObject<RelatedFullDocumentDiagnosticReport>()!;
                        else return obj.ToObject<RelatedUnchangedDocumentDiagnosticReport>()!;
                    }
                    return null;
                default: throw new JsonSerializationException();
            }
        }

        private RelatedDocumentDiagnosticReport? ToRelatedDocumentDiagnosticReport(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Object:
                    var obj = (JObject)token;
                    if (obj.TryGetValue("kind", out var kind) && kind.Type == JTokenType.String)
                    {
                        if (kind.ToObject<string>() == DocumentDiagnosticReportKind.Full) return obj.ToObject<FullDocumentDiagnosticReport>()!;
                        else return obj.ToObject<UnchangedDocumentDiagnosticReport>()!;
                    }
                    return null;
                default: throw new JsonSerializationException();
            }
        }

        private InlineValueResult? ToInlineValueResult(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Null: return null;
                case JTokenType.Object:
                    var obj = (JObject)token;
                    if (obj.ContainsKey("text")) return obj.ToObject<InlineValueText>()!;
                    else if (obj.ContainsKey("caseSensitiveLookup")) return obj.ToObject<InlineValueVariableLookup>()!;
                    else return obj.ToObject<InlineValueEvaluatableExpression>()!;
                default: throw new JsonSerializationException();
            }
        }

        private InlayHintLabel? ToInlayHintLabel(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.String => token.ToObject<string>()!,
                JTokenType.Array => token.ToObject<InlayHintLabelPart[]>()!,
                _ => throw new JsonSerializationException(),
            };
        }

        private RenameOptionsOrBoolean? ToRenameOptionsOrBoolean(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Null => null,
                JTokenType.Boolean => token.ToObject<bool>(),
                JTokenType.Object => token.ToObject<RenameOptions>()!,
                _ => throw new JsonSerializationException(),
            };
        }

        #endregion

        /// <summary>
        /// 写入对象的JSON表示。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, (value as Either)?.value);
        }
    }
}
