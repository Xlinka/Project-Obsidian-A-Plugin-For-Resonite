﻿using System;
using Newtonsoft.Json.Linq;
using ProtoFlux.Core;
using ProtoFlux.Runtimes.Execution;
using Elements.Core;
using FrooxEngine;
using FrooxEngine.ProtoFlux;

namespace ProtoFlux.Runtimes.Execution.Nodes.Obsidian.Json
{
    [NodeCategory("Obsidian/Json")]
    [GenericTypes(typeof(string), typeof(Uri), typeof(JToken), typeof(JObject),
                  typeof(JArray))]
    public class JsonGetObjectFromJArray<T> : ObjectFunctionNode<FrooxEngineContext, T>
    {
        public readonly ObjectInput<JArray> Input;
        public readonly ValueInput<int> Index;
   
        protected override T Compute(FrooxEngineContext context)
        {
            var input = Input.Evaluate(context);
            var index = Index.Evaluate(context);
            if (input == null || index < 0 || index >= input.Count)
                return default;

            try
            {
                return input[index].Value<T>();
            }
            catch
            {
                return default;
            }
        }
    }
}
