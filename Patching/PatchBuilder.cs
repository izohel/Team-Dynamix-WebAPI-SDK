using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Patching;
public class PatchBuilder<T>
{
    private readonly List<PatchOperation> _operations = new();

    /// <summary>
    /// Adds or replaces a value at the specified path.
    /// </summary>
    public PatchBuilder<T> Add(string path, object value)
    {
        _operations.Add(new PatchOperation
        {
            Op = "add",
            Path = path,
            Value = value
        });
        return this;
    }
    /// <summary>
    /// Removes a value at the specified path.
    /// </summary>
    public PatchBuilder<T> Remove(string path)
    {
        _operations.Add(new PatchOperation
        {
            Op = "remove",
            Path = path
        });
        return this;
    }

    /// <summary>
    /// Builds the patch document to send with a PATCH request.
    /// </summary>
    public List<PatchOperation> Build() => _operations;
}
