﻿
namespace SolidityAST
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CompilerOutput
    {
        [JsonProperty]
        public Dictionary<string, Dictionary<string, object>> Contracts { get; private set; }

        [JsonProperty]
        public List<CompilerError> Errors { get; private set; }

        [JsonProperty]
        public Dictionary<string, SoliditySourceFile> Sources { get; private set; }

        public bool ContainsError()
        {
            if (Errors == null) return false;
            foreach (CompilerError error in Errors)
            {
                if (error.Severity.Equals("error"))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class CompilerError
    {
        public string FormattedMessage { get; set; }

        public string Severity { get; set; }
    }

    public class SoliditySourceFile
    {
        public int Id { get; set; }

        public ASTNode Ast { get; set; }
    }
}