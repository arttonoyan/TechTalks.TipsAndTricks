using System.Diagnostics.CodeAnalysis;

namespace TechTalks.NullState;

public class Partition
{
    public string? ParentId { get; set; }

    [MemberNotNullWhen(true, nameof(ParentId))]
    public bool HasParent => ParentId != null;

    public bool HasParent_WithoutAnalysis => ParentId != null;
}
