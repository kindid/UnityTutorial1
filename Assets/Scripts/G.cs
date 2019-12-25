using UnityEngine;
using SQLite4Unity3d;

public class PlayerInfo
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string nick { get; set; }
    public int age { get; set; }
    // PNG is saved as binary. link here (can be null)
    // You can save a Texture directly
    // todo; figure out foreign key constraints etc
    public int pic_id { get; set; }
}

public class FrameData
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public byte[] pic { get; set; }
}

public class G : MonoBehaviour
{
    public static G g;      // generics/templates yadda yadda

    public SQLiteConnection connection;

    void Awake()
    {
        if (g == null)
        {
            g = this;
            // move the GO to a new runtime scene
            DontDestroyOnLoad(g);
            // ctor logic
            connection = new SQLiteConnection(
                "/Users/kuiash/tmp/unity_sqlite_test.db",
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            // now this is magic!
            connection.CreateTable<PlayerInfo>();
            connection.CreateTable<FrameData>();
        }
        else if (g != this)
        {
            Destroy(this);
        }
    }
}
