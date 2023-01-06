using Observable.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable
{
    internal class UserHandler
    {
        private readonly ObservableCollection<User> _users;
        private readonly Action<System.Collections.Specialized.NotifyCollectionChangedEventArgs> _userAction;

        public UserHandler(Action<System.Collections.Specialized.NotifyCollectionChangedEventArgs> userAction)
        {
            this._users = new ObservableCollection<User>();
            _users.CollectionChanged += CollectionChanged;
            _userAction = userAction;
        }
        public void AddUser(User user)
        {
            this._users.Add(user);
        }
        public void RemoveUser(string email)
        {
            var userToRemove = this.users.FirstOrDefault(user => user.Email == email);
            this.users.Remove(userToRemove);
        }

        private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this._userAction(e);
        }
    }
}
