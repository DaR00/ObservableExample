// See https://aka.ms/new-console-template for more information
using Observable;
using Observable.Model;

Console.WriteLine("Hello, World!");
Message msg = new() { AddText = "Új felhasználó hozzáadva: ", RemoveText = "Felhasználó eltávolítva: " };
UserHandler userHandler = new UserHandler((evnt) =>
{
    if (evnt.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
    {
        foreach (var item in evnt.NewItems)
        {
            var  user  = item as User;
            Console.WriteLine(msg.AddText + user.Name);
        }
        return;
    }

    if (evnt.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
    {
        foreach (var item in evnt.OldItems)
        {
            var user = item as User;
            Console.WriteLine(msg.RemoveText + user.Name);
        }
        return;
    }

});
User user = new User() { Name = "Teszt Elek", Email = "teszt.elek@obs.hu", Nationality = "HU" };

userHandler.AddUser(user);
Thread.Sleep(4000);
var user1 = user with { Name = "Gazos Gizella", Email = "gazos.gizi@obs.hu" };
userHandler.AddUser(user1);
Thread.Sleep(2000);
var user2 = user with { Name = "Kaki Maki", Email = "kaki.maki@obs.hu" };
userHandler.AddUser(user2);
Thread.Sleep(6000);
userHandler.RemoveUser("gazos.gizi@obs.hu");