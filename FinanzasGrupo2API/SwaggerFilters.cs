using System;
using System.Collections.Generic;
using System.Linq;
using FinanzasGrupo2API.Shared.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FinanzasGrupo2API
{
    public class SnakeCaseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths;

            //	New Keys
            var newPaths = new Dictionary<string, OpenApiPathItem>();
            var removeKeys = new List<string>(); // Old keys
            foreach (var path in paths)
            {
                var newKey = path.Key.ToLower();
                if (newKey != path.Key)
                {
                    removeKeys.Add(path.Key);
                    newPaths.Add(newKey, path.Value);
                }
            }

            foreach (var path in newPaths)
            {
                swaggerDoc.Paths.Add(path.Key, path.Value);
            }

            //	Removing old keys
            foreach (var key in removeKeys)
            {
                swaggerDoc.Paths.Remove(key);
            }
        }
    }
    public class SnakeCaseOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            for (int i = 0; i < operation.Tags.Count; ++i)
            {
                operation.Tags[i].Name = operation.Tags[i].Name.ToSnakeCase();
            }
        }
    }
}
