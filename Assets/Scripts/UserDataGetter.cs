using UnityEngine;

public static class UserDataGetter
{
    public static UserData GetUserData()
    {
        return new UserData
        {
            Level = Random.Range(0, 8),
            Coins = Random.Range(50, 1500)
        };
    }
}
