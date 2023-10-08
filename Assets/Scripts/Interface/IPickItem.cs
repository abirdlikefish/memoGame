public interface IPickItem
{
    void AddHP(bool ifRedHert , int num);
    void AddBomb(int num);
    void AddKey(int num);
    void AddMoney(int num);
    void UseKey();
    void AddTheHalo();
    void AddTranscendence();
    void AddSpoonBender();
    public bool isFullHP{set;get;}
    public int keyNum{set;get;}
}