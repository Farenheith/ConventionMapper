﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace ConventionMapper.Generator
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    internal partial class BaseMappingGenerator : BaseMappingGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            
            #line 11 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
 

if (_options.DestinationGroup == null)
	throw new InvalidOperationException("DestinationGroup must not be null");

if (_options.Pairs == null)
	throw new InvalidOperationException("Pairs must not be null");

if (_options.GeneratedNamespace == null)
	throw new InvalidOperationException("GeneratedNamespace must not be null");

Run();


            
            #line default
            #line hidden
            this.Write("\r\n");
            return this.GenerationEnvironment.ToString();
        }
        private global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost hostValue;
        /// <summary>
        /// The current host for the text templating engine
        /// </summary>
        public virtual global::Microsoft.VisualStudio.TextTemplating.ITextTemplatingEngineHost Host
        {
            get
            {
                return this.hostValue;
            }
            set
            {
                this.hostValue = value;
            }
        }
        
        #line 26 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"


internal readonly string _outputDirectory;
private readonly MappingGenerator _options;

public string OutputDirectory { get {
		return _outputDirectory;
	}
}

public BaseMappingGenerator(MappingGenerator options) {
	_options = options;
	_outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "output\\" + _options.DestinationGroup + "Mappings\\");
}

protected void Run() {

	IEnumerable<Tuple<Type, Type>> models;
	foreach (var modelPair in _options.Pairs) {
		var source = modelPair.Value;
		var destination = modelPair.Key;
		var originName = source.Name;
		var className = originName + "To" + _options.DestinationGroup;
		var destinationName = destination.Name;

        
        #line default
        #line hidden
        
        #line 50 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("using ConventionMapper;\r\n");

        
        #line default
        #line hidden
        
        #line 52 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
 foreach (var include in GetRequiredNamespaces(source, destination)) { 
        
        #line default
        #line hidden
        
        #line 52 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("using ");

        
        #line default
        #line hidden
        
        #line 53 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(include));

        
        #line default
        #line hidden
        
        #line 53 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(";\r\n");

        
        #line default
        #line hidden
        
        #line 54 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
 } 
        
        #line default
        #line hidden
        
        #line 54 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("using System.Collections.Generic;\r\n\r\nnamespace ");

        
        #line default
        #line hidden
        
        #line 57 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(_options.GeneratedNamespace));

        
        #line default
        #line hidden
        
        #line 57 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("Mappings\r\n{\r\n  ");

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(_options.Acessibility.ToString()));

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" partial class ");

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(className));

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" : MappingBase, IMapping<");

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(originName));

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(", ");

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(destinationName));

        
        #line default
        #line hidden
        
        #line 59 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(">\r\n  {\r\n    public ");

        
        #line default
        #line hidden
        
        #line 61 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(className));

        
        #line default
        #line hidden
        
        #line 61 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("(IConversionCache _cache) : base(_cache) { }\r\n    public ");

        
        #line default
        #line hidden
        
        #line 62 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(className));

        
        #line default
        #line hidden
        
        #line 62 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("() : base() { }\r\n\r\n    public ");

        
        #line default
        #line hidden
        
        #line 64 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(destinationName));

        
        #line default
        #line hidden
        
        #line 64 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" Convert(");

        
        #line default
        #line hidden
        
        #line 64 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(originName));

        
        #line default
        #line hidden
        
        #line 64 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" source, ");

        
        #line default
        #line hidden
        
        #line 64 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(destinationName));

        
        #line default
        #line hidden
        
        #line 64 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" destination)\r\n    {\r\n\t\t\t");

        
        #line default
        #line hidden
        
        #line 66 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"

				var binding = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
				var properties = destination.GetProperties(binding);
				for (var i = 0; i < properties.Length; i++) {
					var property = properties[i];
					var originProperty = source.GetProperties(binding).FirstOrDefault(x => x.Name == property.Name);
					if (originProperty != null) {
						var setter = property.SetMethod;
                        var getter = originProperty.GetMethod;
						if (setter == null && getter == null)
							continue;
                        if (_options.Acessibility == AcessibilityLevelEnum.@public && !setter.IsPublic && !getter.IsPublic)
                            continue;
                        if (setter.IsFamily || setter.IsPrivate || getter.IsFamily || getter.IsPrivate)
                            continue;
						if (property.PropertyType.IsEnum) {
			
        
        #line default
        #line hidden
        
        #line 82 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("      destination.");

        
        #line default
        #line hidden
        
        #line 83 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 83 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" = (int)source.");

        
        #line default
        #line hidden
        
        #line 83 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 83 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(";\r\n\t\t\t");

        
        #line default
        #line hidden
        
        #line 84 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"

						} else if (property.PropertyType.Name == "Nullable`1"
							|| property.PropertyType.Equals(originProperty.PropertyType)) {
			
        
        #line default
        #line hidden
        
        #line 87 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("      destination.");

        
        #line default
        #line hidden
        
        #line 88 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 88 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" = source.");

        
        #line default
        #line hidden
        
        #line 88 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 88 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(";\r\n\t\t\t");

        
        #line default
        #line hidden
        
        #line 89 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"

						} else {
			
        
        #line default
        #line hidden
        
        #line 91 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("      destination.");

        
        #line default
        #line hidden
        
        #line 92 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 92 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" = Get<");

        
        #line default
        #line hidden
        
        #line 92 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeName(property.PropertyType)));

        
        #line default
        #line hidden
        
        #line 92 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(">(source.");

        
        #line default
        #line hidden
        
        #line 92 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));

        
        #line default
        #line hidden
        
        #line 92 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(");\r\n\t\t\t");

        
        #line default
        #line hidden
        
        #line 93 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"

						}
					}
				}
			
        
        #line default
        #line hidden
        
        #line 97 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write("      return TreatResult(destination);\r\n    }\r\n\r\n\tpublic ");

        
        #line default
        #line hidden
        
        #line 101 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(destinationName));

        
        #line default
        #line hidden
        
        #line 101 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" Map(");

        
        #line default
        #line hidden
        
        #line 101 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(originName));

        
        #line default
        #line hidden
        
        #line 101 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(" source)\r\n\t{\r\n\t\treturn Map<");

        
        #line default
        #line hidden
        
        #line 103 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(originName));

        
        #line default
        #line hidden
        
        #line 103 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(", ");

        
        #line default
        #line hidden
        
        #line 103 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(this.ToStringHelper.ToStringWithCulture(destinationName));

        
        #line default
        #line hidden
        
        #line 103 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"
this.Write(">(source);\r\n\t}\r\n  }\r\n}\r\n");

        
        #line default
        #line hidden
        
        #line 107 "D:\Projetos\Pessoal\ConventionMapper\ConventionMapper.Generator\BaseMappingGenerator.tt"

	  // End of file.
	  SaveOutput(className + ".cs");
	}
}

private void SaveOutput(string outputFileName) {
  var outputFilePath = Path.Combine(_outputDirectory, outputFileName);
  Directory.CreateDirectory(_outputDirectory);
  File.WriteAllText(outputFilePath, this.GenerationEnvironment.ToString()); 
  this.GenerationEnvironment.Remove(0, this.GenerationEnvironment.Length);
	Console.WriteLine("Created " + outputFilePath);
}

private static string GetTypeName(Type type)
{
	var generics = type.GetGenericArguments();
	if (generics.Length == 0)
		return type.Name;
	else if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
		return type.GetGenericArguments()[0].Name + "?";
	else
		return type.GetGenericArguments()[0].Name;
}

private static IEnumerable<string> GetRequiredNamespaces(Type source, Type destination) {
	yield return source.Namespace;
	if (source.Namespace != destination.Namespace)
		yield return destination.Namespace;
}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    internal class BaseMappingGeneratorBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
