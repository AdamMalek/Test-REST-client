using btDesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using btDesktopApp.Models;
using System.ComponentModel;

namespace btDesktopApp.ViewModels
{
    public class MainWindowVM: INotifyPropertyChanged
    {
        IDataService _dataService;

        private IEnumerable<User> _users;
        public IEnumerable<User> Users
        {
            get { return _users; }
            set { _users = value; RaiseChange("Users"); }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; RaiseChange("SelectedUser"); UsersPosts = _dataService.GetUsersPost(value.id); }
        }

        private IEnumerable<Post> _usersPosts;
        public IEnumerable<Post> UsersPosts
        {
            get { return _usersPosts; }
            set { _usersPosts = value; RaiseChange("UsersPosts"); }
        }

        private IEnumerable<Comment> _postsComments;
        public IEnumerable<Comment> PostsComments
        {
            get { return _postsComments; }
            set { _postsComments = value; RaiseChange("PostsComments"); }
        }

        private Post _selectedPost;
        public Post SelectedPost
        {
            get { return _selectedPost; }
            set { _selectedPost = value; RaiseChange("SelectedPost"); GetPostData(); }
        }

        private void GetPostData()
        {
            PostsComments = _dataService.GetPostsComments(SelectedPost.id);
            int temp = 0;
            Statistics = _dataService.GetStatisticsForPost(SelectedPost.id).Select(x=> $"#{++temp} => {x.Key}: {x.Value}");
        }

        private IEnumerable<string> _statistics;
        public IEnumerable<string> Statistics
        {
            get { return _statistics; }
            set { _statistics = value; RaiseChange("Statistics"); }
        }

        private bool _isWorking;

        public bool IsWorking
        {
            get { return _isWorking; }
            set { _isWorking = value; RaiseChange("IsWorking"); }
        }



        public MainWindowVM(IDataService dataService)
        {
            _dataService = dataService;
            Users = dataService.GetUsers();
        }   
            
        public event PropertyChangedEventHandler PropertyChanged;
        void RaiseChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
