using System.Diagnostics.CodeAnalysis;

namespace TechTalks.NullState;

public class Tenant
{
    private string _id;

    public Tenant() => EnsureIdentifier();

    [MemberNotNull(nameof(_id))]
    private void EnsureIdentifier()
    {
        _id = Guid.NewGuid().ToString();
    }
}
