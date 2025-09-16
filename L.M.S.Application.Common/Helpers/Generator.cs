using UUIDNext;

namespace L.M.S.Application.Common.Helpers;

public class Generator
{
    public static Guid CreateV7Guid()
    {
        return Uuid.NewDatabaseFriendly();
    }
}