// Copyright 2005-2015 Giacomo Stelluti Scala & Contributors. All rights reserved. See License.md in the project root for license information.

using System;
using System.Collections.Generic;

namespace CommandLine
{
    /// <summary>
    /// Models a verb command specification.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public sealed class VerbAttribute : Attribute
    {
        private readonly string name;
        private string helpText;
        public List<string> Alias = new List<string>();
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLine.VerbAttribute"/> class.
        /// </summary>
        /// <param name="name">The long name of the verb command.</param>
        /// <exception cref="System.ArgumentException">Thrown if <paramref name="name"/> is null, empty or whitespace.</exception>
        public VerbAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name");

            this.name = name;
         
            this.helpText = string.Empty;
        }
        public VerbAttribute(params string[] names)
        {
            if (string.IsNullOrWhiteSpace(names[0])) throw new ArgumentException("name");
            
            this.name = names[0];
            for (int i = 1; i < names.Length; i++)
                Alias.Add(names[i]);

            this.helpText = string.Empty;
        }
        /// <summary>
        /// Gets the verb name.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a command line verb is visible in the help text.
        /// </summary>
        public bool Hidden
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a short description of this command line option. Usually a sentence summary. 
        /// </summary>
        public string HelpText
        {
            get { return helpText; }
            set
            {
                helpText = value ?? throw new ArgumentNullException("value");
            }
        }
    }
}
